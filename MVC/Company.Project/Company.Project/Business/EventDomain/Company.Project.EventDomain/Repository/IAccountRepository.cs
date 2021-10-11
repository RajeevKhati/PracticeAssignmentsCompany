using Company.Project.EventDomain.Domain;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Project.EventDomain.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(Person person);

        Task<SignInResult> PasswordSignInAsync(Person person);

        Task SignOutAsync();
        string GetLoggedInUserId();
        Task<bool> FillListWithCorrespondingUserIds(ICollection<string> emailSet, ICollection<string> userIdList);

        bool IsUserPresentInDatabase(string userId);
        string GetUserFullName(string userId);
    }
}