using MovieService.DataAccess.Models;
using System.Collections.Generic;

namespace MovieService.DataAccess
{
    public static class CategoryRepo
    {
        private static List<Category> _categories { get; set; }
        private static List<Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new List<Category>();
                    for (int i = 1; i <= 100; i++)
                    {
                        _categories.Add(new Category
                        {
                            Id = i,
                            Name = $"Category {i}",
                        });
                    }
                }
                return _categories;
            }
            set { Categories = value; }
        }
        public static void Insert(Category entity)
        {
            Categories.Add(entity);
        }
        public static void Update(Category entity)
        {
            Delete(entity);
            Insert(entity);
        }
        public static void Delete(Category entity)
        {
            Categories.RemoveAll(x => x.Id == entity.Id);
        }
        public static List<Category> List()
        {
            return Categories;
        }
        public static Category GetById(int Id)
        {
            return Categories.Find(x => x.Id == Id);
        }
    }
}
