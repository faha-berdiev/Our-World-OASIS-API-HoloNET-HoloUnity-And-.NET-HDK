﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NextGenSoftware.OASIS.API.Core.Helpers;
using NextGenSoftware.OASIS.API.DNA;

namespace NextGenSoftware.OASIS.API.ONODE.WebAPI.Controllers
{
    [ApiController]
    [Route("api/eggs")]
    public class EggsController : OASISControllerBase
    {
        // OASISDNA _settings;

        //public EggsController(IOptions<OASISDNA> OASISSettings) : base(OASISSettings)
        public EggsController()
        {
            //_settings = OASISSettings.Value;
        }

        /// <summary>
        /// Get's all eggs currently hidden in the OASIS... PREVIEW - COMING SOON...
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetAllEggs")]
        public async Task<OASISResult<bool>> GetAllEggs()
        {
            // TODO: Finish implementing.
            return new()
            {
                IsError = false
            };
        }

        /// <summary>
        /// Get's the current egg quests. PREVIEW - COMING SOON...
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetCurrentEggQuests")]
        public async Task<OASISResult<bool>> GetCurrentEggQuests()
        {
            // TODO: Finish implementing.
            return new()
            {
                IsError = false
            };
        }

        /// <summary>
        /// Get's the current egg quests. PREVIEW - COMING SOON...
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetCurrentEggQuestLeaderBoard")]
        public async Task<OASISResult<bool>> GetCurrentEggQuestLeaderBoard()
        {
            // TODO: Finish implementing.
            return new()
            {
                IsError = false
            };        
        }
    }
}
