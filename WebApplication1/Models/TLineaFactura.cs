

namespace MusicaLMFL.Modelo
{
    public class TLineaFactura
    {

        public string CodFactura { get; set; }
        public string Disco { get; set; }
        public string Cantidad { get; set; }
        public string Total { get; set; }

        public TLineaFactura(string codFactura, string disco, string cantidad, string total)
        {
            CodFactura = codFactura;
            Disco = disco;
            Cantidad = cantidad;
            Total = total;
        }
        public TLineaFactura()
        {

        }

        public float subTotal()
        {
            return float.Parse(Total);
        }

        public override string ToString()
        {
            return Disco + " "+Cantidad+" "+Total;
        }
        public override bool Equals(object obj)
        {
            return ((TLineaFactura)obj).Disco == Disco;
        }
    }
}
