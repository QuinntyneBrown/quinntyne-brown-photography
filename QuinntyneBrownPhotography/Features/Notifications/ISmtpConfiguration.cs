namespace QuinntyneBrownPhotography.Features.Notifications
{
    public interface ISmtpConfiguration
    {
        string Host { get; set; }
        int Port { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}
