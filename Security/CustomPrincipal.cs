using Mix_MTA2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Mix_MTA2.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private NguoiDung NguoiDung;
        public CustomPrincipal(NguoiDung nguoiDung)
        {
            this.NguoiDung = nguoiDung;
            this.Identity = new GenericIdentity(NguoiDung.UserName);
        }
        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.NguoiDung.CapDo.Contains(r));
        }
    }
}