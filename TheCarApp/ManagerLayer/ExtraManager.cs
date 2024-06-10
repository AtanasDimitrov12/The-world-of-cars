using Database;
using DTO;
using Entity_Layer;
using EntityLayout;
using InterfaceLayer;
using System;
using System.Collections.Generic;

namespace ManagerLayer
{
    public class ExtraManager : IExtraManager
    {
        public List<Extra> extras { get; set; }
        private readonly IDataAccess _dataAccess;
        private readonly ICarDataWriter _dataWriter;
        private readonly ICarDataRemover _dataRemover;

        public ExtraManager(IDataAccess dataAccess, ICarDataWriter dataWriter, ICarDataRemover dataRemover)
        {
            extras = new List<Extra>();
            this._dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
            LoadExtra(out _); // Initialize extras list
        }

        public bool AddExtra(Extra extra, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                _dataWriter.AddExtra(extra.ExtraName);
                extras.Add(extra);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool RemoveExtra(Extra extra, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                _dataRemover.RemoveExtra(extra.Id);
                extras.Remove(extra);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public int GetExtraId(string extraName)
        {
            return _dataWriter.GetExtraId(extraName);
        }

        public bool LoadExtra(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                var loadExtras = _dataAccess.GetAllExtras();
                if (loadExtras != null)
                {
                    foreach (ExtraDTO ex in loadExtras)
                    {
                        Extra extra = new Extra(ex.extraName, ex.Id);
                        extras.Add(extra);
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
    }
}
