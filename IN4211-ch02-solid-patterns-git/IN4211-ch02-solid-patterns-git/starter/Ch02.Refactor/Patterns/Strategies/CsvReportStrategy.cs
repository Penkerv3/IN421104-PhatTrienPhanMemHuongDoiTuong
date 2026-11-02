using System.Text;

namespace EduHub.Ch02.Patterns.Strategies;

// Cài đặt IReportStrategy: Định dạng dữ liệu thống kê thành dạng bảng tính chuẩn CSV
public class CsvReportStrategy : IReportStrategy
{
    // Tên định danh của chiến lược hiển thị CSV
    public string Name => "CSV";

    // Xây dựng chuỗi văn bản theo cấu trúc tệp tin CSV với dòng tiêu đề và các dòng dữ liệu
    public string Render(IReadOnlyList<ClubStat> stats)
    {
        // Khởi tạo StringBuilder với hàng tiêu đề chuẩn CSV
        var sb = new StringBuilder("Club,Members,Events,Registered,CheckedIn\n");

        // Lần lượt xuất dữ liệu của từng câu lạc bộ theo chuẩn CSV
        foreach (var s in stats)
            sb.Append($"\"{s.ClubName}\",{s.Members},{s.Events},{s.Registered},{s.CheckedIn}\n");

        // Trả về toàn bộ nội dung dữ liệu bảng tính CSV
        return sb.ToString();
    }
}
