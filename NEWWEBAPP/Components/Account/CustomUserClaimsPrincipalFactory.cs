﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using NEWWEBAPP.Client;
using NEWWEBAPP.Data;
using NEWWEBAPP.Helpers;
using System.Security.Claims;

namespace NEWWEBAPP.Components.Account
{
    public class CustomUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, IOptions<IdentityOptions> options) : UserClaimsPrincipalFactory<ApplicationUser>(userManager, options)
    {
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            ClaimsIdentity identity = await base.GenerateClaimsAsync(user);

            string profilePictureUrl = user.ImageId.HasValue ? $"/api/uploads/{user.ImageId}" : ImageHelper.DefaultProfilePicture;

            List<Claim> customClaims = [
                new Claim(nameof(UserInfo.FirstName), user.FirstName!),
                new Claim(nameof(UserInfo.LastName), user.LastName!),
                new Claim(nameof(UserInfo.ProfilePictureUrl), profilePictureUrl),
            ];

            identity.AddClaims(customClaims);

            return identity;
        }
    }
}