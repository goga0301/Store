using Banking.Domain.Models.Models;

namespace Banking.Domain.Service.Domain
{
    public interface IAccountService
    {
        Task<int> AddAccount(CreateAccountModel account);
        void UpdateAccount(UpdateAccountModel account);
        void DeleteAccount(int Id);
        Task<AccountModel> GetAccountByIdAsync(int Id);
        Task<IEnumerable<AccountModel>> GetAllAccounts();
    }
}
