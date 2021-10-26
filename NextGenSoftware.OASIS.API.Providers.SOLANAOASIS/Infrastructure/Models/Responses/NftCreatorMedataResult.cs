﻿using Solnet.Metaplex;

namespace NextGenSoftware.OASIS.API.Providers.SOLANAOASIS.Infrastructure.Models.Responses
{
    public sealed class NftCreatorMedataResult
    {
        public string PublicKey { get; set; }
        public bool Verified { get; set; }
        public byte Share { get; set; }

        public NftCreatorMedataResult(Creator creator)
        {
            if(creator == null)
                return;

            PublicKey = creator.key.Key;
            Verified = creator.verified;
            Share = creator.share;
        }
    }
}