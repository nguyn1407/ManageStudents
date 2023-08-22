using System;
namespace QLSV.DTOs
{
	public class SinhVienDTO
	{
        public int? Id { get; set; }

        public string? masv { get; set; }

        public string? tensv { get; set; }

        public DateTime? ngaysinh { get; set; }

        public string? ngaysinhString { get
            {
                return ngaysinh.Value.ToString("yyyy-MM-dd");
            }}
        
        public string? gioitinh { get; set; }

        public int? khoaid { get; set; }

        public string? tenKhoa { get; set; }

    }
}

