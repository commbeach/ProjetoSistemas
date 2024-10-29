namespace TodoApi.models{
    public class Pessoa
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Idade { get; set; }
        public bool IsComplete { get; set; }
    }
}