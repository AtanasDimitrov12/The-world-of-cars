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
        private readonly IDataWriter _dataWriter;
        private readonly IDataRemover _dataRemover;

        public ExtraManager(IDataWriter dataWriter, IDataRemover dataRemover)
        {
            extras = new List<Extra>();
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
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

    }
}
