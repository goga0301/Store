namespace Store.Domain.Entities.Enums
{
    public enum OrderStatusEnum
    {
        Created = 1,
        Processing = 2,
        WaitingForPayment = 3,
        Paid = 4,
        Delivered = 5,
        Cancelled = 6
    }
}
