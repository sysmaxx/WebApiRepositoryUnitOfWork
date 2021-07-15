using DemoWebApp.Models.Dto;
using DemoWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApp.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("/")]
        public async Task<IActionResult> GetAllAuthorsAsync() => Ok(await _authorService.GetAllAsync().ConfigureAwait(false));

        [HttpGet("/{id:int}")]
        public async Task<IActionResult> GetAuthorsByIdAsync(long id) => Ok(await _authorService.GetByIdAsync(id).ConfigureAwait(false));

        [HttpPost("/")]
        public async Task<IActionResult> AddAuthorAsync(CreateAuthorDto dto) => Ok(await _authorService.AddAuthorAsync(dto).ConfigureAwait(false));

    }
}
