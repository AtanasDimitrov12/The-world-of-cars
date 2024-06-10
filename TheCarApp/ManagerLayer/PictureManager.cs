using Database;
using DatabaseAccess;
using DTO;
using Entity_Layer;
using InterfaceLayer;
using System;
using System.Collections.Generic;

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
            LoadPictures(out _); 
        }

        public bool AddPicture(Picture pic, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                _dataWriter.AddPicture(pic.PictureURL);
                pictures.Add(pic);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool RemovePicture(Picture pic, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                _dataRemover.RemovePicture(pic.Id);
                pictures.Remove(pic);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool LoadPictures(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                var loadedPics = _dataAccess.GetAllPictures();
                if (loadedPics != null)
                {
                    foreach (PictureDTO pic in loadedPics)
                    {
                        Picture picture = new Picture(pic.Id, pic.PictureURL);
                        pictures.Add(picture);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public int GetPicId(string URL)
        {
            return _dataWriter.GetPictureId(URL);
        }
    }
}
