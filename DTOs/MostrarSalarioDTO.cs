namespace ProjetoDepartamento.Api.DTOs
{
    public class MostrarSalarioDTO
    {
        public string Nome { get; set; }
        
        public decimal Salario { get; set; }

        public string NomeDepart {  get; set; }

        public int DepartamentoId { get; set; }
    }
}
