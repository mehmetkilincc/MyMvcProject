using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMvcProject.Entity.Concrete;

namespace MyMvcProject.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
