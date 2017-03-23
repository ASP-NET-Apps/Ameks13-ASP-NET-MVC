using Microsoft.AspNet.Identity.Owin;
using MyWoodenHouse.Default.Auth.Models;
using System;
using System.Threading.Tasks;

namespace MyWoodenHouse.Default.Auth.Contracts
{
    // TODO Revise whether this should be disposable - remark from Viktor!
    public interface ISignInService : IDisposable
    {
        Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout);

        Task<bool> HasBeenVerifiedAsync();

        Task SignInAsync(ApplicationUser user, bool isPersistent, bool rememberBrowser);

        Task<SignInStatus> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberBrowser);

        Task<string> GetVerifiedUserIdAsync();

        Task<bool> SendTwoFactorCodeAsync(string provider);

        Task<SignInStatus> ExternalSignInAsync(ExternalLoginInfo loginInfo, bool isPersistent);
    }
}
