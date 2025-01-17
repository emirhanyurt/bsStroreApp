﻿using entites.Models;
using entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using repositories.Contracts;
using repositories.EfCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repositories.EfCore
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneBook(Book book) => Create(book);


        public void DeleteOneBook(Book book) => Delete(book);


        public async Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParameters,bool trackChanges)
        {
          var books =  await FindAll(trackChanges)
                .FilterBooks(bookParameters.MinPrice ,bookParameters.MaxPrice).
                Search(bookParameters.SearchTerm)
                .Sort(bookParameters.OrderBy).ToListAsync();

            return PagedList<Book>
                .ToPagedList(books, bookParameters.PageNumber,bookParameters.PageSize);
        }

        public async Task<List<Book>> GetAllBooksAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(b => b.Id).ToListAsync();
        }

        public async Task<List<Book>> GetAllBooksAsyncWithDetails(bool trackChanges)
        {
            return await _context.Books.Include(b => b.Category).OrderBy(b => b.Id).ToListAsync();
        }

        public async Task<Book> GetOneBookByIdAsync(int id, bool trackChanges)
        => await FindByCondition(b => b.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateOneBook(Book book) => Update(book);
        
    }
}
