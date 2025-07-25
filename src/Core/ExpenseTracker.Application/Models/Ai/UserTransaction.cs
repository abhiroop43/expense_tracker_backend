namespace ExpenseTracker.Application.Models.AI;

public class UserTransaction
{
    public string? Id { get; set; }
    public string? TransactionTypeCode { get; set; }
    public string? WalletId { get; set; }
    public string? TransactionCategoryCode { get; set; }
    public DateTime? TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public string? ReceiptImageUrl { get; set; }

    public DateTime? CreatedDate { get; set; }
    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
    public string? UpdatedBy { get; set; }
}