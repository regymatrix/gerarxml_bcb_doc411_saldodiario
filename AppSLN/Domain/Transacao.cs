namespace Domain
{
    public class Transacao
    {
        public int ID { get; set; }
        public string NumeroConta { get; set; }
        public string Agencia { get; set; }
        public string Digito { get; set; }
        public decimal Valor { get; set; }
        public ContaCOSIFEnum CodigoContaCosif { get; set; }
        public DateTime DataTransacao { get; set; }

    }
}