using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Patterns.Observers;

// Observer Pattern: Interface định nghĩa phương thức phản hồi khi có sự kiện mới được tạo ra
public interface IEventObserver
{
    // Phương thức lắng nghe và xử lý khi sự kiện mới của câu lạc bộ xuất hiện
    void OnEventCreated(Event ev, Club club);
}
