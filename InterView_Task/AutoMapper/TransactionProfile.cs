using AutoMapper;
using InterView_Task.DTOs.Transaction;
using InterView_Task.Enums;
using InterView_Task.Models;

namespace InterView_Task.AutoMapper
{
    public class TransactionProfile:Profile
    {
        public TransactionProfile() {
            CreateMap<AddStockDto, TransactionDto>()
                .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(_ => TransactionType.AddStock));



            CreateMap<TransactionDto, InventoryTransactions>();
            CreateMap<InventoryTransactions, TransactionDto>();

            CreateMap<RemoveStockDto, TransactionDto>()

            .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(_ => TransactionType.RemoveStock));



            CreateMap<TransferStockDto, InventoryTransactions>()
           .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(_ => TransactionType.Transfer))
           .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
           .ForMember(dest => dest.UserId, opt => opt.Ignore());

        }
       
    }
}
