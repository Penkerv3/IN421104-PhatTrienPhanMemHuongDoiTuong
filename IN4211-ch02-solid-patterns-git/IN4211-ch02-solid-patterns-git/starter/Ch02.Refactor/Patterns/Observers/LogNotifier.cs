using EduHub.Ch02.Domain;
using EduHub.Ch02.Logging;

namespace EduHub.Ch02.Patterns.Observers;

// Observer thứ hai: Tự động ghi log khi có sự kiện mới được tạo mà không cần can thiệp EventService
public class LogNotifier : IEventObserver
{
    // Dịch vụ ghi log độc lập
    private readonly IAppLogger _logger;

    // Khởi tạo LogNotifier với logger chỉ định
    public LogNotifier(IAppLogger logger) => _logger = logger;

    // Ghi nhận thông tin sự kiện mới vào hệ thống nhật ký
    public void OnEventCreated(Event ev, Club club) =>
        _logger.Info($"Event created: '{ev.Title}' ({club.Name})");
}
