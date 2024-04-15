using Database;
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
    public class ExtraManager : IExtraManager
    {
        public List<Extra> extras { get; set; }
        private readonly IDataAccess _dataAccess;
        private readonly IDataWriter _dataWriter;
        private readonly IDataRemover _dataRemover;

        public ExtraManager(IDataAccess dataAccess, IDataWriter dataWriter, IDataRemover dataRemover)
        {
            extras = new List<Extra>();
            this._dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
            LoadExtra();
        }
        public void AddExtra(Extra extra)
        {
            extras.Add(extra);
            _dataWriter.AddExtra(extra.extraName);
        }

        public void RemoveExtra(Extra extra)
        {
            extras.Remove(extra);
            //remover.RemovePicture(pic.Id);
        }

        public void LoadExtra()
        {
            if (_dataAccess.GetAllExtras() != null)
            {
                foreach (ExtraDTO ex in _dataAccess.GetAllExtras())
                {
                    Extra extra = new Extra(ex.extraName, ex.Id);
                    extras.Add(extra);  
                }
            }
        }
    }
}
