

namespace MusicaLMFL.Modelo
{
    public class LineaAuxiliar
    {

        public string CodFactura { get; set; }
        public TDisco Disco { get; set; }
        public string Cantidad { get; set; }
        public string Total { get; set; }

        public LineaAuxiliar(string codFactura, TDisco disco, string cantidad, string total)
        {
            CodFactura = codFactura;
            Disco = disco;
            Cantidad = cantidad;
            Total = total;
        }
        public LineaAuxiliar()
        {

        }

        public double subTotal()
        {
            return double.Parse(Total.Replace('.', ','));
        }
        
    }
}
