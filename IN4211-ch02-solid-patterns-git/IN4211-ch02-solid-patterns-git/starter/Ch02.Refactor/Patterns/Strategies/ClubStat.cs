namespace EduHub.Ch02.Patterns.Strategies;

// Bản ghi dữ liệu thống kê tổng hợp của câu lạc bộ làm đầu vào cho các chiến lược xuất báo cáo
public record ClubStat(string ClubName, int Members, int Events, int Registered, int CheckedIn);
