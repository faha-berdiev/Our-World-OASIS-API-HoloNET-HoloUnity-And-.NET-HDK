﻿using System;
using System.Collections.Generic;
using NextGenSoftware.OASIS.API.ONODE.BLL.Holons;

namespace NextGenSoftware.OASIS.API.ONODE.BLL.Interfaces
{
    public interface IQuestManager : IOASISManager
    {
        bool CompleteQuest(Guid questId);
        bool CreateQuest(Quest quest);
        bool DeleteQuest(Guid questId);
        Quest FindNearestQuestOnMap();
        List<Quest> GetAllCurrentQuestsForAvatar(Guid avatarId);
        bool HighlightQuestOnMap(Guid questId);
        bool UpdateQuest(Quest quest);
    }
}