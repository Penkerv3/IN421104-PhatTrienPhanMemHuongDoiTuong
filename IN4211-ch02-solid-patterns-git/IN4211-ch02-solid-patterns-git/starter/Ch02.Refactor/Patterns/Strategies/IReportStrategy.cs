namespace EduHub.Ch02.Patterns.Strategies;

// Strategy Pattern: Interface định nghĩa cách biểu diễn dữ liệu báo cáo thống kê theo các định dạng khác nhau
public interface IReportStrategy
{
    // Tên định dạng của chiến lược báo cáo
    string Name { get; }

    // Chuyển đổi danh sách số liệu thống kê thành chuỗi nội dung văn bản tương ứng
    string Render(IReadOnlyList<ClubStat> stats);
}
