using EduHub.Ch02.Domain;
using EduHub.Ch02.Logging;
using EduHub.Ch02.Notifications;
using EduHub.Ch02.Repositories;

namespace EduHub.Ch02.Services;

// Cài đặt nghiệp vụ câu lạc bộ: Điều phối thao tác lưu trữ, kiểm tra sức chứa, ghi log và gửi thông báo
public class ClubService : IClubService
{
    // Các phụ thuộc interface được tiêm qua Dependency Injection (DIP)
    private readonly IClubRepository _clubs;
    private readonly IMemberRepository _members;
    private readonly INotificationService _notifier;
    private readonly IAppLogger _logger;

    // Khởi tạo ClubService nhận toàn bộ phụ thuộc qua constructor
    public ClubService(IClubRepository clubs, IMemberRepository members,
        INotificationService notifier, IAppLogger logger)
    {
        _clubs = clubs;
        _members = members;
        _notifier = notifier;
        _logger = logger;
    }

    // Nghiệp vụ tạo câu lạc bộ: Khởi tạo thực thể domain, lưu trữ, ghi log và gửi thông báo hoàn tất
    public Club CreateClub(string name, string description, string presidentEmail)
    {
        // Tạo thực thể Club và kiểm tra các quy tắc tính hợp lệ ngay tại lớp Domain
        var club = Club.Create(name, description);

        // Lưu đối tượng câu lạc bộ mới vào kho lưu trữ
        _clubs.Add(club);

        // Ghi nhận sự kiện tạo CLB vào nhật ký hệ thống
        _logger.Info($"Club created: {name}");

        // Gửi thông báo xác nhận thành lập câu lạc bộ tới email của chủ nhiệm CLB
        _notifier.Send(presidentEmail, $"Club '{name}' has been created");

        // Trả về thực thể câu lạc bộ vừa được tạo thành công
        return club;
    }

    // Nghiệp vụ tiếp nhận thành viên: Kiểm tra CLB tồn tại, kiểm tra giới hạn sĩ số, tạo thành viên và thông báo
    public Member AddMember(Guid clubId, string memberName, string email)
    {
        // Kiểm tra câu lạc bộ mục tiêu có tồn tại trong hệ thống hay không
        var club = _clubs.GetById(clubId)
            ?? throw new InvalidOperationException("Club not found");

        // Kiểm tra câu lạc bộ đã đạt giới hạn sĩ số tối đa hay chưa
        if (!club.HasRoom(_members.GetByClub(clubId).Count))
            throw new InvalidOperationException($"Club is full (max {Club.MaxMembers} members)");

        // Khởi tạo thực thể thành viên mới và liên kết với câu lạc bộ
        var member = new Member { Id = Guid.NewGuid(), Name = memberName, Email = email, ClubId = clubId };

        // Lưu thông tin thành viên mới vào kho lưu trữ dữ liệu
        _members.Add(member);

        // Ghi log hoạt động kết nạp thành viên mới
        _logger.Info($"Member {memberName} joined {club.Name}");

        // Gửi email chào mừng thành viên mới gia nhập câu lạc bộ
        _notifier.Send(email, $"Welcome to {club.Name}!");

        // Trả về thông tin thành viên vừa được kết nạp
        return member;
    }
}
