using Database;
using DTO;
using Entity_Layer;
using EntityLayout;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            LoadExtra();
        }
        public string AddExtra(Extra extra)
        {
            string Message = _dataWriter.AddExtra(extra.ExtraName);
            if (Message == "done")
            {

                extras.Add(extra);
                return "done";
            }
            else
            {
                return Message;
            }
        }

        public string RemoveExtra(Extra extra)
        {
            string Message = _dataRemover.RemoveExtra(extra.Id);
            if (Message == "done")
            {

                extras.Remove(extra);// Need to get extra Id from DB after added a new one
                return "done";
            }
            else
            {
                return Message;
            }
        }

        public string LoadExtra()
        {
            List<ExtraDTO> loadExtras;
            try
            {
                loadExtras = _dataAccess.GetAllExtras();
                if (loadExtras != null)
                {
                    foreach (ExtraDTO ex in loadExtras)
                    {
                        Extra extra = new Extra(ex.extraName, ex.Id);
                        extras.Add(extra);
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
