﻿namespace entities.Exceptions
{
    public sealed class CategoryNotFoundException : NotFoundException
    {

        public CategoryNotFoundException(int id) : base($"The book with id : {id} could not found")
        {

        }
    }
}
