namespace EduHub.Ch02.Notifications;

// Lớp SlackNotificationService: Cài đặt dịch vụ gửi thông báo qua nền tảng Slack
public class SlackNotificationService : INotificationService
{
    // Giả lập thao tác gửi thông điệp vào kênh hoặc người dùng trên Slack
    public void Send(string to, string message) =>
        Console.WriteLine($"  [SLACK] to {to}: {message}");
}
