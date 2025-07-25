namespace ExpenseTracker.Application.Features.Transaction.Queries.GetAllTransactions;

public class TransactionListDto
{
    public string? Id { get; set; }
    public string? TransactionTypeCode { get; set; }
    public string? TransactionCategoryCode { get; set; }
    public DateTime? TransactionDate { get; set; }
    public decimal Amount { get; set; }

    public DateTime? CreatedDate { get; set; }
    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
    public string? UpdatedBy { get; set; }
}