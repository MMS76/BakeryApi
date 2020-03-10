namespace BakeryApi.Models.Response
{
    public class Error
    {
        public string Message { get; set; }
        public string Field { get; set; }
        public string ErrorCode { get; set; }
    }
}