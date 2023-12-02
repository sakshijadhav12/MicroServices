using System;
using System.Collections.Generic;
using System.Text;

namespace PraticeProjectforAPICalling
{
    public  class APIResponse
    {
        public int Page { get; set; }
        public List<User> Data { get; set; }
    }
}
