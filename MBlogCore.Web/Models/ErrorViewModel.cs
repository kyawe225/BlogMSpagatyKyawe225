namespace MBlogCore.Web.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

public class ModelErrorMessage
{
    public string fieldName { set; get; }
    public string? errorMessage { set; get; }
}