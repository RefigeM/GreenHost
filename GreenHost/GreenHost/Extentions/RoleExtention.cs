using GreenHost.Models.Enums;
using System.Data;

namespace GreenHost.Extentions
{
    public static class RoleExtention
    {
        public static string GetRole(this Roles role)
        {
            return role switch
            {
                Roles.User => nameof(Roles.User),
                Roles.Admin => nameof(Roles.Admin),
            };
        }
    }
}