﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextGenSoftware.OASIS.API.Core.Helpers;
using NextGenSoftware.OASIS.API.DNA;

namespace NextGenSoftware.OASIS.API.ONODE.WebAPI.Controllers
{
    [ApiController]
    [Route("api/stats")]
    public class StatsController : OASISControllerBase
    {
        private readonly OASISDNA _OASISDNA;
        //OASISSettings _settings;

        //public StatsController(IOptions<OASISSettings> OASISSettings) : base(OASISSettings)
        //{
        //    _settings = OASISSettings.Value;
        //}

        public StatsController()
        {
            _OASISDNA = OASISBootLoader.OASISBootLoader.OASISDNA;
            //_settings = OASISSettings.Value;
        }

        /// <summary>
        /// Get's the stats for the currently logged in avatar. PREVIEW - COMING SOON...
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetStatsForCurrentLoggedInAvatar")]
        public OASISResult<bool> GetStatsForCurrentLoggedInAvatar()
        {
            // TODO: Finish implementing.
            return new();
        }

        [AllowAnonymous]
        [HttpGet("GetCurrentLiveVersion")]
        public OASISResult<string> GetCurrentLiveVersion()
        {
            return new(_OASISDNA.OASIS.CurrentLiveVersion) { IsError = false, Message = "OK" };
        }
        
        [AllowAnonymous]
        [HttpGet("GetCurrentStagingVersion")]
        public OASISResult<string> GetCurrentStagingVersion()
        {
            return new(_OASISDNA.OASIS.CurrentStagingVersion) { IsError = false, Message = "OK" };
        }
    }
}
