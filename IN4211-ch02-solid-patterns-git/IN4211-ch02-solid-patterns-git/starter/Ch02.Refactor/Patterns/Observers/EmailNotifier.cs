using EduHub.Ch02.Domain;
using EduHub.Ch02.Notifications;
using EduHub.Ch02.Repositories;

namespace EduHub.Ch02.Patterns.Observers;

// Observer xử lý gửi email thông báo tới toàn thể thành viên khi có sự kiện mới
public class EmailNotifier : IEventObserver
{
    // Các phụ thuộc cần thiết để truy xuất thành viên và thực hiện gửi thông báo
    private readonly IMemberRepository _members;
    private readonly INotificationService _notifier;

    // Khởi tạo EmailNotifier với kho thành viên và dịch vụ gửi thông báo
    public EmailNotifier(IMemberRepository members, INotificationService notifier)
    {
        _members = members;
        _notifier = notifier;
    }

    // Tự động kích hoạt duyệt danh sách thành viên và gửi email khi nhận tín hiệu sự kiện mới
    public void OnEventCreated(Event ev, Club club)
    {
        // Duyệt qua tất cả thành viên của câu lạc bộ và gửi thông tin chi tiết sự kiện qua email
        foreach (var m in _members.GetByClub(club.Id))
            _notifier.Send(m.Email, $"New event '{ev.Title}' at {club.Name} on {ev.Date:dd/MM/yyyy}");
    }
}
