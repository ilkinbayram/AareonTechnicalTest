using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Models.Resources.Result
{
    public class Result
    {
        public bool IsSucceeded { get; set; }
        public List<string> ExceptionMessages { get; set; }

        public static Result Success()
        {
            return new Result() { IsSucceeded = true };
        }

        public static Result Failure(Exception ex)
        {
            var result = new Result();
            result.ExceptionMessages = InitializeExceptions(ex);
            return result;
        }

        protected static List<string> InitializeExceptions(Exception ex)
        {
            List<string> exceptionList = new List<string>();

            if (ex == null) return exceptionList;

            while (true)
            {
                exceptionList.Add(ex.Message);

                if (ex.InnerException == null) return exceptionList;
                ex = ex.InnerException;
            }
        }
    }


    public class Result<T> : Result
    {
        private T _data;
        public Result(T data)
        {
            _data = data;
            ExceptionMessages = new List<string>();
        }

        public Result()
        {
        }

        public T Data => _data;


        public static Result<T> Success(T data)
        {
            var result = new Result<T>(data) { IsSucceeded = true};
            return result;
        }

        public new static Result<T> Failure(Exception ex)
        {
            var result = new Result<T>();
            result.ExceptionMessages = InitializeExceptions(ex);
            return result;
        }
    }
}
