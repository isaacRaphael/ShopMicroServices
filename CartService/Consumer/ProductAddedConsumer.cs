using MassTransit;
using ServicePackages;
using CartService.Contracts;
using CartService.Models;

namespace CartService.Consumer
{
    public class ProductAddedConsumer : IConsumer<ProductCreated>
    {
        private readonly  IProductTwinRepository _productTwinRepository;

        public ProductAddedConsumer(IProductTwinRepository productTwinRepository)
        {
            _productTwinRepository = productTwinRepository;
        }

        public async Task Consume(ConsumeContext<ProductCreated> context)
        {
            var message = context.Message;

            var productTwin = await _productTwinRepository.GetById(message.Id);

            if (productTwin != null)
            {
                return;
            }

            productTwin = new ProductTwin
            {
                Id = message.Id,
                Name = message.Name,
                Price = message.Price,
                ImageUrl = message.ImageUrl,
                Cost = message.Cost
            };

            await _productTwinRepository.Add(productTwin);
        }
    }
}

