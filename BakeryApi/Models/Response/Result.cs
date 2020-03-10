using System;
using System.Collections.Generic;

namespace BakeryApi.Models.Response
{
    public class Result
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public Pagination Pagination { get; set; }

        /// <summary>
        ///     کدهای خطا:
        ///     -1: خطای کاربر
        ///     -2: خطای ولیدیشن
        ///     -3: خطای سرور
        /// </summary>
        public List<Error> Errors { get; set; }


        public Result SetBadRequest(Exception ex)
        {
            Message = "خطایی رخ داد";
            Errors ??= new List<Error>();
            var msg = GetExceptionMessage(ex);
            var code = IsSystemErrorMessage(msg) ? "-3" : "-1";
            Errors.Add(new Error
            {
                Message = msg,
                ErrorCode = code,
                Field = ""
            });

            return this;
        }

        private string GetExceptionMessage(Exception ex)
        {
            if (ex.InnerException == null)
            {
                return ex.Message;
            }

            return GetExceptionMessage(ex.InnerException);
        }

        private bool IsSystemErrorMessage(string message)
        {
            return !(message.Contains('ا') ||
                     message.Contains('ب') ||
                     message.Contains('پ') ||
                     message.Contains('ت') ||
                     message.Contains('ث') ||
                     message.Contains('ج') ||
                     message.Contains('چ') ||
                     message.Contains('ح') ||
                     message.Contains('خ') ||
                     message.Contains('د') ||
                     message.Contains('ذ') ||
                     message.Contains('ر') ||
                     message.Contains('ز') ||
                     message.Contains('ژ') ||
                     message.Contains('س') ||
                     message.Contains('ش') ||
                     message.Contains('ص') ||
                     message.Contains('ض') ||
                     message.Contains('ط') ||
                     message.Contains('ظ') ||
                     message.Contains('ع') ||
                     message.Contains('غ') ||
                     message.Contains('ف') ||
                     message.Contains('ق') ||
                     message.Contains('ک') ||
                     message.Contains('گ') ||
                     message.Contains('ل') ||
                     message.Contains('م') ||
                     message.Contains('ن') ||
                     message.Contains('و') ||
                     message.Contains('ه') ||
                     message.Contains('ی'));
        }

        public Result SetSuccess(object data = null, string message = "عملیات با موفقیت انجام شد")
        {
            Data = data;
            Message = message;
            return this;
        }

        public Result SetSuccess(object data, int pageIndex, int pageSize, int total)
        {
            Data = data;
            Message = "عملیات با موفقیت انجام شد";
            Pagination = new Pagination
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Total = total
            };
            return this;
        }

        //public Result SetModelIsNotValid(IList<ValidationFailure> validationResultErrors)
        //{
        //    Errors = Errors ?? new List<Error>();
        //    foreach (var validationError in validationResultErrors)
        //    {
        //        Errors.Add(new Error()
        //        {
        //            ErrorCode = "-2",
        //            Message = validationError.ErrorMessage,
        //            Field = validationError.PropertyName,
        //        });
        //    }

        //    return this;
        //}
    }
}