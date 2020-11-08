using System;

namespace DnD_Board.Common.Exceptions
{
	public class BadRequestException : Exception
	{
		public BadRequestException(string message) : base(message)
		{
		}
	}
}
