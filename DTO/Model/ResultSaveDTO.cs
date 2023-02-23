using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class ResultSaveDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class ResultSaveDTO<TModel>
    {
        public TModel Model { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
