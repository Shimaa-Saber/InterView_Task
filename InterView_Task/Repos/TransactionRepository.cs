using AutoMapper;
using InterView_Task.DTOs.Transaction;
using InterView_Task.Interfaces;
using InterView_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace InterView_Task.Repos
{

    public class TransactionRepository : ITransaction
    {
        private readonly dbContext _context;
        private readonly IMapper _mapper;
        private readonly IProduct _productRepo;
        public TransactionRepository(dbContext context,
            IMapper mapper, IProduct productRepo)
            
        {
            _context = context;
            _mapper = mapper;
            _productRepo = productRepo;
        }
        public void Add(InventoryTransactions transaction)
        {
           _context.Transactions.Add(transaction);
        }

        public void AddTransaction(TransactionDto dto, string userId)
        {
            var transaction = _mapper.Map<InventoryTransactions>(dto);
            transaction.UserId = userId;
            transaction.TransactionDate = DateTime.UtcNow;

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







    
        public void TransferStock(
            TransferStockDto request,
            string userId)
        {
           
            if (request.SourceId == request.DestinationId)
                throw new ArgumentException("Source and destination warehouses cannot be the same");

     
            var product = _context.Products
                .Include(p => p.WarehouseStocks)
                .FirstOrDefault(p => p.Id == request.ProductId);

            if (product == null)
                throw new KeyNotFoundException($"Product {request.ProductId} not found");

           
            var sourceStock = product.WarehouseStocks
                .FirstOrDefault(ws => ws.WarehouseId == request.SourceId);

            if (sourceStock == null || sourceStock.Quantity < request.Quantity)
                throw new InvalidOperationException(
                    $"Insufficient stock in source warehouse. Available: {sourceStock?.Quantity ?? 0}");

         
            var destStock = product.WarehouseStocks
                .FirstOrDefault(ws => ws.WarehouseId == request.DestinationId);

            if (destStock == null)
            {
                destStock = new WarehouseStock
                {
                    WarehouseId = request.DestinationId,
                    Quantity = 0
                };
                product.WarehouseStocks.Add(destStock);
            }

           
            sourceStock.Quantity -= request.Quantity;
            destStock.Quantity += request.Quantity;

          
            var transaction = _mapper.Map<InventoryTransactions>(request);
            transaction.UserId = userId;
            transaction.Quantity = request.Quantity; 
            _context.Transactions.AddAsync(transaction);
          

         
        }








    }
}
