namespace EduHub.Ch02.Notifications;

// Factory Pattern: Interface chịu trách nhiệm khởi tạo dịch vụ thông báo phù hợp theo kênh (OCP & DIP)
public interface INotificationServiceFactory
{
    // Tạo và trả về đối tượng dịch vụ thông báo tương ứng với kênh chỉ định
    INotificationService Create(NotificationChannel channel);
}
