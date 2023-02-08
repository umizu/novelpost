using ErrorOr;

namespace novelpost.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "A user with this email already exists"
        );
    }
}
