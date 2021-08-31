using MovieService.Core.Aspects;
using MovieService.Core.Models.Results;
using MovieService.DataAccess;
using MovieService.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace MovieService.Core.Business
{
    public class FilmService : IFilmService
    {
        [Logging]
        [RemoveCaching]
        public IResult Add(Movie entity)
        {
            try
            {
                MovieRepo.Insert(entity);
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        [Logging]
        [Caching]
        public IDataResult<Movie> GetById(int Id)
        {
            try
            {
                var result = MovieRepo.GetById(Id);
                return new SuccessDataResult<Movie>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Movie>(ex.Message);
            }
        }

        [Logging]
        [Caching]
        public IDataResult<Movie> GetByCategoryId(int CategoryId)
        {
            try
            {
                var result = MovieRepo.GetById(CategoryId);
                return new SuccessDataResult<Movie>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Movie>(ex.Message);
            }
        }

        [Logging]
        [Caching]
        public IDataResult<List<Movie>> List()
        {
            try
            {
                var result = MovieRepo.List();
                return new SuccessDataResult<List<Movie>>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Movie>>(ex.Message);
            }
        }

        [Logging]
        [RemoveCaching]
        public IResult Update(Movie entity)
        {
            try
            {
                MovieRepo.Update(entity);
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        [Logging]
        [RemoveCaching]
        public IResult Delete(Movie entity)
        {
            try
            {
                MovieRepo.Delete(entity);
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
    public interface IFilmService
    {
        IResult Add(Movie entity);
        IResult Update(Movie entity);
        IResult Delete(Movie entity);
        IDataResult<List<Movie>> List();
        IDataResult<Movie> GetById(int Id);
        IDataResult<Movie> GetByCategoryId(int CategoryId);
    }
}
