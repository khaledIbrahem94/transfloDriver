using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class ResultPagingDTO
    {
        public int Pagelength { get; set; }

        //count of only coming records
        public int PageRows { get; set; }

        // count of all records
        public int TotalRows { get; set; }

        public int NumberOfPAges { get; set; }
    }

    public class ResultListDTO<T>
    {
        public List<T> List { get; set; }
        public ResultPagingDTO ResultPaging { get; set; }
    }
}
