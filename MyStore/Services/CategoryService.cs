using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Services
{

    public interface ICategoryService
    {
        CategoryModel AddCategory(CategoryModel newCategory);
        bool Delete(int id);
        bool Exists(int id);
        IEnumerable<CategoryModel> GetAllCategorys();
        CategoryModel GetById(int id);
        void UpdateCategory(CategoryModel model);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public IEnumerable<CategoryModel> GetAllCategorys()
        {
            //take domain objects
            var allCategorys = categoryRepository.GetAll().ToList();//List<Category>
                                                                    //transform domain objects from List<Category> -> List<CategoryModel>
            var categoryModels = mapper.Map<IEnumerable<CategoryModel>>(allCategorys);

            return categoryModels;
            //for (int i = 0; i < allCategorys.Count(); i++)
            //{
            //    var categoryModel = new CategoryModel();
            //    categoryModel.Categoryid = allCategorys[i].Categoryid;
            //    categoryModel.Categoryid = allCategorys[i].Categoryid;
            //    categoryModel.Categoryname = allCategorys[i].Categoryname;
            //    categoryModel.Unitprice = allCategorys[i].Unitprice;
            //    categoryModel.Discontinued = allCategorys[i].Discontinued;
            //}

            //1 la 1
            //var source = new Category();
            //var destination = new CategoryModel();

            //destination.Categoryid = source.Categoryid;
            //destination.Discontinued = source.Discontinued;
            //destination.Categoryid = source.Categoryid;
            //destination.Categoryname = source.Categoryname;
            //destination.Supplierid = source.Supplierid;
            //destination.Unitprice = source.Unitprice;



        }

        public CategoryModel GetById(int id)
        {
            var categoryToGet = categoryRepository.GetById(id);
            return mapper.Map<CategoryModel>(categoryToGet);
        }
        public bool Exists(int id)
        {
            return categoryRepository.Exists(id);
        }
        public CategoryModel AddCategory(CategoryModel newCategory)
        {
            //Category addedCategory = mapper.Map<Category>(newCategory);
            //return categoryRepository.Add(addedCategory);

            Category categoryToAdd = mapper.Map<Category>(newCategory);
            categoryRepository.Add(categoryToAdd);
            //var addedCategory = categoryRepository.Add(categoryToAdd);
            //newCategory = mapper.Map<CategoryModel>(addedCategory);
            return newCategory;
        }
        public void UpdateCategory(CategoryModel model)
        {
            Category categoryToUpdate = mapper.Map<Category>(model);
            categoryRepository.Update(categoryToUpdate);
        }
        public bool Delete(int id)
        {
            Category itemToDelete = categoryRepository.GetById(id);
            return categoryRepository.Delete(itemToDelete);
        }
    }
}
