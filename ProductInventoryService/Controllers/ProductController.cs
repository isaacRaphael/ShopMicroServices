using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductInventoryService.Contracts;
using ProductInventoryService.DTOs;
using ProductInventoryService.Models;
using ServicePackages;

namespace ProductInventoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public ProductController(IProductRepository productRepository, IPublishEndpoint publishEndpoint)
        {
            _productRepository = productRepository;
            _publishEndpoint = publishEndpoint;
        }


        [HttpPost]
        public async Task<IActionResult> AddProducts(AddproductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = new Product { Name = dto.Name, Cost = dto.Cost, Price = dto.Price, ImageUrl = dto.ImageUrl };
            var result = await _productRepository.Add(product);

            //publishing the just created product to the service bus (RabbitMQ)
           await _publishEndpoint.Publish(new ProductCreated(product.Id, product.Name, product.Price, product.Cost, product.ImageUrl));

            return Ok(result);
        }

       

    }

}
