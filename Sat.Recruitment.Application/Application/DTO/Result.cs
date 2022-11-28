
namespace Sat.Recruitment.Application.DTO
{
    /// <summary>
    /// Class indicating the status of the request
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Property indicating whether the request has been successful
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Property indicating whether the request has failed
        /// </summary>
        public string Errors { get; set; }
    }
}
