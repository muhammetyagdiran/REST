using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REST.Business.Enums;

namespace REST.Business.ResponseModel
{
    public class BaseResponse
    {

        public bool Succeeded { get; set; } = false;
        public string Message { get; set; }
        public string[] Errors { get; set; } = new string[] { };
        public int ErrorCode { get; set; }

        public BaseResponse()
        {
            this.Succeeded = false;
            this.Message = string.Empty;
            this.Errors = new string[0];
        }
        public BaseResponse(string message = "", StatusCodes status = StatusCodes.Success)
        {
            Succeeded = status == StatusCodes.Success;
            Message = status == StatusCodes.Success ? message : "İşlem başarısız.";
        }

    }

    public class BaseResponse<T> : BaseResponse
    {

        public T Result { get; set; }
        public IList<T> List { get; set; }


        public BaseResponse()
        {
            this.Succeeded = false;
            this.Message = string.Empty;
        }

        public BaseResponse(T response, string message = "", StatusCodes status = StatusCodes.Success)
        {
            Succeeded = status == StatusCodes.Success;
            Message = status == StatusCodes.Success ? message : "İşlem başarısız.";
            Result = response;
        }
        public BaseResponse(int ErrorCode)
        {
            this.Succeeded = ErrorCode == 200 || ErrorCode == 0 ? true : false;
            this.ErrorCode = ErrorCode;
        }
        public BaseResponse(string ErrorMessage)
        {
            Message = ErrorMessage;
        }
        public BaseResponse(T response)
        {
            this.Succeeded = true;
            this.ErrorCode = 200;
            Result = response;
        }
        public BaseResponse(IList<T> list)
        {
            this.Succeeded = true;
            this.ErrorCode = 200;
            List = list;
        }
    }

}
