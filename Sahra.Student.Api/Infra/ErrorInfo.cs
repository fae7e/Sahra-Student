namespace Sahra.Student.Api.Infra
{
    public class ErrorInfo
    {
        public int Code { get; private set; }
        public string Message { get; private set; }
        public string Description { get; set; }
        public ErrorInfo(int code, string message)
        {
            Message = message;
            Code = code;
        }
        public ErrorInfo(string message)
        {
            Message = message;
            Code = (int)ErrorCodeEnum.BadRequest;
        }
    }
}
