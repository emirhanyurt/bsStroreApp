﻿using AutoMapper;
using entites.Models;
using entities.Dtos;
using entities.Exceptions;
using entities.LinkModels;
using entities.RequestFeatures;
using repositories.Contracts;
using services.Contracts;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ICategoryService _categoryService;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly IBookLinks _bookLinks;
        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper, IBookLinks bookLinks, ICategoryService categoryService)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _bookLinks = bookLinks;
            _categoryService = categoryService;
        }
        public async Task<BookDto> CreateOneBookAsync(BookDtoForInsertion bookDto)
        {
            var category =  await _categoryService.GetOneCategoryByIdAsync(bookDto.CategoryId,false);

        

            var entity = _mapper.Map<Book>(bookDto);
            _manager.Book.CreateOneBook(entity);
          await  _manager.SaveAsync();
            return _mapper.Map<BookDto>(entity);
        }

        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
            var entity = await GetOneBookAndCheckExits(id, trackChanges);
            _manager.Book.DeleteOneBook(entity);
            await _manager.SaveAsync();
        }

        public async Task<(LinkResponse linkResponse, MetaData metaData)> GetAllBooksAsync(LinkParameters linkParameters, bool trackChanges)
        {
            if(!linkParameters.BookParameters.ValidPriceRange)
                throw new PriceOutofRangeBadRequestException();

            var booksWitgMetaData = await _manager.Book.GetAllBooksAsync(linkParameters.BookParameters, trackChanges);

           var booksDto =  _mapper.Map<IEnumerable<BookDto>>(booksWitgMetaData);
            var links = _bookLinks.TryGenerateLinks(booksDto, linkParameters.BookParameters.Fields, linkParameters.HttpContext);
            return (linkResponse: links, metaData: booksWitgMetaData.MetaData);
        }

        public Task<List<Book>> GetAllBooksAsync(bool trackChanges)
        {
            return _manager.Book.GetAllBooksAsync(trackChanges);
        }

        public Task<List<Book>> GetAllBooksAsyncWithDetails(bool trackChanges)
        {
           return _manager.Book.GetAllBooksAsyncWithDetails(trackChanges);
        }

        public async Task<BookDto> GetOneBookByIdAsync(int id, bool trackChanges)
        {
            var book = await GetOneBookAndCheckExits(id, trackChanges);

            return _mapper.Map<BookDto>(book); 

        }

        public async Task<(BookDtoForUpdate bookDtoForUpdate, Book book)> GetOneBookForPatchAsync(int id, bool trackChanges)
        {
            var entity = await GetOneBookAndCheckExits(id, trackChanges);

            var bookDtoForUpdate = _mapper.Map<BookDtoForUpdate>(entity);
            return (bookDtoForUpdate, entity);
        }

        public async Task SaveChangesForPatchAsync(BookDtoForUpdate bookDtoForUpdate, Book book)
        {
            _mapper.Map(bookDtoForUpdate, book);
           await _manager.SaveAsync();
        }

        public async Task UpdateOneBookAsync(int id, BookDtoForUpdate bookDto, bool trackChanges)
        {
            var entity = await _manager.Book.GetOneBookByIdAsync(id, trackChanges);
            if (entity is null)
            {
                string message = $"Book with id:{id} could not found";
                _logger.LogInfo(message);
                throw new Exception(message);
            }
             
            if (bookDto is null)
                throw new ArgumentNullException(nameof (bookDto));

            entity = _mapper.Map<Book>(bookDto);

            _manager.Book.Update(entity);
           await _manager.SaveAsync();

        }

        private async Task<Book> GetOneBookAndCheckExits(int id,bool trackChanges)
        {

            var entity = await _manager.Book.GetOneBookByIdAsync(id, trackChanges);

            if (entity is null)
                throw new BookNotFound(id);

            return entity;

        }
    }
}
