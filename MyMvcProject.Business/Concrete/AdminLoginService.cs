using MyMvcProject.Business.Abstract;
using MyMvcProject.DataAccess.Abstract;
using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.Business.Concrete
{
    public class AdminLoginService : IAdminLoginService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminLoginService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public Admin ValidateAdmin(string username, string password)
        {
            return _adminRepository.Get(p => p.UserName == username && p.Password == password);
        }
    }
}
