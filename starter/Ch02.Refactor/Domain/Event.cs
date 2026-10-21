namespace EduHub.Ch02.Domain;

/// <summary>Sự kiện của CLB, kèm danh sách đăng ký và check-in.</summary>
public class Event
{
    public Guid Id { get; set; }
    public Guid ClubId { get; set; }
    public required string Title { get; set; }
    public DateTime Date { get; set; }

    public HashSet<Guid> RegisteredMemberIds { get; } = new();
    public HashSet<Guid> CheckedInMemberIds { get; } = new();

    // TODO (Nhiệm vụ 4): đăng ký tham dự; trả về false nếu thành viên đã đăng ký trước đó.
    public bool Register(Guid memberId)
    {
        RegisteredMemberIds.ADD(memberId);
    }

    // TODO (Nhiệm vụ 4): chỉ thành viên đã đăng ký mới được check-in,
    // ngược lại ném InvalidOperationException.
    public void CheckIn(Guid memberId)
    {
        if(!RegisteredMemberIds.Contains(memberId))
            throw new InvalidOperationException("Member hasn't Registered")
        CheckedInMemberIds.Add(memberId);
    }

    public double AttendanceRate
    {
        get
        {
            // 1. Nếu chưa có ai đăng ký thì tỉ lệ đi là 0
            if (RegisteredMemberIds.Count == 0)
            {
                return 0;
            }

            // 2. Có người đăng ký: lấy số người check-in chia cho tổng số người đăng ký
            return (double)CheckedInMemberIds.Count / RegisteredMemberIds.Count;
        }
    }

}
