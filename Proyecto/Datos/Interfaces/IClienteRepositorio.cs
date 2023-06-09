﻿using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IClienteRepositorio
    {
        //declarar metodos
        Task<Cliente> GetPorCodigoAsync(string identidad);
        Task<bool> NuevoAsync(Cliente cliente);
        Task<bool> ActualizarAsync(Cliente cliente);
        //Duda string Identidad?
        Task<bool> EliminarAsync(string codigo);
        Task<IEnumerable<Cliente>> GetListaAsync();
    }
}
