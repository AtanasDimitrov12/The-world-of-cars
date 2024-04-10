using Database;
using DatabaseAccess;
using Entity_Layer;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer
{
    public class PictureManager : IPictureManager
    {
        public List<Picture> pictures { get; set; }
        private readonly IDataWriter _dataWriter;
        private readonly IDataRemover _dataRemover;

        public PictureManager(IDataWriter dataWriter, IDataRemover dataRemover)
        {
            pictures = new List<Picture>();
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
        }
        public void AddPicture(Picture pic)
        {
            pictures.Add(pic);
            _dataWriter.AddPicture(pic.PictureURL);
        }

        public void RemovePicture(Picture pic)
        {
            pictures.Remove(pic);
            //remover.RemovePicture(pic.Id);
        }
    }

}
