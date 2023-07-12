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
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public List<Admin> GetAll()
        {
            return _adminRepository.GetAll(); 
        }
        public Admin GetById(int id)
        {
            return _adminRepository.Get(admin=>admin.Id == id);
        }

        public void Add(Admin admin)
        {
            _adminRepository.Add(admin);
        }

        public void Delete(Admin admin)
        {
            _adminRepository.Update(admin);
        }

        public void Update(Admin admin)
        {
            _adminRepository.Update(admin);
        }
    }
}
