using System.Threading.Tasks;
using BakeryApi.Models.Enum;
using BakeryApi.Models.ViewModel;

namespace BakeryApi.Repository.Interface
{
    public interface IUserRepository
    {
        Task<bool> SignInStepOne(SignInStepOneViewModel model);
        Task<SignInResultViewModel> SignInStepTwo(SignInStepTwoViewModel model);
        Task<bool> CheckUserAccess(long userId, RoleEnum[] roles);
    }
}