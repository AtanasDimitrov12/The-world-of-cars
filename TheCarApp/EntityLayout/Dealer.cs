using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Dealer : Member
    {
        private string _companyName;

        public Dealer(string Email, string Password, string CompanyName) : base(Email, Password) 
        { 
            this._companyName = CompanyName;
        }

        public override string ToString()
        {
            return _companyName;
        }
    }
}
