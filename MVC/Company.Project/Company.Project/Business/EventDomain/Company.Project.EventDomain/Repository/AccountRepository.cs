using Company.Project.EventDomain.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.EventDomain.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContext;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContext = httpContext;
        }

        public async Task<IdentityResult> CreateUserAsync(Person person)
        {
            var user = new ApplicationUser()
            {
                Email = person.Email,
                FullName = person.FullName,
                UserName = person.Email
            };
            var result = await _userManager.CreateAsync(user, person.Password);
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(Person person)
        {
            var result = await _signInManager.PasswordSignInAsync(person.Email, person.Password, false, false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public string GetLoggedInUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public async Task<bool> FillListWithCorrespondingUserIds(ICollection<string> emailSet, ICollection<string> userIdList)
        {
            int i = 0;
            foreach(string email in emailSet)
            {
                var user = await _userManager.FindByEmailAsync(email.Trim());
                if (user == null || 
                    email.Trim().Equals(_userManager.FindByIdAsync(GetLoggedInUserId()).Result.Email)
                    )
                {
                    return false;
                }
                string userId = user.Id;
                userIdList.Add(userId);
                i++;
            }
            return true;
        }

        public bool IsUserPresentInDatabase(string userId)
        {
            try
            {
                var result = _userManager.FindByIdAsync(userId).Result.Id;
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public string GetUserFullName(string userId)
        {
            return _userManager.FindByIdAsync(userId).Result.FullName;
        }


    }
}
