using Beeshtiha.Domain.Commons;
using Beeshtiha.Domain.Enums;

namespace Beeshtiha.Domain.Entities;

public class Card :Auditable
{
   public int CustomerId { get; set; }
   public User User { get; set; }

    public int ItemsId { get; set; }
    public Dish Dish { get; set; }

    public Status Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}
