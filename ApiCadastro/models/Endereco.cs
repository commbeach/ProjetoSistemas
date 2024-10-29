namespace TodoApi.models{
    public class Endereco
    {
        public int Id { get; set; }
        public string? Loug { get; set; }
        public int Numero { get; set; }
        public string? Estado { get; set; }
        public string? Cidade { get; set; }
        public string? Bairro { get; set; }
        public int Id_Pessoa { get; set; }
        public bool IsComplete { get; set; }
    }
}