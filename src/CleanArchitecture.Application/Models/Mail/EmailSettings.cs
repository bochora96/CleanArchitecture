namespace CleanArchitecture.Application.Models.Mail;

public class EmailSettings
{
    public string ApiKey { get; set; } = null!;

    public string FromAddress { get; set; } = null!;

    public string FromName { get; set; } = null!;
}
