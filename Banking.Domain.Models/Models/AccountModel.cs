using Banking.Domain.Entities.Enums;

namespace Banking.Domain.Models.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public RecordStatusEnum RecordStatus { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string CreateUserId { get; set; }
    }

    public class CreateAccountModel
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }

    public class UpdateAccountModel
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
    }

    public class DeleteAccountModel
    {
        public int Id { get; set; }
    }


}
