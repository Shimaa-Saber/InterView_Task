using InterView_Task.DTOs.Product;
using InterView_Task.Models;
using AutoMapper;
using InterView_Task.DTOs.Transaction;
using InterView_Task.Enums;

namespace InterView_Task.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<Product, AddProductDto>();
            CreateMap<AddProductDto, Product>();
            CreateMap<EditProductDto, Product>();
            CreateMap<Product, EditProductDto>();

            CreateMap<AddStockDto, InventoryTransactions>()
           .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(_ => TransactionType.AddStock));

            CreateMap<TransactionDto, InventoryTransactions>();
            CreateMap<InventoryTransactions, TransactionDto>();

            CreateMap<RemoveStockDto, InventoryTransactions>()
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => -src.Quantity)) 
            .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(_ => TransactionType.RemoveStock))
            .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UserId, opt => opt.Ignore());


            CreateMap<TransferStockDto, InventoryTransactions>()
           .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(_ => TransactionType.Transfer))
           .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
           .ForMember(dest => dest.UserId, opt => opt.Ignore());
        }
    }
}
