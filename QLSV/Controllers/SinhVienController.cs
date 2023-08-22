using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLSV.DTOs;
using QLSV.IServices;
using QLSV.Models;
using QLSV.Paginations;
using QLSV.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QLSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {

        
        private readonly ISinhVienService svser;
     

        public SinhVienController(ISinhVienService svser)
        {

            this.svser = svser;
        }

        // GET: api/values
        [HttpGet("GetAllSinhViens")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> GetSinhViens([FromQuery]PagingParameters paging)
        {
            var dssv = await svser.GetSinhViens(paging);
            var respone = new APIRespone { status = true, message = "Get all sinh vien success!!", data = dssv };
            return Ok(respone);
        }

        [HttpPost("CreateNew")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddSinhVien(SinhVienDTO sv)
        {
            var created = await svser.AddSinhVien(sv);
            if (created)
            {
                var respone = new APIRespone { status = true, message = "Created new sinh vien success!!", data = sv };
                return Ok(respone);
            }
            else
            {
                var respone = new APIRespone { status = false, message = "Unable create new sinh vien!!", data = sv };
                return BadRequest(respone);
            }
        }

        [HttpDelete("DeleteOne/{masv}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> DeleteOneSinhVien(string masv)
        {
            var deleted = await svser.DeleteSinhVien(masv);
            if (deleted)
            {
                var respone = new APIRespone { status = true, message = "Delete sinh vien success!!", data = null };
                return Ok(respone);
            }
            else
            {
                var respone = new APIRespone { status = false, message = "Unable delete sinh vien!!", data = null };
                return BadRequest(respone);
            }
        }

        [HttpPut("UpdateSinhVien/{masv}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateSinhVien(string masv, SinhVienDTO sv)
        {
            var updated = await svser.UpdateSinhVien(masv, sv);
            if (updated)
            {
                var respone = new APIRespone { status = true, message = "Update sinh vien success!!", data = sv };
                return Ok(respone);
            }
            else
            {
                var respone = new APIRespone { status = false, message = "Unable update sinh vien!!", data = sv };
                return BadRequest(respone);
            }
        }


        [HttpGet("SearchSV/{word}")]
        [ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        public async Task<ActionResult> SearchSinhVien(string word,[FromQuery] PagingParameters paging)
        {
            var dssv = await svser.SearchInfo(word, paging);
            
            var respone = new APIRespone { status = true, message = "Search sinh vien success!!", data = dssv };
            return Ok(respone);
            
          
        }


        [HttpDelete("DeleteSinhViens")]
        public async Task<ActionResult> DeleteSinhViens(List<string> dsmaSV)
        {
            if(dsmaSV.Count() > 0)
            {
                var deleted = await svser.DeleteSinhViens(dsmaSV);
                var respone = new APIRespone { status = true, message = "Delete ds sinh vien success!!", data = dsmaSV };
                return Ok(respone);
            }
            else
            {
                var respone = new APIRespone { status = true, message = "Danh sách rỗng!!", data = null };
                return BadRequest(respone);
            }
        }
    }
}

