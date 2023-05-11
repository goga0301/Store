namespace Store.Domain.Entities.Enums
{
    public enum TransactionStatusEnum : byte
    {
        /// <summary>
        /// ტრანზაქცია პროცესშია
        /// </summary>
        InProgress = 1,

        /// <summary>
        /// ტრანზაქცია გაუქმდა გამომძახებელი არხის მიერ
        /// </summary>
        Rejected = 2,

        /// <summary>
        /// ტრანზაქციით დაგენერირებული ოფერი გამომძახებელმა არხმა გამოიყენა
        /// </summary>
        Accepted = 3,

        /// <summary>
        /// ტრანზაქცია დაერორდა ოფერების დაგენერირებისას
        /// </summary>
        Errored = 4
    }
}
