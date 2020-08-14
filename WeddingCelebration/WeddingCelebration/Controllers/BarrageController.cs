using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingCelebration.ApiGroup;
using WeddingCelebration.IService;

namespace WeddingCelebration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class BarrageController : Controller
    {
        private readonly IBarrageService _barrageService;
        public BarrageController(IBarrageService barrageService)
        {
            _barrageService = barrageService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: api/Barrage
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _barrageService.GetAllAsync();
            return Ok(data);
        }
        // GET: api/Barrage/5
        /// <summary>
        /// api/Barrage/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        [ApiGroup(new ApiGroupNames[] { ApiGroupNames.It, ApiGroupNames.Hr })]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Barrage
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Barrage/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
