using AutoMapper;
using Sigma.Application.Dtos;
using Sigma.Application.Interfaces;
using Sigma.Domain.Entities;
using Sigma.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<List<UsuarioDTo>> BuscarTodos()
        {
            var usuarios = await _usuarioRepository.BuscarTodos();
            return _mapper.Map<List<UsuarioDTo>>(usuarios);
        }

        public Task<bool> Inserir(UsuarioDTo usuarioDto)
        {
            return _usuarioRepository.Inserir(_mapper.Map<Usuario>(usuarioDto));
        }
    }
}
