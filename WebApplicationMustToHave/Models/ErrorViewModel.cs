namespace WebApplicationMustToHave.DataModels
{
    public class ErrorViewDataModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
