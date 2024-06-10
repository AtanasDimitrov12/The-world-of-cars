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
        bool AddExtra(Extra extra, out string errorMessage);
        bool RemoveExtra(Extra extra, out string errorMessage);
        int GetExtraId(string extraName);
        bool LoadExtra(out string errorMessage);
    }

}
