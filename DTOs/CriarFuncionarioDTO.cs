namespace ProjetoDepartamento.Api.DTOs
{
    public class CriarFuncionarioDTO
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public decimal Salario { get; set; }

        public int DepartamentoId { get; set; }
    }
}
