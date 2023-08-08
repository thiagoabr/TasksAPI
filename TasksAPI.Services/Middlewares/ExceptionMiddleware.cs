using System.Net;
using TasksAPI.Domain.Exceptions;
using TasksAPI.Services.Models;

namespace TasksAPI.Services.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate? _requestDelegate;

        public ExceptionMiddleware(RequestDelegate? requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (TaskNotFoundException e)
            {
                await HandleExceptionAsync(context, e);
            }
            catch (UserAlreadyExistsException e)
            {
                await HandleExceptionAsync(context, e);
            }
            catch (UserNotFoundException e)
            {
                await HandleExceptionAsync(context, e);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            switch (exception)
            {
                case TaskNotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case UserNotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                case UserAlreadyExistsException:
                    context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    break;

                case Exception:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";

            var errorResultModel = new ErrorResultModel
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message,
            };

            await context.Response.WriteAsync(errorResultModel.ToString());
        }
    }
}
