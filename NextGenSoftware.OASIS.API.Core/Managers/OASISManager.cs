﻿using System;
using System.Threading.Tasks;
using NextGenSoftware.OASIS.API.Core.Events;
using NextGenSoftware.OASIS.API.Core.Interfaces;
using NextGenSoftware.OASIS.API.DNA;

namespace NextGenSoftware.OASIS.API.Core.Managers
{
    public abstract class OASISManager
    {
        public OASISDNA OASISDNA { get; set; }

        public Task<ISearchResults> SearchAsync(ISearchParams searchParams)
        {
            throw new NotImplementedException();
        }

        //Events
        public delegate void OASISManagerError(object sender, OASISErrorEventArgs e);
        public event OASISManagerError OnOASISManagerError;

        public delegate void StorageProviderError(object sender, OASISErrorEventArgs e);

       //TODO: In future more than one storage provider can be active at a time where each call can specify which provider to use.
        public OASISManager(IOASISStorage OASISStorageProvider, OASISDNA OASISDNA = null)
        {
            if (OASISStorageProvider != null)
            {
                ProviderManager.SetAndActivateCurrentStorageProvider(OASISStorageProvider);
                OASISStorageProvider.StorageProviderError += OASISStorageProvider_StorageProviderError;
            }

            if (OASISDNA == null)
            {
                if (OASISDNAManager.OASISDNA == null)
                    OASISDNAManager.LoadDNA();

                this.OASISDNA = OASISDNAManager.OASISDNA;
            }
            else
                this.OASISDNA = OASISDNA;

            //TODO: Need to unsubscribe events to stop memory leaks...
        }

        private void OASISStorageProvider_StorageProviderError(object sender, AvatarManagerErrorEventArgs e)
        {
            OnOASISManagerError?.Invoke(this, new OASISErrorEventArgs() { ErrorDetails = e.ErrorDetails, Reason = e.Reason });
        }
    }
}
