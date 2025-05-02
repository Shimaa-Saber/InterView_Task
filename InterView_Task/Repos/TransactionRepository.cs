using InterView_Task.Interfaces;
using InterView_Task.Models;

namespace InterView_Task.Repos
{

    public class TransactionRepository : ITransaction
    {
        private readonly dbContext _context;
        public TransactionRepository(dbContext context)
        {
            _context = context;
        }
        public void Add(InventoryTransactions transaction)
        {
           _context.Transactions.Add(transaction);
        }

        public void Delete(InventoryTransactions transaction)
        {
           _context.Transactions.Remove(transaction);
        }

        public List<InventoryTransactions> GetAll()
        {
            return _context.Transactions.ToList();
        }

        public InventoryTransactions GetById(int id)
        {
            return _context.Transactions.FirstOrDefault(T=> T.Id == id);
        }

        public void Save()
        {
           _context.SaveChanges();
        }

        public void Update(InventoryTransactions transaction)
        {
            _context.Transactions.Update(transaction);
        }
    }
}
