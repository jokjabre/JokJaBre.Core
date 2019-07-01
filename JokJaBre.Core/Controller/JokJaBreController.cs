﻿using JokJaBre.Core.Objects;
using JokJaBre.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JokJaBre.Core.Controller
{
    public abstract class JokJaBreController<TModel> : ControllerBase //, IJokJaBreController<TModel>
        where TModel : IJokJaBreModel
    {
        protected IJokJaBreService<TModel> m_service;
        public JokJaBreController(IJokJaBreService<TModel> service)
        {
            m_service = service;
        }

        //[HttpPost]
        //public abstract IActionResult Create(IJokJaBreRequest request);

        //[HttpGet]
        //public abstract IActionResult GetAll();

        //[HttpGet("{id}")]
        //public abstract IActionResult GetById(long id);
    }
}
