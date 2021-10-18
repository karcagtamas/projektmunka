﻿using MeetHut.Services.Application.DTOs;
using MeetHut.Services.Application.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MeetHut.Services.Application.Interfaces
{
    /// <summary>
    /// Token Service
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Build access token
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="roles">Roles for claim</param>
        /// <returns>Created token</returns>
        string BuildAccessToken(UserTokenDTO user, IList<string> roles);

        /// <summary>
        /// Build refresh token
        /// </summary>
        /// <returns>Created token</returns>
        string BuildRefreshToken();

        /// <summary>
        /// Validate input token
        /// </summary>
        /// <param name="token">Token</param>
        /// <returns>True if it is valid</returns>
        bool ValidateToken(string token);

        /// <summary>
        /// Get claims from token
        /// </summary>
        /// <param name="token">Token</param>
        /// <returns>Claim principals</returns>
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

        /// <summary>
        /// Refresh tokens
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Refreshed tokens</returns>
        Task<TokenDTO> Refresh(TokenModel model);
    }
}
