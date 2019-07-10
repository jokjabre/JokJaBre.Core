using System;
using System.Collections.Generic;
using System.Text;

namespace JokJaBre.Core.Objects
{
    public static class ApiExceptions
    {
        public static ApiException ObjectNotFound => NotFound("Object was not found");


        public static ApiException BadRequest(string message) => new ApiException(message, 400);
        public static ApiException Unauthorized(string message) => new ApiException(message, 401);
        public static ApiException Forbidden(string message) => new ApiException(message, 403);
        public static ApiException NotFound(string message) => new ApiException(message, 404);

        public static ApiException Error(string message) => new ApiException(message, 500);
        public static ApiException Error(string message, Exception inner) => new ApiException(message, inner, 500);
    }
}
