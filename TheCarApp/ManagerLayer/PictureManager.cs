using Database;
using DatabaseAccess;
using DTO;
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
        private readonly IDataAccess _dataAccess;
        private readonly IDataWriter _dataWriter;
        private readonly IDataRemover _dataRemover;

        public PictureManager(IDataAccess dataAccess, IDataWriter dataWriter, IDataRemover dataRemover)
        {
            pictures = new List<Picture>();
            _dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
            LoadPictures(); 
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

        public void LoadPictures()
        {
            if (_dataAccess.GetAllExtras() != null)
            {
                foreach (PictureDTO pic in _dataAccess.GetAllPictures())
                {
                    Picture picture = new Picture(pic.Id, pic.PictureURL);
                    pictures.Add(picture);
                }
            }
        }
    }

}
