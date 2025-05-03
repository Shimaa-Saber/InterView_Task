using AutoMapper;
using InterView_Task.DTOs.Reports;
using InterView_Task.Models;

namespace InterView_Task.AutoMapper
{
    public class ReportProfile: Profile
    {
        public ReportProfile()
        {
            CreateMap<Product, LowStockReportDto>();


            CreateMap<InventoryTransactions, TransactionHistoryDto>()
          .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : "Unknown"))
    .ForMember(dest => dest.Source, opt => opt.MapFrom(src => src.Source != null ? src.Source.Name : "N/A"))
    .ForMember(dest => dest.Destination, opt => opt.MapFrom(src => src.Destination != null ? src.Destination.Name : "N/A"))
    .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User != null ? src.User.UserName : "N/A"));
        }
    }
}
