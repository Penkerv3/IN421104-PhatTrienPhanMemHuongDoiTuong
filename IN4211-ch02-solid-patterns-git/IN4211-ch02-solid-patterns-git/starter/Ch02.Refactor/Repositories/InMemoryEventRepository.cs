using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Repositories;

// Cài đặt IEventRepository: Lưu trữ danh sách các sự kiện trong bộ nhớ RAM
public class InMemoryEventRepository : IEventRepository
{
    // Danh sách lưu trữ các đối tượng Event trong bộ nhớ
    private readonly List<Event> _store = new();

    // Lọc danh sách các sự kiện thuộc về câu lạc bộ cụ thể theo ClubId
    public IReadOnlyList<Event> GetByClub(Guid clubId) =>
        _store.Where(e => e.ClubId == clubId).ToList();

    // Tìm kiếm sự kiện theo ID trong danh sách bộ nhớ
    public Event? GetById(Guid id) => _store.FirstOrDefault(e => e.Id == id);

    // Thêm sự kiện mới vào danh sách bộ nhớ
    public void Add(Event ev) => _store.Add(ev);
}
