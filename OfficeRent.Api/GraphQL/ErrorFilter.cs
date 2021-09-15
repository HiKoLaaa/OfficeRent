using HotChocolate;

namespace OfficeRent.Api.GraphQL
{
	internal class ErrorFilter : IErrorFilter
	{
		public IError OnError(IError error)
		{
			return error.Exception is not null ? error.WithMessage(error.Exception.Message) : error;
		}
	}
}