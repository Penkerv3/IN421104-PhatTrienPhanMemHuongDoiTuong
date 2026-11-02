namespace EduHub.Ch02.Notifications;

// Lớp EmailNotificationService: Cài đặt dịch vụ gửi thông báo qua email (thay thế chuỗi if-else domain email ở starter)
public class EmailNotificationService : INotificationService
{
    // Giả lập thao tác gửi nội dung thông báo tới hòm thư người nhận
    public void Send(string to, string message) =>
        Console.WriteLine($"  [EMAIL] to {to}: {message}");
}
