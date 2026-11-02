using EduHub.Ch02.Domain;
using EduHub.Ch02.Patterns.Observers;

namespace EduHub.Ch02.Services;

// Interface định nghĩa các nghiệp vụ liên quan đến sự kiện và cơ chế Observer
public interface IEventService
{
    // Đăng ký một observer lắng nghe các sự kiện mới
    void Subscribe(IEventObserver observer);

    // Hủy đăng ký một observer khỏi danh sách lắng nghe
    void Unsubscribe(IEventObserver observer);

    // Tạo sự kiện mới và thông báo đến tất cả các observer đã đăng ký
    Event CreateEvent(Guid clubId, string title, DateTime date);

    // Ghi nhận thành viên đăng ký tham gia sự kiện
    void Register(Guid eventId, Guid memberId);

    // Xác nhận check-in thực tế của thành viên tại sự kiện
    void CheckIn(Guid eventId, Guid memberId);
}
