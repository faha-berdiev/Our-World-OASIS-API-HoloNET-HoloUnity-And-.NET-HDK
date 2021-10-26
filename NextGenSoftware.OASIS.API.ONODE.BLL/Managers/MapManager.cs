﻿using NextGenSoftware.OASIS.API.Core.Interfaces;
using NextGenSoftware.OASIS.API.Core.Objects;
using NextGenSoftware.OASIS.API.ONODE.BLL.Holons;
using NextGenSoftware.OASIS.API.ONODE.BLL.Interfaces;

namespace NextGenSoftware.OASIS.API.ONODE.BLL.Managers
{
    public class MapManager : OASISManager, IMapManager
    {
        public MapManager() : base()
        {

        }

        public bool Draw3DObjectOnMap(object obj, float x, float y)
        {
            return true;
        }

        public bool Draw2DSpriteOnMap(object sprite, float x, float y)
        {
            return true;
        }

        public bool Draw2DSpriteOnHUD(object sprite, float x, float y)
        {
            return true;
        }

        public bool SelectBuildingOnMap(Building building)
        {
            return true;
        }

        public bool HighlightBuildingOnMap(Building building)
        {
            return true;
        }

        public bool DrawRouteOnMap(float startX, float startY, float endX, float endY)
        {
            return true;
        }

        public bool CreateAndDrawRouteOnMapBeweenPoints(MapPoints points)
        {
            return true;
        }

        public bool ZoomMapOut(float value)
        {
            return true;
        }

        public bool ZoomMapIn(float value)
        {
            return true;
        }

        public bool PamMapLeft(float value)
        {
            return true;
        }

        public bool PamMapRight(float value)
        {
            return true;
        }

        public bool PamMapUp(float value)
        {
            return true;
        }

        public bool PamMapDown(float value)
        {
            return true;
        }

        public bool SelectHolonOnMap(IHolon holon)
        {
            return true;
        }

        public bool SelectQuestOnMap(IQuest quest)
        {
            return true;
        }

        public bool ZoomToHolonOnMap(IHolon holon)
        {
            return true;
        }

        public bool ZoomToQuestOnMap(IQuest quest)
        {
            return true;
        }

        public bool CreateAndDrawRouteOnMapBetweenHolons(IHolon fromHolon, IHolon toHolon)
        {
            return true;
        }
    }
}
