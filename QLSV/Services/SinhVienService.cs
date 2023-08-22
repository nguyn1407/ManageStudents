using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLSV.DTOs;
using QLSV.IServices;
using QLSV.Models;
using QLSV.Paginations;

namespace QLSV.Services
{
	public class SinhVienService : ISinhVienService
	{
        private readonly AppdbContext dbContext;
        private readonly IMapper mapper;

       
        public SinhVienService(IMapper mapper)
        {
            this.mapper = mapper;
            dbContext = new AppdbContext();
		}

        public async Task<bool> AddSinhVien(SinhVienDTO sv)
        {
            if(sv.masv != null)
            {
                var sinhVien = await dbContext.SinhViens.FirstOrDefaultAsync(value => value.MaSV == sv.masv);
                if(sinhVien == null)
                {
                    var newSinhVien = mapper.Map<SinhVien>(sv);
                    newSinhVien.CreateAt = DateTime.Now;

                    //Khoa khoa = await dbContext.Khoas.FirstOrDefaultAsync(khoa => khoa.Id == sinhVien.KhoaId);
                    //newSinhVien.Khoa = khoa;

                    await dbContext.SinhViens.AddAsync(newSinhVien);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> DeleteSinhVien(string masv)
        {
            if(masv != "")
            {
                var sv = await dbContext.SinhViens.FirstOrDefaultAsync(sv => sv.MaSV == masv);
                if(sv != null)
                {
                    dbContext.Remove(sv);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> DeleteSinhViens(List<string> dsMasv)
        {
            if(dsMasv != null)
            {
                var dsDelete = await dbContext.SinhViens.Where(sv => dsMasv.Contains(sv.MaSV)).ToListAsync();

                dbContext.SinhViens.RemoveRange(dsDelete);

                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<PageResult<SinhVienDTO>> GetSinhViens(PagingParameters paging)
        {
           
            var query = await (from sv in dbContext.SinhViens
                         join khoa in dbContext.Khoas on sv.KhoaId equals khoa.Id
                         select new SinhVienDTO
                         {
                             Id = sv.Id,
                             gioitinh = sv.GioiTinh,
                             ngaysinh = sv.NgaySinh,
                             tensv = sv.TenSV,
                             khoaid = sv.KhoaId,
                             tenKhoa = khoa.TenKhoa,
                             masv = sv.MaSV
                             
                         }).ToListAsync();
                       
              

            return new PageResult<SinhVienDTO>(query, paging.PageNumber, paging.PageSize);
        }

        public async Task<PageResult<SinhVienDTO>> SearchInfo(string word, PagingParameters paging)
        {
            
            if (word == "" || word == null)
            {
                var dssv = await dbContext.SinhViens.ToListAsync();
                var redssv = mapper.Map<List<SinhVienDTO>>(dssv);
                return new PageResult<SinhVienDTO>(redssv, paging.PageNumber, paging.PageSize);
            }
            else
            {
                //var dsSearch = await dbContext.SinhViens.Where(sv => sv.MaSV.Contains(word) || sv.TenSV.Contains(word) || sv.GioiTinh.Contains(word)).ToListAsync();
            
                //var reSearch = mapper.Map<List<SinhVienDTO>>(dsSearch);

                //foreach (var sinhvien in reSearch)
                //{
                //    sinhvien.tenKhoa = await dbContext.Khoas.Where(khoa => khoa.Id == sinhvien.khoaid)
                //                                            .Select(khoa => khoa.TenKhoa)
                //                                            .FirstOrDefaultAsync();
                //}

                var query = await (from sv in dbContext.SinhViens
                             join khoa in dbContext.Khoas on sv.KhoaId equals khoa.Id
                             where sv.MaSV.Contains(word) || sv.TenSV.Contains(word) || sv.GioiTinh.Contains(word)
                             select new SinhVienDTO
                             {
                                 Id = sv.Id,
                                 gioitinh = sv.GioiTinh,
                                 ngaysinh = sv.NgaySinh,
                                 tensv = sv.TenSV,
                                 khoaid = sv.KhoaId,
                                 tenKhoa = khoa.TenKhoa,
                                 masv = sv.MaSV
                             }).ToListAsync();

                return new PageResult<SinhVienDTO>(query, paging.PageNumber, paging.PageSize);
            }
        }

        public async Task<bool> UpdateSinhVien(string masv, SinhVienDTO sv)
        {
           
                var sinhVien = await dbContext.SinhViens.FirstOrDefaultAsync(value => value.MaSV == masv);
                if(sinhVien != null)
                {
                    var khoa = await dbContext.Khoas.FirstOrDefaultAsync(khoa => khoa.Id == sv.khoaid);

                    SinhVien newSV = new SinhVien();

                    mapper.Map<SinhVienDTO, SinhVien>(sv, newSV);
         
                    sinhVien.UpdateAt = DateTime.Now;
                    sinhVien.Khoa = newSV.Khoa;
                    sinhVien.TenSV = newSV.TenSV;
                    sinhVien.GioiTinh = newSV.GioiTinh;
                    sinhVien.NgaySinh = newSV.NgaySinh;
                    sinhVien.KhoaId = newSV.KhoaId;
                    sinhVien.Khoa = khoa;

                    dbContext.SinhViens.Update(sinhVien);
               
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            
            return false;
        }

    }
}

