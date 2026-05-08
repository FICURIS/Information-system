using System;

public class Request
{
    public int RequestID { get; set; }
    public Course Course { get; set; }
    public RequestStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class RequestStatus
{
    public int StatusID { get; set; }
    public string StatusName { get; set; }
}