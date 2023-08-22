using System;
using System.Globalization;
using AutoMapper;
using QLSV.DTOs;
using QLSV.Models;

namespace QLSV
{
	public class AutoMapperProfile:Profile
	{
		private readonly AppdbContext dbContext;
        public AutoMapperProfile()
		{
			dbContext = new AppdbContext();
			CreateMap<SinhVien, SinhVienDTO>()
			.ForMember(dest => dest.ngaysinhString, opt => opt.MapFrom(src => src.NgaySinh.Value.ToString("yyyy-MM-dd")))
			.ForMember(dest => dest.khoaid, opt => opt.MapFrom(src => src.KhoaId))
			.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();


			CreateMap<SinhVienDTO, SinhVien>()
			.ForMember(dest => dest.NgaySinh, opt => opt.MapFrom(src => DateTime.ParseExact(src.ngaysinhString, "yyyy-MM-dd", CultureInfo.InvariantCulture)));


			CreateMap<Khoa, KhoaDTO>();
		}
	}
}

