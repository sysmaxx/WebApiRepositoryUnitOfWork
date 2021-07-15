using DemoWebApp.Models;
using DemoWebApp.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApp.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(long id);
        Task<Author> AddAuthorAsync(CreateAuthorDto authorDto);
    }
}
