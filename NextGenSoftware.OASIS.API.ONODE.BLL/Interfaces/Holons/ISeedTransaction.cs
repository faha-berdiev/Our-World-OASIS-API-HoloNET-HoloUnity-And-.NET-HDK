﻿using System;
using NextGenSoftware.OASIS.API.Core.Interfaces;

namespace NextGenSoftware.OASIS.API.ONODE.BLL.Interfaces
{
    public interface ISeedTransaction : IHolon
    {
        int Amount { get; set; }
        Guid AvatarId { get; set; }
        string AvatarUserName { get; set; }
        string Memo { get; set; }
    }
}