using AutoMapper;
using Domain.Model;
using DTO.Model;
using InfraStructure;
using Service.Interface;
using Services.Interface;

namespace Service.Implementation
{
    public class DriverService : IDriverService
    {
        private IUnitOfWork UnitOfWork;
        private IMapper autoMapper;
        private ICommonService commonService;
        private IRepository<Driver> DriverRepo;

        public DriverService(IUnitOfWork UnitOfWork, IMapper autoMapper
            , ICommonService commonService)
        {
            this.UnitOfWork = UnitOfWork;
            this.autoMapper = autoMapper;
            this.commonService = commonService;
            this.DriverRepo = this.UnitOfWork.GetRepository<Driver>();
        }

        public async Task<ResultSaveDTO> DeleteDriver(long driverId)
        {
            try
            {
                Driver driver = await DriverRepo.GetByIdAsync(driverId);
                await DriverRepo.DeleteAsync(driver);
                await UnitOfWork.SaveChangesAsync();
                return commonService.Success();
            }
            catch
            {
                return commonService.Fail();
            }
        }

        public async Task<ResultListDTO<DriverDTO>> GetAllDrivers()
        {
            var (total, drivers) = await DriverRepo.GetByConditionAsync(x => true);
            List<DriverDTO> driverList = autoMapper.Map<List<DriverDTO>>(drivers);
            return commonService.ResultList<DriverDTO>(total, driverList);
        }

        public async Task<ResultSaveDTO<DriverDTO>> GetDriverById(long driverId)
        {
            try
            {
                var (total, driver) = await DriverRepo.GetByConditionAsync(d => d.Id == driverId);
                DriverDTO driverDTO = autoMapper.Map<DriverDTO>(driver.FirstOrDefault());
                return commonService.Success<DriverDTO>("Success", driverDTO);
            }
            catch (Exception ex)
            {
                return commonService.Fail<DriverDTO>("fail", null);
            }
        }

        public async Task<ResultSaveDTO> InsertDriver(DriverDTO driverDTO)
        {
            try
            {
                Driver driver = autoMapper.Map<Driver>(driverDTO);
                await DriverRepo.InsertAsync(driver);
                await UnitOfWork.SaveChangesAsync();
                return commonService.Success();
            }
            catch
            {
                return commonService.Fail();
            }
        }

        public async Task<ResultSaveDTO> UpdateDriver(DriverDTO driverDTO)
        {
            try
            {
                Driver driver = await DriverRepo.GetByIdAsync(driverDTO.Id);
                driver.FirstName = driverDTO.FirstName;
                driver.LastName = driverDTO.LastName;
                driver.PhoneNumber = driverDTO.PhoneNumber;
                driver.Email = driverDTO.Email;
                await DriverRepo.UpdateAsync(driver);
                await UnitOfWork.SaveChangesAsync();
                return commonService.Success();
            }
            catch
            {
                return commonService.Fail();
            }
        }
    }
}
