﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NextGenSoftware.OASIS.API.Core.Enums;
using NextGenSoftware.OASIS.API.Core.Helpers;
using NextGenSoftware.OASIS.API.Core.Interfaces;
using NextGenSoftware.OASIS.API.Core.Managers;
using NextGenSoftware.OASIS.API.Core.Objects;

namespace NextGenSoftware.OASIS.API.Core.Holons
{
    // Lightweight version of the AvatarDetail object used for SSO. If people need the extended Avatar info they can load the AvatarDetail object.
    // If people need to add/subreact karma from the Avatar then they need to use the AvatarDetail object, same with if they need to query their KarmaAkasicRecords (karma audit).
    public class Avatar : HolonBase, IAvatar
    {
        //public new Guid Id 
        //{
        //    get
        //    {
        //        return base.Id;
        //    }
        //    set
        //    {
        //        base.Id = value;
        //    }
        //}

        //Needed to work around bug in WebAPI where base class properties are not returned/serialized (it cannot be the same property name or it breaks Mongo for some unknown reason!)
        public Guid AvatarId
        {
            get
            {
                return base.Id;
            }
            set
            {
                base.Id = value;
            }
        }

        public new string Name
        {
            get
            {
                return FullName;
            }
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return string.Concat(Title, " ", FirstName, " ", LastName);
            }
        }
        public EnumValue<AvatarType> AvatarType { get; set; }
        public bool AcceptTerms { get; set; }
        public string VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
        public string ResetToken { get; set; }
        public string JwtToken { get; set; }

        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }

        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        public DateTime? LastBeamedIn { get; set; }
        public DateTime? LastBeamedOut { get; set; }
        public bool IsBeamedIn { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
        public string Image2D { get; set; }
        public int Karma { get; set; } //TODO: This really needs to have a private setter but in the HoloOASIS provider it needs to copy the object along with each property... would prefer another work around if possible?
        public int XP { get; set; }
        public int Level
        {
            get
            {
                if (this.Karma > 0 && this.Karma < 100)
                    return 1;

                if (this.Karma >= 100 && this.Karma < 200)
                    return 2;

                if (this.Karma >= 200 && this.Karma < 300)
                    return 3;

                if (this.Karma >= 777)
                    return 99;

                //TODO: Add all the other levels here, all the way up to 100 for now! ;=)

                return 1; //Default.
            }
        }

        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }

        public async Task<IAvatar> SaveAsync()
        {
            return await (ProviderManager.CurrentStorageProvider).SaveAvatarAsync(this);
        }
        public IAvatar Save()
        {
            return (ProviderManager.CurrentStorageProvider).SaveAvatar(this);
        }
    }
}