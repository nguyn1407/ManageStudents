using System;
using QLSV.DTOs;

namespace QLSV.IServices
{
	public interface IKhoaService
	{
		Task<List<KhoaDTO>> GetKhoas();
	}
}

