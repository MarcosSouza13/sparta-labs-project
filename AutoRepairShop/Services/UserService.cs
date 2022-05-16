using AutoRepairShop.Api.Authentication;
using AutoRepairShop.Api.Repositories.Interfaces;
using AutoRepairShop.Api.Services.Base;
using AutoRepairShop.Api.Services.Interfaces;
using AutoRepairShop.Arguments.Base;
using AutoRepairShop.Arguments.Login;
using AutoRepairShop.Arguments.User;
using AutoRepairShop.Domain.Entities.Models;

namespace AutoRepairShop.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRepairShopRepository _repairShopRepository;

        public UserService(IUserRepository userRepository, IRepairShopRepository repairShopRepository)
        {
            _userRepository = userRepository;
            _repairShopRepository = repairShopRepository;
        }

        public async Task<ResponseHttp<IResponse>> Add(User user)
        {
            var repairShop = await _repairShopRepository.Get(user.IdRepairShop);
            if (repairShop == null)
                return new ResponseHttp<IResponse>(412, errorMessage: $"Não é encontrar a oficina com o Id: {user.IdRepairShop}");
            
            user.Cnpj = repairShop.Cnpj;
            user.Salt = Auth.EncodeBaseToken(user.Password);

            await _userRepository.Add(user);

            return new ResponseHttp<IResponse>(201, new ViewUserResponse(user));
        }

        public Task<ResponseHttp<IResponse>> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseHttp<IResponse>> Edit(User obj)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseHttp<IResponse>> Get(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseHttp<IResponse>> Login(Login login)
        {
            var user = await GetByCnpj(login.Cnpj);
            if (user == null || user.Salt != Auth.EncodeBaseToken(login.Password))
                return new ResponseHttp<IResponse>(422, errorMessage: "Senha inválida");

            var loginResponse = new LoginResponse(login);

            var token = Auth.EncodeToken();
            loginResponse.Token = token;

            return new ResponseHttp<IResponse>(200, loginResponse);
        }
        private async Task<User> GetByCnpj(string cnpj)
        {
            var user = await _userRepository.GetByCnpj(cnpj);
            return user;
        }
    }
}
