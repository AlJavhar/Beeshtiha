using Beeshtiha.Domain.Commons;
using Beeshtiha.Domain.Enums;

namespace Beeshtiha.Service.DTOs.Card;

public class CardForResultDto : Auditable
{
    public int CustomerId { get; set; }
    public int ItemsId { get; set; }
    public Status Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}
