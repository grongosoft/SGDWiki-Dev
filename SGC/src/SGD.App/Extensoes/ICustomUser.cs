using Microsoft.AspNetCore.Identity;

namespace SGD.App.Extensoes
{
    public interface ICustomUser: ICustomUsers<IdentityUser>
    {
    }
}