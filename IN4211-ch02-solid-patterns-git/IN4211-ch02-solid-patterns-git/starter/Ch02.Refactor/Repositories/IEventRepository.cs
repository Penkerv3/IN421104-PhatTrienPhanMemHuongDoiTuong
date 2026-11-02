using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Repositories;

// Interface trừu tượng hóa kho lưu trữ dữ liệu sự kiện câu lạc bộ
public interface IEventRepository
{
    // Lấy danh sách toàn bộ các sự kiện thuộc một câu lạc bộ cụ thể
    IReadOnlyList<Event> GetByClub(Guid clubId);

    // Tìm kiếm sự kiện theo mã định danh duy nhất
    Event? GetById(Guid id);

    // Lưu một sự kiện mới vào kho dữ liệu
    void Add(Event ev);
}
