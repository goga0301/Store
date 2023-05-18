

using Banking.Domain.Entities;
using Banking.Domain.Entities.Enums;
using Banking.Domain.Models.Models;

namespace Banking.Domain.Models.Mappers
{
    public static  class AccountMappers
    {
        public static Account Map(this CreateAccountModel model)
        {
            return new Account
            {
                AccountNumber = model.AccountNumber,
                Balance = model.Balance,
                CreateDate = DateTimeOffset.Now,
                CreateUserId = "test",
                RecordStatus = RecordStatusEnum.Active
            };
        }

        public static AccountModel Map(this Account model)
        {
            return new AccountModel
            {
                Id = model.Id,
                AccountNumber = model.AccountNumber,
                Balance = model.Balance,
                CreateDate = model.CreateDate,
                CreateUserId = model.CreateUserId,
                RecordStatus = model.RecordStatus
            };
        }
    }
}
