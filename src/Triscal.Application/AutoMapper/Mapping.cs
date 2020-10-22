﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Triscal.Application.DTO;
using Triscal.Domain.Entities;

namespace Triscal.Application.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<Cliente, ClienteDTO>();

            CreateMap<EnderecoDTO, Endereco>();
            CreateMap<Endereco, EnderecoDTO>();
        }
    }
}