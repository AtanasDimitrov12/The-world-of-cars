using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Extra
    {
        public int Id { get; set; }
        public string ExtraName { get; set; }

        public Extra(string ExtraName, int ID) 
        { 
            this.ExtraName = ExtraName;
            this.Id = ID;
        }

        public Extra(string ExtraName)
        {
            this.ExtraName = ExtraName;
        }
    }
}
