namespace EduHub.Ch02.Notifications;

// Lớp SmsNotificationService: Cài đặt dịch vụ gửi thông báo qua tin nhắn SMS
public class SmsNotificationService : INotificationService
{
    // Giả lập thao tác gửi tin nhắn SMS tới số điện thoại người nhận
    public void Send(string to, string message) =>
        Console.WriteLine($"  [SMS] to {to}: {message}");
}
