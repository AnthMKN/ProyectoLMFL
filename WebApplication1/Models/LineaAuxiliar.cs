

namespace MusicaLMFL.Modelo
{
    public class LineaAuxiliar
    {

        public string CodFactura { get; set; }
        public TTeclado Teclado { get; set; }
        public string Cantidad { get; set; }
        public string Total { get; set; }

        public LineaAuxiliar(string codFactura, TTeclado teclado, string cantidad, string total)
        {
            CodFactura = codFactura;
            Teclado = teclado;
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
