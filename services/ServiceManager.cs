﻿using AutoMapper;
using entities.Dtos;
using entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using repositories.Contracts;
using services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthenticationService _authencationService;

        public ServiceManager(IBookService bookService,
            ICategoryService categoryService,
            IAuthenticationService authencationService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _authencationService = authencationService;
        }

        public IBookService BookService => _bookService;

        public IAuthenticationService AuthenticationService => _authencationService;

        public ICategoryService CategoryService => _categoryService;
    }

}
