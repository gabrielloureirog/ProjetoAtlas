namespace ProjetoAlans_API.models
{
    public class CustoMensal
    {

        public CustoMensal()
        {
            
        }
        public CustoMensal(int id, string calculo)
        {
            this.id = id;
            this.calculo = calculo;

        }
        public int id { get; set; }

        public string calculo { get; set; }
    }
}