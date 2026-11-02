using System.Text;

namespace EduHub.Ch02.Patterns.Strategies;

// Cài đặt IReportStrategy: Định dạng dữ liệu thống kê thành dạng văn bản trực quan trên màn hình Console
public class ConsoleReportStrategy : IReportStrategy
{
    // Tên định danh của chiến lược hiển thị Console
    public string Name => "Console";

    // Xây dựng chuỗi văn bản biểu diễn các dòng thống kê CLB
    public string Render(IReadOnlyList<ClubStat> stats)
    {
        // Khởi tạo StringBuilder để ghép nội dung báo cáo
        var sb = new StringBuilder();

        // Định dạng từng bản ghi thống kê câu lạc bộ thành dòng thông tin trực quan
        foreach (var s in stats)
            sb.AppendLine($"Club: {s.ClubName} | Members: {s.Members} | Events: {s.Events} | " +
                          $"Registered: {s.Registered} | Checked-in: {s.CheckedIn}");

        // Trả về toàn bộ nội dung báo cáo hoàn chỉnh
        return sb.ToString();
    }
}
