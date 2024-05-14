﻿using System.Collections.Generic;

namespace MusicShool.Entities
{
    public class User
    {
        public int UsersId { get; set; }
        public int IdPost { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; } = null;
        public string Password { get; set; } = null;
        public Post IdPostNavigation { get; set; } = null;
        public ICollection<Journal> IdJournals { get; set; } = new List<Journal>();
    }
}
