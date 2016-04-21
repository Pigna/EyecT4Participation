﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation
{
    class Review
    {
        public int Score { get; set; }
        public string Description { get; set; }
        public string Reaction { get; set; }
        public bool Active { get; set; }

        public Review(int score, string description, string reaction, bool active)
        {
            this.Score = score;
            this.Description = description;
            this.Reaction = reaction;
            this.Active = active;
        }

        public Review()
        {

        }

        public void AddReaction(Account sender, string message, DateTime date)
        {

        }
    }
}