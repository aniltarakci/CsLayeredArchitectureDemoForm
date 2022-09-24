using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDal : ICategoryDal
    {
        public void Add(Category entity)
        {
            using (ExampledbContext exampledbContext = new ExampledbContext())
            {
                exampledbContext.Categories.Add(entity);
                exampledbContext.SaveChanges();
            }
        }

        public void Delete(Category entity)
        {
            using (ExampledbContext exampledbContext = new ExampledbContext())
            {
                exampledbContext.Categories.Remove(exampledbContext.Categories.SingleOrDefault(p => p.Id == entity.Id));
                exampledbContext.SaveChanges();
            }
        }

        public List<Category> GetAll()
        {
            using (ExampledbContext exampledbContext = new ExampledbContext())
            {
                return exampledbContext.Categories.ToList();
            }
        }

        public Category GetById(int id)
        {
            using (ExampledbContext exampledbContext = new ExampledbContext())
            {
                return exampledbContext.Categories.SingleOrDefault(p => p.Id == id);
            }
        }

        public void Update(Category entity)
        {
            using (ExampledbContext exampledbContext = new ExampledbContext())
            {
                var categoryToUpdate = exampledbContext.Categories.SingleOrDefault(p => p.Id == entity.Id);
                categoryToUpdate.CategoryName = entity.CategoryName;
                exampledbContext.SaveChanges();
            }
        }
    }
}
