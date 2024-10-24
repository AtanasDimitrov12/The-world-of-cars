using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IExtraManager
    {
        Task<(bool Success, string ErrorMessage)> AddExtraAsync(ExtraDTO extraDTO);
        Task<(bool Success, string ErrorMessage)> RemoveExtraAsync(ExtraDTO extraDTO);
        Task<int> GetExtraIdAsync(string extraName);
        Task<(bool Success, string ErrorMessage)> LoadExtraAsync();
        List<ExtraDTO> Extras { get; set; }
    }

}
