using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingCelebration.IService;
using WeddingCelebration.Service;

namespace Authorized_services
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserService _userService;
        public ResourceOwnerPasswordValidator(IUserService userService)
        {
            _userService = userService;
        }
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            //IBarrageService _barrageService = new BarrageService();
            if(_userService.FindUserByuAccount(context.UserName, context.Password)!=null)
            //if (context.UserName == "test" && context.Password == "test")
            {
                context.Result = new GrantValidationResult(
                 subject: context.UserName,
                 authenticationMethod: OidcConstants.AuthenticationMethods.Password);
            }
            else
            {
                //验证失败
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant,
                    "invalid custom credential"
                    );
            }
            return Task.FromResult(0);
        }


    }
}
