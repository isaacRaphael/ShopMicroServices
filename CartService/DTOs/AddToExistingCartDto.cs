namespace CartService.DTOs
{
    public record  AddToExistingCartDto(Guid productId, Guid cartId);
}
