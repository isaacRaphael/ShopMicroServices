using CartService.Contracts;
using CartService.DTOs;
using CartService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;
        private readonly ICartRepository _cartRepository;
        private readonly IProductTwinRepository _productTwinRepository;
        private readonly ICartItemRepository _cartItemRepository;

        public CartController(ILogger<CartController> logger,
            ICartRepository cartRepository,
            IProductTwinRepository productTwinRepository,
            ICartItemRepository cartItemRepository)
        {
            _logger = logger;
            _cartRepository = cartRepository;
            _productTwinRepository = productTwinRepository;
            _cartItemRepository = cartItemRepository;
        }

        [HttpPost]
        [Route("{productId}")]
        public async Task<IActionResult> AddToNewCart(Guid productId)
        {
            try
            {
                var product = await _productTwinRepository.GetById(productId);
                if (product is null)
                    return NotFound();

                var cart = new Cart();
                var cartCreated = await _cartRepository.Add(cart);
                var cartItem = new CartItem
                {
                    Name = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    CartId = cartCreated.Id
                };
                var result = await _cartItemRepository.Add(cartItem);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new { Success = false, Message = "Error processing request" });
            }

        }

        [HttpPost]
        [Route("existingCart")]
        public async Task<IActionResult> AddToNewCart(AddToExistingCartDto dto)
        {
            try
            {
                var cart = await _cartRepository.GetById(dto.cartId);
                if (cart is null)
                    return NotFound();

                var product = await _productTwinRepository.GetById(dto.productId);
                if (product is null)
                    return NotFound();

                var cartItem = new CartItem
                {
                    Name = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    CartId = cart.Id
                };
                var result = await _cartItemRepository.Add(cartItem);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new { Success = false, Message = "Error processing request" });
            }
        }


    }
}
