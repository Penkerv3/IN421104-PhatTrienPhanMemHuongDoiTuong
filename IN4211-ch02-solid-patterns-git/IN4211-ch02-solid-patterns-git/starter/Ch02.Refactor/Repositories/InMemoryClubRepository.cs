using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Repositories;

// Cài đặt IClubRepository: Quản lý và lưu trữ dữ liệu câu lạc bộ trực tiếp trong danh sách RAM
public class InMemoryClubRepository : IClubRepository
{
    // Danh sách lưu trữ các đối tượng Club trong bộ nhớ
    private readonly List<Club> _store = new();

    // Trả về danh sách chỉ đọc chứa tất cả các câu lạc bộ hiện có
    public IReadOnlyList<Club> GetAll() => _store.AsReadOnly();

    // Tìm kiếm câu lạc bộ theo ID trong danh sách bộ nhớ
    public Club? GetById(Guid id) => _store.FirstOrDefault(c => c.Id == id);

    // Thêm câu lạc bộ mới vào danh sách bộ nhớ
    public void Add(Club club) => _store.Add(club);
}
