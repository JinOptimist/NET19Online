
namespace WebStoryFroEveryting.Services
{
    public class AuthService
    {
        public const string AUTH_TYPE = "AuthTypeSmile";
        public const string CLAIM_KEY_ID = "Id";
        public const string CLAIM_KEY_NAME = "Name";

        private IHttpContextAccessor _contextAccessor;

        public AuthService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserName()
        {
            var userName = _contextAccessor
                .HttpContext!
                .User
                .Claims
                .FirstOrDefault(x => x.Type == CLAIM_KEY_NAME)
                ?.Value
                ?? "Guest";

            return userName;
        }

        public int GetUserId()
        {
            var idStr = _contextAccessor
                .HttpContext!
                .User
                .Claims
                .First(x => x.Type == CLAIM_KEY_ID)
                .Value;

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
    }
}
