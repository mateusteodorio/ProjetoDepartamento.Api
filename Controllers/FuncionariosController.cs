using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoDepartamento.Api.Data;
using ProjetoDepartamento.Api.DTOs;
using ProjetoDepartamento.Api.Models;

namespace ProjetoDepartamento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FuncionariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MostrarFuncionarioDTO>>> GetFuncionarios() 
        {

            return await _context.Funcionarios.Include(f => f.Departamento).Select(f => new MostrarFuncionarioDTO { NomeFunc = f.Nome, NomeDep = f.Departamento.Nome }).ToListAsync();
        }

        [HttpGet("info")]
        public async Task<ActionResult<IEnumerable<MostrarSalarioDTO>>> GetSalarios()
        {

            return await _context.Funcionarios.Include(f => f.Departamento).Select(f => new MostrarSalarioDTO { Nome = f.Nome, Salario = f.Salario, NomeDepart = f.Departamento.Nome, DepartamentoId = f.DepartamentoId }).ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CriarFuncionario(CriarFuncionarioDTO funcionarioDto)
        {
            var novoFuncionario = new Funcionario
            {
                Nome = funcionarioDto.Nome,
                CPF = funcionarioDto.CPF,
                Salario = funcionarioDto.Salario,
                DepartamentoId = funcionarioDto.DepartamentoId
            };
            _context.Funcionarios.Add(novoFuncionario);
            await _context.SaveChangesAsync();
            return Ok("Funcionario sequestrado com sucesso");
        }
    
}
}
