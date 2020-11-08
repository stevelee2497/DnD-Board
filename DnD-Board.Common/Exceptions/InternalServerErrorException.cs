using System;

namespace DnD_Board.Common.Exceptions
{
    public class InternalServerErrorException : Exception
	{
		public InternalServerErrorException(string message) : base(message)
		{
		}
	}
}
