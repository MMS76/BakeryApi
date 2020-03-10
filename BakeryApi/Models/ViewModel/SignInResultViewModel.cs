namespace BakeryApi.Models.ViewModel
{
    public class SignInResultViewModel
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string RoleTitle { get; set; }
        public int RoleEnum { get; set; }
        public string Token { get; set; }
    }
}