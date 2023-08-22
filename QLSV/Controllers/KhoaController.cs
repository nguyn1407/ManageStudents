using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSV.DTOs;
using QLSV.IServices;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QLSV.Controllers
{
    public class KhoaController : ControllerBase
    {
        private readonly IKhoaService khoaser;

        public KhoaController(IKhoaService khoaser)
        {
            this.khoaser = khoaser;
        }

        [HttpGet("GetAllKhoas")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetKhoas()
        {
            var dskhoa = await khoaser.GetKhoas();
            var respone = new APIRespone { status = true, message = "Get all khoa success!!", data = dskhoa };
            return Ok(respone);
        }
    }
}

