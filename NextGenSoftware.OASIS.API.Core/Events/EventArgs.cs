﻿using System;
using System.Collections.Generic;
using NextGenSoftware.OASIS.API.Core.Helpers;
using NextGenSoftware.OASIS.API.Core.Interfaces;
using NextGenSoftware.OASIS.API.Core.Interfaces.STAR;

namespace NextGenSoftware.OASIS.API.Core.Events
{
    public class OASISEventArgs<T> : EventArgs
    {
        public OASISResult<T> Result { get; set; }
    }

    public class OASISErrorEventArgs<T> : OASISEventArgs<T>
    {
        public string EndPoint { get; set; }
        public string Reason { get; set; }
        public Exception Exception { get; set; }
    }

    public class OASISErrorEventArgs : EventArgs
    {
        public string EndPoint { get; set; }
        public string Reason { get; set; }
        public Exception Exception { get; set; }
    }

    public class AvatarManagerErrorEventArgs : OASISErrorEventArgs<IAvatar>
    {

    }

    /*
    public class CelestialHolonLoadedEventArgs : EventArgs
    {
        public OASISResult<ICelestialHolon> Result { get; set; }
    }

    public class CelestialHolonSavedEventArgs : EventArgs
    {
        public OASISResult<ICelestialHolon> Result { get; set; }
    }

    public class CelestialHolonErrorEventArgs : EventArgs
    {
        public string Reason { get; set; }
        public OASISResult<ICelestialHolon> Result { get; set; }
    }
    */
    public class CelestialBodyLoadedEventArgs : OASISEventArgs<ICelestialBody>
    {

    }

    public class CelestialBodySavedEventArgs : OASISEventArgs<ICelestialBody>
    {
        
    }

    public class CelestialBodyErrorEventArgs : OASISErrorEventArgs<ICelestialBody>
    {

    }

    public class CelestialBodiesLoadedEventArgs : OASISEventArgs<IEnumerable<ICelestialBody>>
    {

    }
    public class CelestialBodiesSavedEventArgs : OASISEventArgs<IEnumerable<ICelestialBody>>
    {

    }

    public class CelestialBodiesErrorEventArgs : OASISErrorEventArgs<IEnumerable<ICelestialBody>>
    {

    }

    public class CelestialSpaceLoadedEventArgs : OASISEventArgs<ICelestialSpace>
    {

    }

    public class CelestialSpaceSavedEventArgs : OASISEventArgs<ICelestialSpace>
    {

    }

    public class CelestialSpaceErrorEventArgs : OASISErrorEventArgs<ICelestialSpace>
    {

    }

    public class CelestialSpacesLoadedEventArgs : OASISEventArgs<IEnumerable<ICelestialSpace>>
    {

    }

    public class CelestialSpacesSavedEventArgs : OASISEventArgs<IEnumerable<ICelestialSpace>>
    {

    }

    public class CelestialSpacesErrorEventArgs : OASISErrorEventArgs<IEnumerable<ICelestialSpace>>
    {

    }

    public class HolonLoadedEventArgs : OASISEventArgs<IHolon>
    {

    }

    public class HolonSavedEventArgs : OASISEventArgs<IHolon>
    {

    }

    public class HolonAddedEventArgs : OASISEventArgs<IEnumerable<IHolon>>
    {

    }

    public class HolonRemovedEventArgs : OASISEventArgs<IEnumerable<IHolon>>
    {

    }

    //public class HolonSavedEventArgs<IHolon> : OASISEventArgs<IHolon>
    //{

    //}

    public class HolonErrorEventArgs : OASISErrorEventArgs<IHolon>
    {

    }

    public class HolonsLoadedEventArgs : OASISEventArgs<IEnumerable<IHolon>>
    {
       
    }

    public class HolonsSavedEventArgs : OASISEventArgs<IEnumerable<IHolon>>
    {

    }

    public class HolonsErrorEventArgs : OASISErrorEventArgs<IEnumerable<IHolon>>
    {

    }



    //public class HolonsSavedEventArgs<T> : OASISEventArgs<T>
    //{

    //}

    public class ZomeLoadedEventArgs : OASISEventArgs<IZome>
    {

    }
   
    public class ZomeSavedEventArgs : OASISEventArgs<IZome>
    {

    }

    public class ZomeAddedEventArgs : OASISEventArgs<IZome>
    {
        
    }

    public class ZomeRemovedEventArgs : OASISEventArgs<IZome>
    {

    }

    public class ZomeErrorEventArgs : OASISErrorEventArgs<IZome>
    {

    }

    public class ZomesLoadedEventArgs : OASISEventArgs<IEnumerable<IZome>>
    {

    }

    public class ZomesSavedEventArgs : OASISEventArgs<IEnumerable<IZome>>
    {

    }

    public class ZomesErrorEventArgs : OASISErrorEventArgs<IEnumerable<IZome>>
    {

    }

    /*
    public class ConnectedEventArgs : EventArgs
    {
        public string EndPoint { get; set; }
    }

    public class DisconnectedEventArgs : EventArgs
    {
        public string EndPoint { get; set; }
        public string Reason { get; set; }
    }*/
}
