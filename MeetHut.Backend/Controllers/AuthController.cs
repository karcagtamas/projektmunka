﻿using System;
using MeetHut.Backend.Configurations;
using MeetHut.Services.Application.DTOs;
using MeetHut.Services.Application.Interfaces;
using MeetHut.Services.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MeetHut.Backend.Controllers
{
    /// <summary>
    /// Auth Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ApplicationConfiguration _applicationConfiguration;

        /// <summary>
        /// Init Auth controller
        /// </summary>
        /// <param name="authService">Auth Service</param>
        /// <param name="options">Application options</param>
        public AuthController(IAuthService authService, IOptions<ApplicationConfiguration> options)
        {
            _authService = authService;
            _applicationConfiguration = options.Value;
        }
        
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Token</returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public TokenDTO Login([FromBody] LoginModel model)
        {
            return _authService.Login(model);
        }
        
        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="model">Model</param>
        [HttpPost("registration")]
        [AllowAnonymous]
        public void Registration([FromBody] RegistrationModel model)
        {
            if (_applicationConfiguration.DisableRegistration)
            {
                throw new Exception("Registration is disabled");
            }
            _authService.Registration(model);
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        [HttpPost("logout")]
        public void Logout()
        {
            if (User.Identity == null || string.IsNullOrEmpty(User.Identity.Name))
            {
                throw new ArgumentException("Identity is invalid");
            }
            
            _authService.Logout(User.Identity.Name);
        }
    }
}