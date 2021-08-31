using MovieService.Core.Aspects;
using MovieService.Core.Models.Results;
using MovieService.DataAccess;
using MovieService.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace MovieService.Core.Business
{
    public class CategoryService : ICategoryService
    {
        [Logging]
        [RemoveCaching]
        public IResult Add(Category entity)
        {
            try
            {
                CategoryRepo.Insert(entity);
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        [Logging]
        [Caching]
        public IDataResult<Category> GetById(int Id)
        {
            try
            {
                var result = CategoryRepo.GetById(Id);
                return new SuccessDataResult<Category>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Category>(ex.Message);
            }
        }

        [Logging]
        [Caching]
        public IDataResult<List<Category>> List()
        {
            try
            {
                var result = CategoryRepo.List();
                return new SuccessDataResult<List<Category>>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Category>>(ex.Message);
            }
        }

        [Logging]
        [RemoveCaching]
        public IResult Update(Category entity)
        {
            try
            {
                CategoryRepo.Update(entity);
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        [Logging]
        [RemoveCaching]
        public IResult Delete(Category entity)
        {
            try
            {
                CategoryRepo.Delete(entity);
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
        public interface ICategoryService
        {
        IResult Add(Category entity);
        IResult Update(Category entity);
        IResult Delete(Category entity);
        IDataResult<List<Category>> List();
        IDataResult<Category> GetById(int Id);
    }
}
