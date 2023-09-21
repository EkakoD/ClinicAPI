using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicAPI.Application.Base
{

	public interface IResponse<T>
	{
        public bool Success { get; set; }

        public string Message { get; set; }
		public T Data { get; set; }
		public StatusCode Code { get; set; }
	}
	public enum StatusCode
	{
		Ok=200,
		NotFound=404,
		BadRequest=400
	}
    public class Response<T> : IResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public StatusCode Code { get ; set; }


        public void HasBadRequest(string Text)
        {
            Message = Text;
            Code = StatusCode.BadRequest;
        }
        public void NotFoundData(string Text)
        {
            Success = false;
            Message = Text;
            Code = StatusCode.NotFound;
        }
        public void SuccessData(string message =null)
        {
            Success = true;
            Code = StatusCode.Ok;
            Data = Data;
            Message = message;
        }
    }
}

