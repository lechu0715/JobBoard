using ErrorOr;

namespace JobBoard.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class CompanyUser
        {
            public static Error DuplicateEmail => Error.Conflict(code: "CompanyUser.DuplicateEmail", description: "Email is already in use.");
        }
    }
}
