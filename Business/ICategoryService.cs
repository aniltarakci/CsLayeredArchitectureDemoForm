using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
        public void Add(Category category);
        public void Update(Category category);
        public void Delete(Category category);
    }
}
