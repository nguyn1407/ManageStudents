using System;
using Microsoft.EntityFrameworkCore;

namespace QLSV.Models
{ 
    public class AppdbContext:DbContext
	{
		
		public virtual DbSet<SinhVien> SinhViens { get; set; }

        public virtual DbSet<Khoa> Khoas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=localhost,1433; Database=QLSV; User=SA;Password=123456aA@$; Trusted_Connection=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var khoa = modelBuilder.Entity<Khoa>();
            khoa.HasKey(x => x.Id);
            khoa.Property(p => p.TenKhoa).IsRequired();


            var sinhvien = modelBuilder.Entity<SinhVien>();
            sinhvien.HasKey(x => x.Id);
                         
        }

    }
}

