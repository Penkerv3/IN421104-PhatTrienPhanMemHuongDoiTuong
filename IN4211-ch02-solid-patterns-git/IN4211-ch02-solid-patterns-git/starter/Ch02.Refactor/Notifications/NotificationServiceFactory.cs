namespace EduHub.Ch02.Notifications;

// Cài đặt Factory Pattern: Quản lý tập trung logic tạo đối tượng dịch vụ thông báo cụ thể
public class NotificationServiceFactory : INotificationServiceFactory
{
    // Ánh xạ từng kênh thông báo sang đối tượng triển khai dịch vụ tương ứng
    public INotificationService Create(NotificationChannel channel) => channel switch
    {
        NotificationChannel.Email => new EmailNotificationService(),
        NotificationChannel.Sms => new SmsNotificationService(),
        NotificationChannel.Slack => new SlackNotificationService(),
        _ => throw new ArgumentOutOfRangeException(nameof(channel), channel, "Unsupported channel")
    };
}
