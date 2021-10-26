﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NextGenSoftware.OASIS.API.Core.Helpers;
using NextGenSoftware.OASIS.API.ONODE.WebAPI.Repositories;

namespace NextGenSoftware.OASIS.API.ONODE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class SCMSDrawings : ControllerBase
    {
        SCMSRepository _scmsRepository = new();

        [HttpGet]
        public async Task<OASISResult<IEnumerable<Drawing>>> GetAllDrawings()
        {
            return await _scmsRepository.GetAllDrawings();
        }

        [HttpGet("GetAllDrawingsForSequenceAndPhase/{sequenceNo}/{phaseNo}/{loadPhase}/{loadFile}")]
        public async Task<OASISResult<IEnumerable<Drawing>>> GetAllDrawingsForSequenceAndPhase(int SequenceNo, int PhaseNo, bool loadPhase = false, bool loadFile = true)
        {
            return await _scmsRepository.GetAllDrawings(SequenceNo, PhaseNo, loadPhase, loadFile);
        }

        [HttpGet("GetAllDrawingsForSequenceAndPhase/{sequenceNo}/{phaseNo}")]
        public async Task<OASISResult<IEnumerable<Drawing>>> GetAllDrawingsForSequenceAndPhase(int SequenceNo, int PhaseNo)
        {
            return await _scmsRepository.GetAllDrawings(SequenceNo, PhaseNo);
        }
    }
}
