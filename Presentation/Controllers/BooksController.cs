using entites.Models;
using entities.Dtos;
using entities.Exceptions;
using entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [ApiVersion("1.0")]
    [ResponseCache(CacheProfileName ="5mins")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/{v:apiversion}/books")]
    public class BooksController : ControllerBase
    {

        private readonly IServiceManager _manager;
        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpHead]
        [HttpGet(Name = "GetAllBooksAsync")]
        [ResponseCache(Duration = 60)]
        [ServiceFilter(typeof (ValidateMediaTypeAttribute))]
        [Authorize]
        public async Task<IActionResult> GetAllBooksAsync([FromQuery] BookParameters bookParameters )
        {
            var linkParameters = new LinkParameters()
            {
              
                 BookParameters = bookParameters,
                 HttpContext = HttpContext


            };
                var result = await _manager.BookService.GetAllBooksAsync(linkParameters, false);

            Response.Headers.Add("X-Pagination",
                    JsonSerializer.Serialize(result.metaData));

            return result.linkResponse.HasLinks ?
            Ok(result.linkResponse.LinkedEntities) :
            Ok(result.linkResponse.ShapedEntities);
        }
        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetSelectedBooksAsync(int id)
        {

                var book = await _manager.BookService.GetOneBookByIdAsync(id, false);

                if (book is null)
                     throw new BookNotFound(id);
                return Ok(book);
          


        }
        [HttpGet("details")]
        [Authorize]
        public async Task<IActionResult>  GetAllBooksAsyncWithDetails ()
        {

            var book = await _manager.BookService.GetAllBooksAsyncWithDetails(false);

  
            return Ok(book);



        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost(Name = "CreateOneBookAsync")]
        [Authorize(Roles = "Editor, Admin")]
        public async Task<IActionResult> CreateOneBookAsync(BookDtoForInsertion bookDto)
        {
           
                if (bookDto is null)
                    return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
           var book = await _manager.BookService.CreateOneBookAsync(bookDto);

                return StatusCode(201, book);

        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Editor, Admin")]
        public async  Task<IActionResult> UpdateSelectedBookAsync([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
        {
            


                if (id != bookDto.Id)
                    return BadRequest();

               

           await _manager.BookService.UpdateOneBookAsync(id, bookDto, false);
                    return Ok(bookDto);


        }


        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSelectedBookAsync([FromRoute(Name = "id")] int id)
        {
            
              await  _manager.BookService.DeleteOneBookAsync(id, false);
                return NoContent();
           

        }
        [HttpPatch("{id:int}")]
        [Authorize(Roles = "Editor, Admin")]
        public async Task<IActionResult> PartiallyUpdateSelectedBookAsync([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<BookDtoForUpdate> bookPacth)
        {

            if (bookPacth is null)
                return BadRequest();


                var result = await _manager.BookService.GetOneBookForPatchAsync(id, false);
               


            bookPacth.ApplyTo(result.bookDtoForUpdate, ModelState);

            TryValidateModel(result.bookDtoForUpdate);
            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);


          await  _manager.BookService.SaveChangesForPatchAsync(result.bookDtoForUpdate, result.book);
                return NoContent();
           

        }

        [HttpOptions]
        [Authorize]
        public IActionResult GetBooksOptions()
        {
            Response.Headers.Add("Allow", "GET, PUT, POST, PACTH, DELETE ,HEAD, OPTIONS");
            return Ok();
        }
    
    }
}
