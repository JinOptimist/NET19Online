using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebStoryFroEveryting.Controllers.ApiControllers;

namespace WebStoryFroEveryting.Controllers
{
    public class PurchaseCartoonController : Controller
    {

        public IActionResult CartoonStore()
        {
            return View();
        }
        public IActionResult InformationAPI()
        {

            return View();
        }

        [HttpGet("api/methods")]
        public IActionResult GetHttpPostMethods()
        {
            var type = typeof(FilmController);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                             .Where(x => x.IsDefined(typeof(HttpPostAttribute), inherit: true)).Select(x => x.Name)
                             .ToList();
            return Ok(methods);
        }

        [HttpGet("MethodWithParameters")]
        public IActionResult GetMethodWithParameters()
        {

            var type = typeof(PurchaseFilmsController);
            var methodWithParameters = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                                            .Where(x => x.GetParameters().Length > 0)
                                            .Select(x => new
                                            {
                                                Method = x.Name,
                                                Parameters = x.GetParameters().Select(p => new
                                                {
                                                    Type = p.ParameterType.Name,
                                                    Name = p.Name,
                                                    Properties = p.ParameterType.GetProperties()
                                                    .Select(x => new
                                                    {
                                                        Name = x.Name,
                                                        Type = x.PropertyType.Name
                                                    }).ToList()

                                                }).ToList(),
                                            }).ToList();

            return Ok(methodWithParameters);
        }

    }
}
