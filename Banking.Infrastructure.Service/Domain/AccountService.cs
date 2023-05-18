using Banking.Domain.Models.Mappers;
using Banking.Domain.Models.Models;
using Banking.Domain.Repository;
using Banking.Domain.Service.Domain;

namespace Banking.Infrastructure.Service.Domain
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<int> AddAccount(CreateAccountModel account)
        {
            return await _accountRepository.CreateAsync(account.Map());
        }

        public async void DeleteAccount(int Id)
        {
            var account = await _accountRepository.GetSingleAsync(x => x.Id == Id);
            if (account == null)
            {
                throw new Exception("ანგარიში ვერ მოიძებნა");
            }

            _accountRepository.SoftDelete(account);
            await _accountRepository.SaveChangesAsync();
        }



        public async Task<AccountModel> GetAccountByIdAsync(int id)
        {
            var account = await _accountRepository.GetSingleAsync(x => x.Id == id);
            if (account == null)
            {
                throw new Exception("ანგარიში ვერ მოიძებნა");
            }
            return account.Map();
        }

        public async void UpdateAccount(UpdateAccountModel accountUpdate)
        {
            var account = await _accountRepository.GetSingleAsync(x => x.Id == accountUpdate.Id);
            if (account == null)
            {
                throw new Exception("ანგარიში ვერ მოიძებნა");
            }

            account.Balance = accountUpdate.Balance;


            _accountRepository.Update(account);
            await _accountRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<AccountModel>> GetAllAccounts()
        {
            return (await _accountRepository.GetAllAsync()).Select(x => x.Map());
        }
    }
}
