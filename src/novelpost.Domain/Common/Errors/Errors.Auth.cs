using ErrorOr;

namespace novelpost.Domain.Common.Errors;

public static partial class Errors
{
    public static class Auth
    {
        public static Error InvalidCredentials => Error.Conflict(
            code: "Auth.InvalidCred",
            description: "Invalid credentials."
        );
    }
}
