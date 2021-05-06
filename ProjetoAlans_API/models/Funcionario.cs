namespace ProjetoAlans_API.models
{
    public class Funcionario
    {

        public Funcionario() 
        {
            
        }

        public Funcionario(int id, string nome, string escala, double custoDia)
        {
            this.id = id;
            this.nome = nome;
            this.escala = escala;
            this.custoDia = custoDia;

        }
        public int id { get; set; }
        public string nome { get; set; }
        public string escala { get; set; }
        public double custoDia { get; set; }
    }
}