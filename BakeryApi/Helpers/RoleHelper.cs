using System.Linq;

namespace BakeryApi.Helpers
{
    public static class RoleHelper
    {
        public static IQueryable<T> CheckUserAccess<T>(this IQueryable<T> query, int roleId) //where T : PublicObject
        {
            //switch (roleId)
            //{
            //    case (int) RoleEnum.Admin:
            //        return query;
            //    case (int) RoleEnum.User:
            //        return query.Where(w => w.IsActive && !w.IsDel);
            //    default:
            //        return null;
            //}
            return null;
        }
    }
}