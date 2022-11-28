namespace Sat.Recruitment.Application.Constants
{
    /// <summary>
    /// ValidationError constants
    /// </summary>
    public static class ValidationError
    {
        /// <summary>
        /// String to indicate that the name is empty
        /// </summary>
        public const string ERROR_VALIDATION_NAME_EMPTY_OR_NULL = "The name is required";

        /// <summary>
        /// String to indicate that the email is empty
        /// </summary>
        public const string ERROR_VALIDATION_EMAIL_EMPTY_OR_NULL = "The email is required";

        /// <summary>
        /// String to indicate that the email is empty
        /// </summary>
        public const string ERROR_VALIDATION_EMAIL_NOT_VALID = "A valid email is required. Example: example@example.com";

        /// <summary>
        /// String to indicate that the address is empty
        /// </summary>
        public const string ERROR_VALIDATION_ADDRESS_EMPTY_OR_NULL = "The address is required";

        /// <summary>
        /// String to indicate that the phone is empty
        /// </summary>
        public const string ERROR_VALIDATION_PHONE_EMPTY_OR_NULL = "The phone is required";

    }
}
