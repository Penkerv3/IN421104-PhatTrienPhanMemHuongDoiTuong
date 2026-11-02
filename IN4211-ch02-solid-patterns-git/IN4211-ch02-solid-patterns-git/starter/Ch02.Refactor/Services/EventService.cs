using EduHub.Ch02.Domain;
using EduHub.Ch02.Patterns.Observers;
using EduHub.Ch02.Repositories;

namespace EduHub.Ch02.Services;

// Quản lý nghiệp vụ sự kiện đồng thời đóng vai trò Subject trong Observer Pattern
public class EventService : IEventService
{
    // Các kho dữ liệu lưu trữ và danh sách những observer đang theo dõi
    private readonly IClubRepository _clubs;
    private readonly IMemberRepository _members;
    private readonly IEventRepository _events;
    private readonly List<IEventObserver> _observers = new();

    // Khởi tạo EventService với các kho lưu trữ dữ liệu
    public EventService(IClubRepository clubs, IMemberRepository members, IEventRepository events)
    {
        _clubs = clubs;
        _members = members;
        _events = events;
    }

    // Đăng ký người quan sát mới vào danh sách theo dõi sự kiện
    public void Subscribe(IEventObserver observer) => _observers.Add(observer);

    // Loại bỏ người quan sát khỏi danh sách theo dõi sự kiện
    public void Unsubscribe(IEventObserver observer) => _observers.Remove(observer);

    // Nghiệp vụ tạo sự kiện: Kiểm tra hợp lệ, lưu trữ và kích hoạt thông báo tới mọi observer
    public Event CreateEvent(Guid clubId, string title, DateTime date)
    {
        // Kiểm tra câu lạc bộ tổ chức có tồn tại hay không
        var club = _clubs.GetById(clubId)
            ?? throw new InvalidOperationException("Club not found");

        // Kiểm tra tiêu đề sự kiện không được để trống
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Event title is required");

        // Khởi tạo đối tượng sự kiện mới và lưu vào kho dữ liệu
        var ev = new Event { Id = Guid.NewGuid(), ClubId = clubId, Title = title, Date = date };
        _events.Add(ev);

        // Phát thông báo sự kiện mới tới tất cả các observers đã đăng ký
        foreach (var observer in _observers.ToList())
            observer.OnEventCreated(ev, club);

        // Trả về sự kiện vừa được tạo
        return ev;
    }

    // Nghiệp vụ đăng ký tham gia sự kiện của thành viên thuộc câu lạc bộ
    public void Register(Guid eventId, Guid memberId)
    {
        // Lấy thông tin sự kiện và thông tin thành viên cần đăng ký
        var ev = GetEvent(eventId);
        var member = _members.GetById(memberId)
            ?? throw new InvalidOperationException("Member not found");

        // Đảm bảo thành viên đăng ký phải trực thuộc câu lạc bộ tổ chức sự kiện
        if (member.ClubId != ev.ClubId)
            throw new InvalidOperationException("Member does not belong to this club");

        // Gọi phương thức đăng ký của đối tượng Event
        ev.Register(memberId);
    }

    // Nghiệp vụ điểm danh check-in thành viên tại sự kiện
    public void CheckIn(Guid eventId, Guid memberId)
    {
        // Tìm sự kiện và chuyển tiếp lời gọi xác nhận check-in
        var ev = GetEvent(eventId);
        ev.CheckIn(memberId);
    }

    // Phương thức nội bộ tìm kiếm sự kiện theo ID hoặc báo lỗi nếu không tìm thấy
    private Event GetEvent(Guid id) =>
        _events.GetById(id) ?? throw new InvalidOperationException("Event not found");
}
