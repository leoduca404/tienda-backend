﻿using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Querys
{
    public class ClienteQuery : IClienteQuery
    {
        private readonly TiendaContext _context;

        public ClienteQuery(TiendaContext context)
        {
            _context = context;
        }

        public Cliente GetClienteById(int ClienteId)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> GetClientes()
        {
            throw new NotImplementedException();
        }
    }
}