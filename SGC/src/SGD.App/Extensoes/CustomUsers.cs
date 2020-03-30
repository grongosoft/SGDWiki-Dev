using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SGD.App.Data;

namespace SGD.App.Extensoes
{
    public class CustomUsers : UserContext<IdentityUser>, ICustomUser
    {
        #region Public Constructors
       

        public CustomUsers(IdentityContext idContext, IHttpContextAccessor teste) : base(idContext, teste)
        {
           
        }

        #endregion Public Constructors

        #region Public Methods

        public static bool ValidarClaimsUsuario(HttpContext context, string claimName, string ClamValue)
        {
            return false;
        }

        public static bool ValidarUsuario(HttpContext context)
        {
            return context.User.Identity.IsAuthenticated;
        }



        #endregion Public Methods
    }
}