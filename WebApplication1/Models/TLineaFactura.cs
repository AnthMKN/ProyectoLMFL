namespace MusicaLMFL.Modelo
{
    public class TLineaFactura
    {

        public string CodFactura { get; set; }
        public string Teclado { get; set; }
        public string Cantidad { get; set; }
        public string Total { get; set; }

        public TLineaFactura(string codFactura, string teclado, string cantidad, string total)
        {
            CodFactura = codFactura;
            Teclado = teclado;
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
            return Teclado + " "+Cantidad+" "+Total;
        }
        public override bool Equals(object obj)
        {
            return ((TLineaFactura)obj).Teclado == Teclado;
        }
    }
}
