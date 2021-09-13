﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class GithubAccount
    {

        public Guid Id{ get; set; }
        public string Nickname{ get; set; }
        public Member Member{ get; set; }
        public int MemberId{ get; set; }

    }
}