﻿using Entity_Layer;
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
        void AddExtra(Extra extra);
        void RemoveExtra(Extra extra);
    }

}
