using Beeshtiha.Domain.Enums;

namespace Beeshtiha.Service.DTOs.Card;

public class CardForCreationDto
{
    public int CustomerId { get; set; }
    public int ItemsId { get; set; }
    public Status Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}
