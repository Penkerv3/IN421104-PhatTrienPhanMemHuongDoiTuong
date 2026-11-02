using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Repositories;

// Cài đặt IMemberRepository: Quản lý danh sách thành viên lưu trực tiếp trong bộ nhớ RAM
public class InMemoryMemberRepository : IMemberRepository
{
    // Danh sách lưu trữ các đối tượng Member trong bộ nhớ
    private readonly List<Member> _store = new();

    // Lấy toàn bộ thành viên trực thuộc một câu lạc bộ cụ thể theo ClubId
    public IReadOnlyList<Member> GetByClub(Guid clubId) =>
        _store.Where(m => m.ClubId == clubId).ToList();

    // Tìm kiếm thành viên theo ID trong danh sách bộ nhớ
    public Member? GetById(Guid id) => _store.FirstOrDefault(m => m.Id == id);

    // Thêm thành viên mới vào danh sách bộ nhớ
    public void Add(Member member) => _store.Add(member);
}
