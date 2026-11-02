namespace EduHub.Ch02.Notifications;

// Interface trừu tượng hóa dịch vụ gửi thông báo (tuân thủ OCP: thêm kênh mới không làm sửa đổi mã hiện tại)
public interface INotificationService
{
    // Gửi thông báo đến địa chỉ người nhận
    void Send(string to, string message);
}
