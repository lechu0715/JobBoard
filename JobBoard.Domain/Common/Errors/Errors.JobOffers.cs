using ErrorOr;

namespace JobBoard.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class JobOffers
        {
            public static Error NotFound => Error.NotFound(code: "JobOffers.NotFound", description: "Job offer not found.");
        }
    }
}
