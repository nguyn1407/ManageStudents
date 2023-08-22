using System;
using QLSV.DTOs;
using QLSV.Paginations;

namespace QLSV.IServices
{
	public interface ISinhVienService
	{
		Task<PageResult<SinhVienDTO>> GetSinhViens(PagingParameters paging);
		Task<bool> AddSinhVien(SinhVienDTO sv);
		Task<bool> UpdateSinhVien(string masv, SinhVienDTO sv);
		Task<bool> DeleteSinhVien(string masv);
		Task<PageResult<SinhVienDTO>> SearchInfo(string word, PagingParameters paging);
		Task<bool> DeleteSinhViens(List<string> dsMasv);
	}
}

