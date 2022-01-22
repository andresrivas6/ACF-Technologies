using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACF.Infrastructure.Interfaces;
using ACF.Models;
using ACF.DTO;
using AutoMapper;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ACF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _cliente;
        private readonly IMapper _mapper;

        public ClienteController(ICliente cliente, IMapper mapper)
        {
            _cliente = cliente;
            _mapper = mapper;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            var clienteModel = _cliente.GetClientes();
            if (clienteModel != null)
            {
                return Ok(_mapper.Map<IEnumerable<ClienteReadDto>>(clienteModel));
            }
            return NotFound(); ;
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}", Name = "GetClienteById")]
        public async Task<ActionResult> GetClienteById(int id)
        {
            var clientItem = _cliente.GetClienteById(id);
            if (clientItem != null)
            {
                return Ok(clientItem);//_mapper.Map<ClienteReadDto>(clientItem));
            }
            return NotFound();
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult<ClienteReadDto>> Post(ClienteCreateDto clienteCreateDto)//[FromBody] string value)
        {
            var clientModel = _mapper.Map<Cliente>(clienteCreateDto);
            int idCreado = 0;
            idCreado = await _cliente.CreateCliente(clientModel);

            var ClienteReadDto = _mapper.Map<ClienteReadDto>(clientModel);

            return CreatedAtRoute(nameof(GetClienteById), new { Id = ClienteReadDto.Id }, ClienteReadDto);
            //return Ok(orderDto);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ClienteReadDto clienteReadDto)//[FromBody] string value)
        {
            var clientModel = await _cliente.GetClienteById(id);
            if (clientModel == null)
            {
                return NotFound();
            }

            _mapper.Map(clienteReadDto, clientModel);


            await _cliente.UpdateCliente(clientModel);


            return NoContent();
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var clientModel = await _cliente.GetClienteById(id);
            if (clientModel == null)
            {
                return NotFound();
            }

            //_mapper.Map(ClienteReadDto, clientModel);


            await _cliente.DeleteCliente(clientModel);


            return NoContent();
        }
    }
}
