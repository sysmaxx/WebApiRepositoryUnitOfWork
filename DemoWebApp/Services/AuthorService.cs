using DemoWebApp.Models;
using DemoWebApp.Models.Dto;
using DemoWebApp.Persistence;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoWebApp.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Author>> GetAllAsync() => await _unitOfWork.Authors.GetAllAsync().ConfigureAwait(false);
        public async Task<Author> GetByIdAsync(long id) => await _unitOfWork.Authors.GetAsync(id).ConfigureAwait(false);

        public async Task<Author> AddAuthorAsync(CreateAuthorDto authorDto)
        {
            var author = new Author { Name = authorDto.Name };
            await _unitOfWork.Authors.AddAsync(author).ConfigureAwait(false);
            await _unitOfWork.CompleteAsync().ConfigureAwait(false);
            return author;
        }
    }
}
