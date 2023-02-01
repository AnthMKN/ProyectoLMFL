using MusicaLMFL.Comun;


namespace MusicaLMFL.Modelo
{
    public class TLinea
    {
        public string CodFactura { get; set; }
        public string Teclado { get; set; }
        public string Cantidad { get; set; }
        public string Total { get; set; }

        public TLinea(string codFactura, string teclado, string cantidad, string total)
        {
            CodFactura = codFactura;
            Teclado = teclado;
            Cantidad = cantidad;
            Total = total;
        }

        public TLinea(string teclado, string cantidad, string total)
        {
            CodFactura = Util.GenerarCodigo(this.GetType());
            Teclado = teclado;
            Cantidad = cantidad;
            Total = total;
        }

        public TLinea() { }

        public override string ToString()
        {
            return CodFactura+": " + Teclado.ToUpper();
        }

    }

    

}
