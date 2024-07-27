using entites.Models;
using entities.Dtos;
using entities.LinkModels;
using entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Contracts
{
    public interface IBookService
    {
       
        
            Task <(LinkResponse  linkResponse, MetaData metaData)> GetAllBooksAsync(LinkParameters linkParameters, bool trackChanges);
            Task<BookDto> GetOneBookByIdAsync(int id, bool trackChanges);
            Task<BookDto> CreateOneBookAsync(BookDtoForInsertion book);
            Task UpdateOneBookAsync(int id, BookDtoForUpdate Dtobook,bool trackChanges);
            Task DeleteOneBookAsync(int id, bool trackChanges);
            Task <(BookDtoForUpdate bookDtoForUpdate, Book book)> GetOneBookForPatchAsync(int id, bool trackChanges);

            Task SaveChangesForPatchAsync(BookDtoForUpdate bookDtoForUpdate, Book book);
            Task<List<Book>> GetAllBooksAsync(bool trackChanges);
            Task<List<Book>> GetAllBooksAsyncWithDetails(bool trackChanges);

    }
}
