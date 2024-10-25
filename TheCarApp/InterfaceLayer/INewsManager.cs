using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface INewsManager
    {
        List<CarNewsDTO> News { get; set; }
        Task<(bool Success, string ErrorMessage)> AddNewsAsync(CarNewsDTO carNewsDTO);
        Task<(bool Success, string ErrorMessage)> DeleteNewsAsync(CarNewsDTO carNewsDTO);
        Task<(bool Success, string ErrorMessage)> UpdateNewsAsync(CarNewsDTO carNewsDTO);
        Task<(bool Success, string ErrorMessage)> LoadNewsAsync();
        List<CarNewsDTO> GetNewsASC();
        List<CarNewsDTO> GetNewsDESC();
        CarNewsDTO GetNewsById(int id);
    }
}