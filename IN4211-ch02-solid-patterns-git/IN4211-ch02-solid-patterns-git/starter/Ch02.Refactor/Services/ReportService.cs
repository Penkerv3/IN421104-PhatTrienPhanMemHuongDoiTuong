using EduHub.Ch02.Patterns.Strategies;
using EduHub.Ch02.Repositories;

namespace EduHub.Ch02.Services;

// Cài đặt dịch vụ tạo báo cáo thống kê: Tập trung thu thập số liệu, ủy quyền định dạng cho Strategy (tuân thủ OCP)
public class ReportService : IReportService
{
    // Các kho lưu trữ phục vụ truy vấn số liệu
    private readonly IClubRepository _clubs;
    private readonly IMemberRepository _members;
    private readonly IEventRepository _events;

    // Khởi tạo ReportService nhận các kho lưu trữ qua constructor
    public ReportService(IClubRepository clubs, IMemberRepository members, IEventRepository events)
    {
        _clubs = clubs;
        _members = members;
        _events = events;
    }

    // Thu thập dữ liệu thống kê từ các repository và áp dụng chiến lược hiển thị đã chọn
    public string Generate(IReportStrategy strategy)
    {
        // Tổng hợp các chỉ số thống kê về số lượng thành viên, sự kiện, đăng ký và check-in cho từng câu lạc bộ
        var stats = _clubs.GetAll().Select(c =>
        {
            var events = _events.GetByClub(c.Id);
            return new ClubStat(
                c.Name,
                _members.GetByClub(c.Id).Count,
                events.Count,
                events.Sum(e => e.RegisteredMemberIds.Count),
                events.Sum(e => e.CheckedInMemberIds.Count));
        }).ToList();

        // Chuyển giao dữ liệu số liệu thô cho chiến lược định dạng tương ứng để kết xuất kết quả
        return strategy.Render(stats);
    }
}
