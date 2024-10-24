using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface ICommentsManager
    {
        Task<(bool Success, string ErrorMessage)> AddCommentAsync(CarNewsDTO newsDTO, CommentDTO commentDTO);

        Task<(bool Success, string ErrorMessage)> RemoveCommentAsync(CarNewsDTO newsDTO, CommentDTO commentDTO);
    }
}
