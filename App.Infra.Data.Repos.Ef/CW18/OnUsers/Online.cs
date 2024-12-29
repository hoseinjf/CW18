using AppDomainCore.CW18.Cards.Entities;
using AppDomainCore.CW18.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.CW18.OnUsers
{
    public static class Online
    {
        public static User user { get; set; }
        public static Card card { get; set; }
    }
}
