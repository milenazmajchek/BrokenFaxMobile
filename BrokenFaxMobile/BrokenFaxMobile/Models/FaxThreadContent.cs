using System;
using System.Collections.Generic;
using System.Text;

namespace BrokenFaxMobile.Models
{
    public class FaxThreadContent
    {
        public string Id { get; set; }
        public string Term { get; set; }
        public string Remaining { get; set; }
        public List<NewUserInput> Input { get; set; }

    }
}
