using System;
using System.Collections.Generic;
using System.Text;

namespace BrokenFaxMobile.Models
{
    public class GroupMembership
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public bool IsMember { get; set; }
    }
}
