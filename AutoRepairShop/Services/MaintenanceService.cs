using AutoRepairShop.Api.Repositories.Interfaces;
using AutoRepairShop.Api.Services.Base;
using AutoRepairShop.Api.Services.Interfaces;
using AutoRepairShop.Arguments.Base;
using AutoRepairShop.Arguments.Maintenance;
using AutoRepairShop.Domain.Entities.Models;

namespace AutoRepairShop.Api.Services
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly IMaintenanceRepository _maintenanceRepository;
        private readonly IRepairShopConfigurationRepository _repairShopConfigurationRepository;
        private readonly IServiceRepository _serviceRepository;

        public MaintenanceService(IMaintenanceRepository maintenanceRepository, IRepairShopConfigurationRepository repairShopConfigurationRepository, IServiceRepository serviceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
            _repairShopConfigurationRepository = repairShopConfigurationRepository;
            _serviceRepository = serviceRepository;
        }

        public async Task<ResponseHttp<IResponse>> Add(Maintenance maintenance)
        {
            if (maintenance.ScheduledAt.DayOfWeek == DayOfWeek.Saturday || maintenance.ScheduledAt.DayOfWeek == DayOfWeek.Sunday)
                return new ResponseHttp<IResponse>(412, errorMessage: "Não é possível agendar o serviço no fim de semana");

            var workload = await _repairShopConfigurationRepository.GetByIdRepairShop(maintenance.IdRepairShop, maintenance.ScheduledAt);
            if (workload == null)
                return new ResponseHttp<IResponse>(412, errorMessage: $"Não possui carga de trabalho disponível para a empresa: {maintenance.IdRepairShop}, no dia: {maintenance.ScheduledAt.Date}");

            var unitOfWork = await _serviceRepository.Get((int)maintenance.Type);

            if (workload.WorkBalance > unitOfWork)
                return new ResponseHttp<IResponse>(412, errorMessage: "Não é possível realizar o agendamento do serviço, pois ultrapassou a carga de trabalho máxima diária");

            await _maintenanceRepository.Add(maintenance);

            return new ResponseHttp<IResponse>(201, new ViewMaintenanceResponse(maintenance));
        }

        public async Task<ResponseHttp<IResponse>> Edit(Maintenance maintenanceEdited)
        {
            var maintenance = await GetById(maintenanceEdited.Id);

            if (maintenance == null)
                return new ResponseHttp<IResponse>(412, errorMessage: $"Não é possível editar o agendamento do serviço com o Id: {maintenanceEdited.Id}");

            await _maintenanceRepository.Edit(maintenance);

            return new ResponseHttp<IResponse>(200, new ViewMaintenanceResponse(maintenance));
        }

        public async Task<ResponseHttp<IResponse>> Get(long id)
        {
            var maintenance = await GetById(id);
            if (maintenance == null)
                return new ResponseHttp<IResponse>(412, errorMessage: $"Não é possível localizar o agendamento do serviço com o Id: {id}");

            return new ResponseHttp<IResponse>(200, new ViewMaintenanceResponse(maintenance));
        }

        public async Task<ResponseHttp<IResponse>> Delete(long id)
        {
            var maintenance = await GetById(id);

            if (maintenance == null)
                return new ResponseHttp<IResponse>(412, errorMessage: $"Não é possível deletar o agendamento do serviço com o Id: {id}");

            await _maintenanceRepository.Delete(maintenance);

            return new ResponseHttp<IResponse>(204);
        }

        public async Task<ResponseHttp<IEnumerable<IResponse>>> List()
        {
            var list = new List<ViewMaintenanceResponse>();
            var result = await _maintenanceRepository.List();

            foreach (var item in result)
            {
                list.Add(new ViewMaintenanceResponse(item));
            }

            return new ResponseHttp<IEnumerable<IResponse>>(200, list);
        }

        public async Task<ResponseHttp<IEnumerable<IResponse>>> ListWithDates(string initalDate, string finalDate)
        {
            var list = new List<ViewMaintenanceResponse>();
            var result = await _maintenanceRepository.ListWithDates(initalDate, finalDate);

            foreach (var item in result)
            {
                list.Add(new ViewMaintenanceResponse(item));
            }

            return new ResponseHttp<IEnumerable<IResponse>>(200, list);
        }

        private async Task<Maintenance> GetById(long id)
        {
            var maintenance = await _maintenanceRepository.Get(id);
            return maintenance;
        }

    }
}
