using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLSV.DTOs;
using QLSV.IServices;
using QLSV.Models;

namespace QLSV.Services
{
    public class KhoaService : IKhoaService
    {
        private readonly AppdbContext dbContext;
        private readonly IMapper mapper;

        public KhoaService(IMapper mapper)
        {
            this.mapper = mapper;
            dbContext = new AppdbContext();
        }

        public async Task<List<KhoaDTO>> GetKhoas()
        {
            var dskhoa = await dbContext.Khoas.ToListAsync();
            return mapper.Map<List<KhoaDTO>>(dskhoa);
        }
    }
}

