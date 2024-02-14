namespace WholesaleStore.Common.Responses;

public class ErrorResponse
{
    public string Code { get; set; } = default!;
    public string Message { get; set; } = default!;
    public IEnumerable<ErrorResponseFieldInfo> FieldErrors { get; set; } = default!;
}

public class ErrorResponseFieldInfo
{
    public string Code { get; set; } = default!;
    public string FieldName { get; set; } = default!;
    public string Message { get; set; } = default!;
}
