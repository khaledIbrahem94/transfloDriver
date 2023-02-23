using DTO.Model;

namespace Service.Interface
{
    public interface IDriverService
    {
        Task<ResultListDTO<DriverDTO>> GetAllDrivers();

        Task<ResultSaveDTO<DriverDTO>> GetDriverById(long driverId);

        Task<ResultSaveDTO> InsertDriver(DriverDTO driver);

        Task<ResultSaveDTO> UpdateDriver(DriverDTO driver);

        Task<ResultSaveDTO> DeleteDriver(long driverId);
    }
}
