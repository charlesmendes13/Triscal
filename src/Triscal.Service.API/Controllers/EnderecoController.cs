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
    public class EnderecoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEnderecoAppService _enderecoAppService;

        public EnderecoController(IMapper mapper, 
            IEnderecoAppService enderecoAppService)
        {
            _mapper = mapper;
            _enderecoAppService = enderecoAppService;
        }

        // GET: api/<EnderecoController>
        [HttpGet]
        public async Task<ActionResult<EnderecoDTO>> Get()
        {
            var enderecos = await _enderecoAppService.GetAllAsync();

            return Ok(_mapper.Map<List<EnderecoDTO>>(enderecos));
        }

        // GET api/<EnderecoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoDTO>> Get(Guid id)
        {
            var endereco = await _enderecoAppService.GetByIdAsync(id);

            return Ok(_mapper.Map<EnderecoDTO>(endereco));
        }

        // POST api/<EnderecoController>
        [HttpPost]
        public async Task<ActionResult<EnderecoDTO>> Post(EnderecoDTO enderecoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(enderecoDTO);
            }

            var endereco = await _enderecoAppService.InsertAsync(_mapper.Map<Endereco>(enderecoDTO));

            if (endereco == null)
            {
                return BadRequest("O Cliente já existe!");
            }

            return Ok(_mapper.Map<EnderecoDTO>(endereco));
        }

        // PUT api/<EnderecoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<EnderecoDTO>> Put(Guid id, EnderecoDTO enderecoDTO)
        {
            if (id != enderecoDTO.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(enderecoDTO);
            }

            var endereco = await _enderecoAppService.UpdateAsync(_mapper.Map<Endereco>(enderecoDTO));

            if (endereco == null)
            {
                return BadRequest("O Cliente já existe!");
            }

            return Ok(_mapper.Map<EnderecoDTO>(endereco));
        }

        // DELETE api/<EnderecoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EnderecoDTO>> Delete(Guid id)
        {
            var endereco = await _enderecoAppService.DeleteAsync(await _enderecoAppService.GetByIdAsync(id));

            return Ok(_mapper.Map<EnderecoDTO>(endereco));
        }
    }
}
