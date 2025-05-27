using AutoMapper;
using Sigma.Application.Dtos;
using Sigma.Application.Interfaces;
using Sigma.Domain.Entities;
using Sigma.Domain.Enums;
using Sigma.Domain.Interfaces.Repositories;
using Sigma.Infra.Data.Repositories;
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

        private async Task<Usuario> BuscarPorIdOuRetornaErro(int id)
        {
            var usuario = await _usuarioRepository.BuscarPorIdAsync(id);

            if (usuario == null)
            {
                throw new KeyNotFoundException($"Usuario com ID {id} não encontrado.");
            }

            return usuario;
        }

        private Usuario AtualizarProjetoComDTo(Usuario usuario, UsuarioDTo model)
        {
            usuario.Name = model.Name;
            usuario.Email = model.Email;
            usuario.Senha = model.Senha;
            usuario.Cargo = model.Cargo.Equals("Administrador", StringComparison.OrdinalIgnoreCase) ? Cargo.Administrador : Cargo.Cliente;
            return usuario;
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
        public async Task<bool> EditarProjeto(UsuarioDTo model, int id)
        {
            var usuario = await BuscarPorIdOuRetornaErro(id);
            AtualizarProjetoComDTo(usuario, model);
            return await _usuarioRepository.EditarUsuarioAsync(usuario);
        }
        public async Task<bool> DeletarUsuario(int id)
        {
            var usuario = await BuscarPorIdOuRetornaErro(id);
            return await _usuarioRepository.DeletarUsuarioAsync(usuario);
        }
    }
}
