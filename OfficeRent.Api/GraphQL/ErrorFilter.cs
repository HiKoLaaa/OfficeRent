using System;
using HotChocolate;

namespace OfficeRent.Api.GraphQL
{
	internal class ErrorFilter : IErrorFilter 
	{
		public IError OnError(IError error) =>
			error.Exception is not null ? error.WithMessage(error.Exception.Message) : error;
	}
}