﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Interfaces
{
    public interface IApp<TViewModel, TModel> 
        where TViewModel : class 
        where TModel : class
    {
        Task<IEnumerable<TViewModel>> WhereAsync(Expression<Func<TModel, bool>> predicate);
        Task<IEnumerable<TViewModel>> FindAllAsync();
        Task<TViewModel> CreateAsync(TViewModel viewModel);
        Task<TViewModel> FindByIdAsync(int id);
        Task<TViewModel> EditAsync(TViewModel viewModel);
    }

    public interface IApp<TModel> 
        where TModel : class
    {
        Task<IEnumerable<TModel>> WhereAsync(Expression<Func<TModel, bool>> predicate);
        Task<IEnumerable<TModel>> FindAllAsync();
        Task<TModel> FindByIdAsync(int id);
        Task<TModel> EditAsync(TModel viewModel);

    }
}
