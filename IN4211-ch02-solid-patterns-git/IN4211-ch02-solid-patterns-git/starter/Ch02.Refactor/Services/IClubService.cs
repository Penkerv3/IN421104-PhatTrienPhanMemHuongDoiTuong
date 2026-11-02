using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Services;

// Interface định nghĩa các nghiệp vụ cốt lõi của câu lạc bộ (tuân thủ SRP và DIP)
public interface IClubService
{
    // Tạo câu lạc bộ mới và gửi email thông báo cho chủ nhiệm
    Club CreateClub(string name, string description, string presidentEmail);

    // Tiếp nhận và ghi danh thành viên mới vào câu lạc bộ
    Member AddMember(Guid clubId, string memberName, string email);
}
