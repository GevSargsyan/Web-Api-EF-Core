﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Member
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public GithubAccount GithubAccount { get; set; }

    }
}
