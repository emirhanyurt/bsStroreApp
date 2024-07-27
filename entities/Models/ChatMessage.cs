﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entities.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public DateTime Timestamp { get; set; }
        public User? User { get; set; }
    }
}
