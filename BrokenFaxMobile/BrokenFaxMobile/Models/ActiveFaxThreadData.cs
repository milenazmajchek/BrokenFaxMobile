using System;
using System.Collections.Generic;
using System.Text;

namespace BrokenFaxMobile.Models
{
    public class ActiveFaxThreadData
    {
        public string Id { get; set; }
        public string CreatorName { get; set; }
        public int NextId { get; set; }
        public string NextName { get; set; }
        public string GroupName { get; set; }
        public int Remaining { get; set; }
        public int Length { get; set; }
        public DateTime Updated { get; set; }
    }
}
