﻿using DataAccess.CD_Repositorios.ReposAplicacion;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Aplicacion
{
    public class CN_Pedidos
    {
        private static CN_Pedidos instancia;
        private RepoPedidos repositorio;
        private List<Pedido> pedidos;

        private CN_Pedidos()
        {
            repositorio = new RepoPedidos();
            pedidos = new List<Pedido>();
        }

        public static CN_Pedidos ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new CN_Pedidos();
            }
            return instancia;
        }

        public List<Pedido> ObtenerTodosLosPedidos()
        {
            try
            {
                if (pedidos.Count > 0)
                {
                    return pedidos;
                }
                else
                {
                    pedidos = repositorio.ObtenerTodosLosPedidos();
                    return pedidos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}