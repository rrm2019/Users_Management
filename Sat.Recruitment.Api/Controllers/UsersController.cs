using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Application.DTO;
using Sat.Recruitment.Application.Services.Abstract;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    /// <summary>
    /// Schedule Controller
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;
        /// <summary>
        /// Constructor: Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userService">Service Application</param>
        /// <param name="logger">Logger</param>
        public UsersController(IUserService userService, ILogger logger)
        {
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <remarks>Properties of the resources and tasks come on another api call</remarks>
        /// <param name="newUser">user data to create</param>    
        /// <returns>Returns the result of the request</returns>
        [HttpPost]
        [Route("/createUser")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateUser(UserDto newUser)
        {
            _logger.LogInformation("Call to CreateUser");
            var result = await _userService.CreateUser(newUser);
            return Ok(result);
        }
    }
}
