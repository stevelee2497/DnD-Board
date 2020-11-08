using System;

namespace DnD_Board.Common.Exceptions
{
    public class DataNotFoundException : Exception
	{
		public DataNotFoundException(string message) : base(message)
		{
		}
	}
}
