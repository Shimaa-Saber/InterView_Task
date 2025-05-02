using InterView_Task.DTOs.Transaction;
using InterView_Task.Models;

namespace InterView_Task.Interfaces
{
    public interface ITransaction: IGeneric<InventoryTransactions>
    {
        void AddTransaction(TransactionDto transaction,string UserId);
        void TransferStock(
    TransferStockDto request,
    string userId);


    }
}
