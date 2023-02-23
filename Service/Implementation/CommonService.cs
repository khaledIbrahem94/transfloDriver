using DTO.Model;
using Services.Interface;

namespace Services.Implementation
{
    public class CommonService : ICommonService
    {
        public ResultSaveDTO Fail(string Msg = "Fail")
        {
            return new ResultSaveDTO
            {
                Success = false,
                Message = Msg
            };
        }

        public ResultListDTO<T> ResultList<T>(int Total, List<T> List)
        {
            return new ResultListDTO<T>
            {
                List = List,
                ResultPaging = new ResultPagingDTO
                {
                    PageRows = List.Count,

                    TotalRows = Total,
                    NumberOfPAges = Total,
                }
            };
        }

        public ResultSaveDTO Success(string Msg = "Done")
        {
            return new ResultSaveDTO
            {
                Success = true,
                Message = Msg
            };
        }

        public ResultSaveDTO<T> Fail<T>(string Msg, T Entity)
        {
            return new ResultSaveDTO<T>
            {
                Success = false,
                Message = Msg,
                Model = Entity
            };
        }

        public ResultSaveDTO<T> Success<T>(string Msg, T Entity)
        {
            return new ResultSaveDTO<T>
            {
                Message = Msg,
                Success = true,
                Model = Entity
            };
        }
    }
}
