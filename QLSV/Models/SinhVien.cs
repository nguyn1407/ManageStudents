using System;
namespace QLSV.Models
{
	public class SinhVien
	{
		public int Id { get; set; }

		public string ?MaSV { get; set; }

		public string ?TenSV { get; set; }

		public DateTime? NgaySinh { get; set; }

		public string? GioiTinh { get; set; }

		public int? KhoaId { get; set; }

		public DateTime? CreateAt { get; set; }

		public DateTime? UpdateAt { get; set; }

		public virtual Khoa Khoa { get; set; }
	
	}
}

