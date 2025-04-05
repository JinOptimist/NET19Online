using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using NUnit.Framework;
using StoreData.Models;
using StoreData.Repostiroties;
using System.Security.Claims;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEverything.Test.Services
{
    public class AuthServiceTest
    {
        [Test]
        public void GetCurrentUser_GetUserFromRepository()
        {
            //Prepare
            var iHttpContextAccessor = new Mock<IHttpContextAccessor>();
            var claims = new List<Claim> { new Claim(AuthService.CLAIM_KEY_ID, "42") };
            iHttpContextAccessor
                .Setup(x => x.HttpContext!.User.Claims)
                .Returns(claims);

            var iUserRepository = new Mock<IUserRepository>();

            var userFromDb = new UserData();
            iUserRepository
                .Setup(x => x.Get(42))
                .Returns(userFromDb);

            var authService = new AuthService(
                iHttpContextAccessor.Object,
                iUserRepository.Object);

            //Act
            var user = authService.GetCurrentUser();

            //Assert
            Assert.That(user == userFromDb, "We need get user from UserRepository");
        }
    }
}
