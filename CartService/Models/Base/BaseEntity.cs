namespace CartService.Models.Base
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedOn = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
