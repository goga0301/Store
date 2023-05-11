namespace Store.Domain.Entities.Enums
{
    public enum ChangeStatusEnum : byte
    {
        /// <summary>
        /// ავტორიზებული
        /// </summary>
        Authorized = 1,
        /// <summary>
        /// არაავტორიზებული
        /// </summary>
        UnAuthorized = 2,
        /// <summary>
        /// უარყოფილი
        /// </summary>
        DeAuthorized = 3
    }
}
