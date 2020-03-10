namespace BakeryApi.Models.ViewModel
{
    public class SignInStepOneViewModel
    {
        public string PhoneNumber { get; set; }
    }

    public class SignInStepTwoViewModel
    {
        public string PhoneNumber { get; set; }
        public string SecurityCode { get; set; }
    }
}