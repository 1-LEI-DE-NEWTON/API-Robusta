using Manager.API.ViewModels;

namespace Manager.API.Utilities
{
    public static class Responses
    {
        public static ResultViewModel ApliccationError()
        {
            return new ResultViewModel
            {
                Success = false,
                Message = "Internal server error. Please, contact the administrator.",
                Data = null
            };
        }

        public static ResultViewModel DomainError(string message)
        {
            return new ResultViewModel
            {
                Success = false,
                Message = message,
                Data = null
            };
        }

        public static ResultViewModel DomainError (string message, IReadOnlyCollection<string> errors)
        {
            return new ResultViewModel
            {
                Success = false,
                Message = message,
                Data = errors
            };
        }

        public static ResultViewModel UnauthorizedError(string message)
        {
            return new ResultViewModel
            {
                Success = false,
                Message = "Unauthorized access",
                Data = null
            };
        }

        public static ResultViewModel Success(string message, object data)
        {
            return new ResultViewModel
            {
                Success = true,
                Message = message,
                Data = data
            };
        }
    }
}