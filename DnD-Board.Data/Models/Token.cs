using System;

namespace DnD_Board.Data.Models
{
    public class Token
    {
        public string AccessToken { get; set; }

        public DateTimeOffset Expires { get; set; }

        public string Type { get; set; }

        public string RefreshToken { get; set; }
    }
}