using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Repositories;

// Interface trừu tượng hóa kho lưu trữ dữ liệu thành viên câu lạc bộ
public interface IMemberRepository
{
    // Lấy danh sách thành viên thuộc về một câu lạc bộ cụ thể
    IReadOnlyList<Member> GetByClub(Guid clubId);

    // Tìm kiếm thông tin thành viên theo mã định danh duy nhất
    Member? GetById(Guid id);

    // Thêm thông tin thành viên mới vào kho dữ liệu
    void Add(Member member);
}
