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
        private readonly ICarDataWriter _dataWriter;
        private readonly ICarDataRemover _dataRemover;

        public PictureManager(IDataAccess dataAccess, ICarDataWriter dataWriter, ICarDataRemover dataRemover)
        {
            pictures = new List<Picture>();
            _dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
            LoadPictures();
        }
        public string AddPicture(Picture pic)
        {
            try
            {
                _dataWriter.AddPicture(pic.PictureURL);
                pictures.Add(pic);
                return "done";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        public string RemovePicture(Picture pic)
        {
            try
            {
                _dataRemover.RemovePicture(pic.Id);
                pictures.Remove(pic);
                return "done";
            }
            catch (Exception ex)
            {
                return ex.Message;
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
