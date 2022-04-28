using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealAsm.Models;
using Microsoft.AspNetCore.Identity;

namespace RealAsm.Areas.Identity.Data;

// Add profile data for application users by adding properties to the RealAsmUser class
public class RealAsmUser : IdentityUser
{
    public DateTime BirthDay { get; set; }
    public String Address { get; set; }
    public String Gender { get; set; }
    public String FullName { get; set; }
    public Store? Store { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }

}

