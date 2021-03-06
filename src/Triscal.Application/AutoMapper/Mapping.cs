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
            CreateMap<Cliente, ClienteDTO>()
                .ForMember(dto => dto.DataNascimento, opt => opt.MapFrom(entity => entity.DataNascimento.ToString("dd/MM/yyyy")));

            CreateMap<ClienteCreateDTO, Cliente>();
            CreateMap<Cliente, ClienteCreateDTO>();

            CreateMap<ClienteUpdateDTO, Cliente>();
            CreateMap<Cliente, ClienteUpdateDTO>();

            CreateMap<ClienteEnderecoCreateDTO, Endereco>();
            CreateMap<Endereco, ClienteEnderecoCreateDTO>();

            CreateMap<EnderecoDTO, Endereco>();
            CreateMap<Endereco, EnderecoDTO>();

            CreateMap<EnderecoCreateDTO, Endereco>();
            CreateMap<Endereco, EnderecoCreateDTO>();

            CreateMap<EnderecoUpdateDTO, Endereco>();
            CreateMap<Endereco, EnderecoUpdateDTO>();
        }
    }
}
