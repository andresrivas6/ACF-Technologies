using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ACF.Models;
using ACF.DTO;
namespace ACF.Profiles
{
    public class PCliente : Profile
    {
        public PCliente()
        {
            CreateMap<Cliente, ClienteCreateDto>();
            CreateMap<Cliente, ClienteReadDto>();
            CreateMap<ClienteCreateDto, Cliente>();
            CreateMap<ClienteReadDto, Cliente>();
        }
    }
}
