﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace NextGenSoftware.OASIS.API.ONODE.WebAPI.Controllers
{
    [ApiController]
    [Route("api/settings")]
    public class SettingsController : OASISControllerBase
    {
        OASISSettings _settings;

        public SettingsController(IOptions<OASISSettings> OASISSettings) : base(OASISSettings)
        {
            _settings = OASISSettings.Value;
        }

        /// <summary>
        /// Return's all settings for the currently logged in avatar. PREVIEW - COMING SOON...
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetAllSettingsForCurrentLoggedInAvatar")]
        public ActionResult<bool> GetAllSettingsForCurrentLoggedInAvatar()
        {
            // TODO: Finish implementing.
            return Ok();
        }
    }
}