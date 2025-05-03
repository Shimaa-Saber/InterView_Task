using InterView_Task.DTOs.Reports;

namespace InterView_Task.Interfaces
{
    public interface IReport
    {
        Task<List<LowStockReportDto>> GetLowStockReportAsync(string? category, bool OutOfStock);
        Task<List<TransactionHistoryDto> >GetTransactionHistoryAsync(
        int? productId,
        DateTime? startDate,
        DateTime? endDate,
        string? transactionType);
    }
}
