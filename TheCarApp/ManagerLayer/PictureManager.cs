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
        public string AddPicture(Picture pic)
        {
            string Message = _dataWriter.AddPicture(pic.PictureURL);
            if (Message == "done")
            {
                pictures.Add(pic);
                return "done";
            }
            else 
            {
                return Message;
            }
        }

        public string RemovePicture(Picture pic)
        {
            string Message = _dataRemover.RemovePicture(pic.Id);
            if (Message == "done")
            {
                pictures.Remove(pic);
                return "done";
            }
            else
            {
                return Message;
            }
        }

        public string LoadPictures()
        {
            try
            {
                var LoadedPics = _dataAccess.GetAllExtras();
                if (LoadedPics != null)
                {
                    foreach (PictureDTO pic in _dataAccess.GetAllPictures())
                    {
                        Picture picture = new Picture(pic.Id, pic.PictureURL);
                        pictures.Add(picture);
                    }
                }
                return "done";
            }
            catch (ApplicationException ex)
            {
                return ex.Message;
            }
            
        }
    }

}
