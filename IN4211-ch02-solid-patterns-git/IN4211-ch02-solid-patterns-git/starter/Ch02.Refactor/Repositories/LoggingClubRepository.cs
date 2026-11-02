using EduHub.Ch02.Domain;
using EduHub.Ch02.Logging;

namespace EduHub.Ch02.Repositories;

// Decorator Pattern: Bọc lấy IClubRepository để ghi log mỗi lần truy cập dữ liệu mà không cần sửa đổi repository gốc
public class LoggingClubRepository : IClubRepository
{
    // Lưu trữ tham chiếu tới repository gốc và logger phục vụ ghi log
    private readonly IClubRepository _inner;
    private readonly IAppLogger _logger;

    // Khởi tạo Decorator với repository mục tiêu và logger được tiêm vào
    public LoggingClubRepository(IClubRepository inner, IAppLogger logger)
    {
        _inner = inner;
        _logger = logger;
    }

    // Ghi log hoạt động và chuyển tiếp yêu cầu lấy tất cả câu lạc bộ tới repository gốc
    public IReadOnlyList<Club> GetAll()
    {
        // Ghi nhận nhật ký thao tác lấy toàn bộ danh sách CLB
        _logger.Info("[repo] GetAll clubs");

        // Gọi repository bên trong để lấy dữ liệu thực tế
        return _inner.GetAll();
    }

    // Ghi log hoạt động và chuyển tiếp yêu cầu tìm kiếm câu lạc bộ theo ID
    public Club? GetById(Guid id)
    {
        // Ghi nhận nhật ký thao tác tìm kiếm CLB theo ID
        _logger.Info($"[repo] GetById {id}");

        // Chuyển tiếp lời gọi tìm kiếm tới repository gốc
        return _inner.GetById(id);
    }

    // Ghi log hoạt động và chuyển tiếp yêu cầu thêm câu lạc bộ mới
    public void Add(Club club)
    {
        // Ghi nhận nhật ký thao tác bổ sung CLB mới
        _logger.Info($"[repo] Add club '{club.Name}'");

        // Chuyển tiếp đối tượng cần thêm tới repository gốc
        _inner.Add(club);
    }
}
