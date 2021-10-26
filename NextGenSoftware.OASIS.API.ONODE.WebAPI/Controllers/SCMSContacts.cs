﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using NextGenSoftware.OASIS.API.Core.Helpers;
using NextGenSoftware.OASIS.API.ONODE.WebAPI.Repositories;

namespace NextGenSoftware.OASIS.API.ONODE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class SCMSContacts : OASISControllerBase
    {
        private readonly SCMSRepository _scmsRepository = new();
        
        [HttpGet]
        public async Task<OASISResult<IEnumerable<Contact>>> GetAllContacts()
        {
            GetAndActivateDefaultProvider();
            return await _scmsRepository.GetAllContacts();
        }

        [HttpGet("GetAllContactsForSequenceAndPhase/{sequenceNo}/{phaseNo}")]
        public async Task<OASISResult<IEnumerable<Contact>>> GetAllContactsForSequenceAndPhase(int sequenceNo, int phaseNo)
        {
            GetAndActivateDefaultProvider();
            return await _scmsRepository.GetAllContacts(sequenceNo, phaseNo, false);
        }

        [HttpGet("GetAllContactsForSequenceAndPhase/{sequenceNo}/{phaseNo}/{loadPhase}")]
        public async Task<OASISResult<IEnumerable<Contact>>> GetAllContactsForSequenceAndPhase(int sequenceNo, int phaseNo, bool loadPhase = false)
        {
            GetAndActivateDefaultProvider();
            return await _scmsRepository.GetAllContacts(sequenceNo, phaseNo, loadPhase);
        }
    }
}
