﻿using Enums.User;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Services.ReflectionServices;

namespace WebStoryFroEveryting.Services
{
    [AutoRegistration]
    public class AuthService
    {
        public const string AUTH_TYPE = "AuthTypeSmile";
        public const string CLAIM_KEY_ID = "Id";
        public const string CLAIM_KEY_NAME = "Name";
        public const string CLAIM_KEY_PERMISSION = "Permission";

        private IHttpContextAccessor _contextAccessor;
        private IUserRepository _userRepository;

        public AuthService(IHttpContextAccessor contextAccessor, IUserRepository userRepository)
        {
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
        }

        public string GetUserName()
        {
            var userName = GetClaim(CLAIM_KEY_NAME)
                ?? "Guest";
            return userName;
        }

        public int GetUserId()
        {
            var idStr = GetClaim(CLAIM_KEY_ID);
            return int.Parse(idStr);
        }
    
        public bool IsAuthenticated()
        {
            return _contextAccessor
                .HttpContext!
                .User
                ?.Identity
                ?.IsAuthenticated
                ?? false;
        }
    
        public bool HasPermission(Permisson permisson)
        {
            var permissionInt = int.Parse(GetClaim(CLAIM_KEY_PERMISSION));
            if (permissionInt < 0)
            {
                return false;
            }

            var userPermisson = (Permisson)permissionInt;
            return userPermisson.HasFlag(permisson);
        }

        private string? GetClaim(string key)
        {
            return _contextAccessor
                .HttpContext!
                .User
                .Claims
                .FirstOrDefault(x => x.Type == key)
                ?.Value;
        }

        public bool IsAdmin()
        {
            return GetUserName() == "admin";
        }

        public string GetAvatarSrc()
        {
            return IsAuthenticated()
                ? $"/avatars/avatar-{GetUserId()}.jpg"
                : "/avatars/avatar-default.png";
        }

        public UserData GetCurrentUser()
        {
            return _userRepository.Get(GetUserId());
        }
    }
}
