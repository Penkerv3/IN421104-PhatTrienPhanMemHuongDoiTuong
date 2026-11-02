using EduHub.Ch02.Patterns.Strategies;

namespace EduHub.Ch02.Services;

// Interface định nghĩa dịch vụ tạo báo cáo thống kê sử dụng Strategy Pattern
public interface IReportService
{
    // Tạo báo cáo thống kê theo chiến lược định dạng được cung cấp
    string Generate(IReportStrategy strategy);
}
