using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IExtraManager
    {
        List<Extra> extras { get; set; }
        string AddExtra(Extra extra);
        string RemoveExtra(Extra extra);
        int GetExtraId(string Extra);
        string LoadExtra();
    }

}
