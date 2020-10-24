using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Triscal.Application.DTO;
using Triscal.Application.Interfaces;
using Triscal.Domain.Entities;

namespace Triscal.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IMapper mapper,
            IClienteAppService clienteAppService)
        {
            _mapper = mapper;
            _clienteAppService = clienteAppService;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<ActionResult<ClienteDTO>> Get()
        {
            var clientes = await _clienteAppService.GetAllAsync();

            return Ok(_mapper.Map<List<ClienteDTO>>(clientes));
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> Get(Guid id)
        {
            var cliente = await _clienteAppService.GetByIdAsync(id);

            return Ok(_mapper.Map<ClienteDTO>(cliente));
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> Post(ClienteCreateDTO clienteCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(clienteCreateDTO);
            }

            var cliente = await _clienteAppService.InsertAsync(_mapper.Map<Cliente>(clienteCreateDTO));

            if (cliente == null)
            {
                return BadRequest("O CPF já existe!");
            }

            return Ok(_mapper.Map<ClienteDTO>(cliente));
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteDTO>> Put(Guid id, ClienteUpdateDTO clienteUpdateDTO)
        {
            if (id != clienteUpdateDTO.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(clienteUpdateDTO);
            }

            var cliente = await _clienteAppService.UpdateAsync(_mapper.Map<Cliente>(clienteUpdateDTO));

            if (cliente == null)
            {
                return BadRequest("O CPF já existe!");
            }

            return Ok(_mapper.Map<ClienteDTO>(cliente));
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteDTO>> Delete(Guid id)
        {
            var cliente = await _clienteAppService.DeleteAsync(await _clienteAppService.GetByIdAsync(id));

            return Ok(_mapper.Map<ClienteDTO>(cliente));
        }
    }
}
