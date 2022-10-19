using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.DTO
{
    public class GetAllNumberOfFriends
    {
        public IList<Frinds> frinds { get; set; }
        public int numOfFriends { get; set; }
    }
}
