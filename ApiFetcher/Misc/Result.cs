using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFetcher
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Content { get; set; }
        public string Message { get; set; }
        
        private Result(T content, bool success, string message = "")
        {
            this.IsSuccess = success;
            this.Content = content;
            this.Message = message;
        }

        public static Result<T> Ok(T content)
        {
            return new Result<T>(content, true);
        }

        public static Result<T> Fail(string message)
        {
            return new Result<T>(default(T), false, message);
        }
    }
}
