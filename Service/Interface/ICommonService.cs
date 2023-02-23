using DTO.Model;

namespace Services.Interface
{
    public interface ICommonService
    {
        ResultSaveDTO Success(string Msg = "Done");

        ResultSaveDTO<T> Success<T>(string Msg, T Entity);

        ResultSaveDTO<T> Fail<T>(string Msg, T Entity);

        ResultSaveDTO Fail(string Msg = "Fail");

        ResultListDTO<T> ResultList<T>(int Total, List<T> List);
    }
}
