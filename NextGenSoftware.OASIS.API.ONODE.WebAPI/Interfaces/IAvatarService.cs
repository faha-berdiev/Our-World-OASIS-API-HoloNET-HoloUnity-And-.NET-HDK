﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NextGenSoftware.OASIS.API.Core.Enums;
using NextGenSoftware.OASIS.API.Core.Helpers;
using NextGenSoftware.OASIS.API.Core.Interfaces;
using NextGenSoftware.OASIS.API.Core.Objects;
using NextGenSoftware.OASIS.API.ONODE.WebAPI.Models;
using NextGenSoftware.OASIS.API.ONODE.WebAPI.Models.Avatar;
using NextGenSoftware.OASIS.API.ONODE.WebAPI.Models.Security;

namespace NextGenSoftware.OASIS.API.ONODE.WebAPI.Interfaces
{
    public interface IAvatarService
    {
        Task<OASISResult<string>> GetTerms();
        Task<OASISResult<string>> ValidateAccountToken(string accountToken);
        Task<OASISResult<AuthenticateResponse>> Authenticate(AuthenticateRequest model, string ipAddress);
        Task<OASISResult<IAvatar>> RefreshToken(string token, string ipAddress);
        Task<OASISResult<string>> RevokeToken(string token, string ipAddress);
        Task<OASISResult<IAvatar>> Register(RegisterRequest model, string origin);
        Task<OASISResult<bool>> VerifyEmail(string token);
        Task<OASISResult<string>> ForgotPassword(ForgotPasswordRequest model, string origin);
        Task<OASISResult<string>> ValidateResetToken(ValidateResetTokenRequest model);
        Task<OASISResult<string>> ResetPassword(ResetPasswordRequest model);
        Task<OASISResult<IEnumerable<IAvatar>>> GetAll();
        Task<OASISResult<AvatarImage>> GetAvatarImageById(Guid id);
        Task<OASISResult<AvatarImage>> GetAvatarImageByUsername(string userName);
        Task<OASISResult<AvatarImage>> GetAvatarImageByEmail(string email);
        Task<OASISResult<string>> Upload2DAvatarImage(AvatarImage avatarImage);
        Task<OASISResult<IAvatar>> GetById(Guid id);
        Task<OASISResult<IAvatar>> GetByUsername(string userName);
        Task<OASISResult<IAvatar>> GetByEmail(string email);
        Task<OASISResult<IAvatar>> Create(CreateRequest model);
        Task<OASISResult<IAvatar>> Update(Guid id, UpdateRequest avatar);
        Task<OASISResult<IAvatar>> UpdateByEmail(string email, UpdateRequest avatar);
        Task<OASISResult<IAvatar>> UpdateByUsername(string username, UpdateRequest avatar);
        Task<OASISResult<bool>> Delete(Guid id);
        Task<OASISResult<bool>> DeleteByUsername(string username);
        Task<OASISResult<bool>> DeleteByEmail(string email);
        Task<OASISResult<IAvatarDetail>> GetAvatarDetail(Guid id);
        Task<OASISResult<IAvatarDetail>> GetAvatarDetailByUsername(string username);
        Task<OASISResult<IAvatarDetail>> GetAvatarDetailByEmail(string email);
        Task<OASISResult<IEnumerable<IAvatarDetail>>> GetAllAvatarDetails();
        Task<OASISResult<string>> GetAvatarUmaJsonById(Guid id);
        Task<OASISResult<string>> GetAvatarUmaJsonByUsername(string username);
        Task<OASISResult<string>> GetAvatarUmaJsonByMail(string mail);
        Task<OASISResult<IAvatar>> GetAvatarByJwt();
        Task<OASISResult<ISearchResults>> Search(ISearchParams searchParams);
        Task<OASISResult<IAvatarDetail>> LinkProviderKeyToAvatar(Guid avatarId, ProviderType telosOasis, string telosAccountName);
        Task<OASISResult<string>> GetProviderKeyForAvatar(string avatarUsername, ProviderType providerType);
        Task<OASISResult<string>> GetPrivateProviderKeyForAvatar(Guid avatarId, ProviderType providerType);
        Task<OASISResult<KarmaAkashicRecord>> AddKarmaToAvatar(Guid avatarId, AddRemoveKarmaToAvatarRequest addRemoveKarmaToAvatarRequest);
        Task<OASISResult<KarmaAkashicRecord>> RemoveKarmaFromAvatar(Guid avatarId, AddRemoveKarmaToAvatarRequest addKarmaToAvatarRequest);
    }
}
