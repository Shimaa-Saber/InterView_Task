using AutoMapper;
using AutoMapper.QueryableExtensions;
using InterView_Task.DTOs.Reports;
using InterView_Task.Interfaces;
using InterView_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace InterView_Task.Repos
{
    public class ReportReposatory : IReport
    {
        private readonly dbContext _context;
        private readonly IMapper _mapper;

        public ReportReposatory(dbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<LowStockReportDto>> GetLowStockReportAsync(
      string? category,
      bool OutOfStock)
        {
            var query = _context.Products
                .Where(p => p.Quantity <= p.LowStockThreshold);

            if (category!=null)
            {
                query = query.Where(p => p.Category == category);
            }

            if (!OutOfStock)
            {
                query = query.Where(p => p.Quantity > 0);
            }

            return await query
                .OrderBy(p => p.Quantity)
                .ProjectTo<LowStockReportDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }




        public async Task<List<TransactionHistoryDto>> GetTransactionHistoryAsync(
         int? productId,
         DateTime? startDate,
         DateTime? endDate,
         string? transactionType)
        {
            var query = _context.Transactions
                .Include(t => t.Product)
                .Include(t => t.Source)
                .Include(t => t.Destination)
                .AsQueryable();

         
            if (productId.HasValue)
                query = query.Where(t => t.ProductId == productId);

            if (startDate.HasValue)
                query = query.Where(t => t.TransactionDate >= startDate);

            if (endDate.HasValue)
                query = query.Where(t => t.TransactionDate <= endDate.Value.AddDays(1));

            if (transactionType!=null)
                query = query.Where(t => t.TransactionType.ToString() == transactionType);

            return await query
                .OrderByDescending(t => t.TransactionDate)
                .ProjectTo<TransactionHistoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
