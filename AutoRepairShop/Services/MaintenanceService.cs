using AutoRepairShop.Api.Repositories.Interfaces;
using AutoRepairShop.Api.Services.Base;
using AutoRepairShop.Api.Services.Interfaces;
using AutoRepairShop.Api.Validators.Base;
using AutoRepairShop.Api.Validators.Maintenance;
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
            var validator = new AddMaintenanceValidator();
            var validation = validator.Validate(maintenance);
            if (!validation.IsValid)
                return new ResponseHttp<IResponse>(400, errorsModel: VisualizationError.ToList(validation.Errors));

            if (maintenance.ScheduledAt.DayOfWeek == DayOfWeek.Saturday || maintenance.ScheduledAt.DayOfWeek == DayOfWeek.Sunday)
                return new ResponseHttp<IResponse>(412, errorMessage: "Não é possível agendar o serviço no fim de semana");

            var validationResponse = await ValidateWorkBalance(maintenance);
            if (validationResponse.StatusCode == 412)
                return validationResponse;

            await _maintenanceRepository.Add(maintenance);

            return new ResponseHttp<IResponse>(201, new ViewMaintenanceResponse(maintenance));
        }

        public async Task<ResponseHttp<IResponse>> Edit(Maintenance maintenanceEdited)
        {
            var validator = new EditMaintenanceValidator();
            var validation = validator.Validate(maintenanceEdited);
            if (!validation.IsValid)
                return new ResponseHttp<IResponse>(400, errorsModel: VisualizationError.ToList(validation.Errors));

            var maintenance = await GetById(maintenanceEdited.Id);
            if (maintenance == null)
                return new ResponseHttp<IResponse>(412, errorMessage: $"Não é possível editar o agendamento do serviço com o Id: {maintenanceEdited.Id}");


            var validationResponse = await ValidateWorkBalance(maintenance);
            if (validationResponse.StatusCode == 412)
                return validationResponse;

            maintenanceEdited.UpdatedAt = DateTime.Now;

            await _maintenanceRepository.Edit(maintenanceEdited);

            return new ResponseHttp<IResponse>(200, new ViewMaintenanceResponse(maintenanceEdited));
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

        public async Task<ResponseHttp<IEnumerable<IResponse>>> ListDaily()
        {
            var list = new List<ViewMaintenanceResponse>();
            var result = await _maintenanceRepository.ListDaily();

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

        private async Task<ResponseHttp<IResponse>> ValidateWorkBalance(Maintenance maintenance)
        {
            var workload = await _repairShopConfigurationRepository.GetByIdRepairShop(maintenance.IdRepairShop, maintenance.ScheduledAt);
            if (workload == null)
                return new ResponseHttp<IResponse>(412, errorMessage: $"Não possui carga de trabalho disponível para a empresa: {maintenance.IdRepairShop}, no dia: {maintenance.ScheduledAt.Date}");

            var dailyServices = await _maintenanceRepository.ListByDate(maintenance.ScheduledAt);
            if (dailyServices.Any())
            {
                var dailyWorkBalance = await _serviceRepository.Get(dailyServices.Select(a => (int)a.Type));

                if (dailyWorkBalance > workload.WorkBalance)
                    return new ResponseHttp<IResponse>(412, errorMessage: "Não é possível realizar o agendamento do serviço, pois ultrapassou a carga de trabalho máxima diária");
            }

            return new ResponseHttp<IResponse>(200);
        }
    }
}
