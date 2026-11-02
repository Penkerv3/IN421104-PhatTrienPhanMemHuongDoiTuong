using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Repositories;

// Interface trừu tượng hóa kho lưu trữ dữ liệu câu lạc bộ (áp dụng Interface Segregation Principle - ISP)
public interface IClubRepository
{
    // Lấy toàn bộ danh sách câu lạc bộ hiện có
    IReadOnlyList<Club> GetAll();

    // Tìm kiếm thông tin câu lạc bộ theo mã định danh duy nhất
    Club? GetById(Guid id);

    // Lưu một câu lạc bộ mới vào kho dữ liệu
    void Add(Club club);
}
