﻿using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IPictureManager
    {
        void AddPicture(Picture picture);
        void RemovePicture(Picture picture);
    }

}