using MusicaLMFL.Comun;


namespace MusicaLMFL.Modelo
{
    public class TLinea
    {
        public string CodFactura { get; set; }
        public string Disco { get; set; }
        public string Cantidad { get; set; }
        public string Total { get; set; }

        public TLinea(string codFactura, string disco, string cantidad, string total)
        {
            CodFactura = codFactura;
            Disco = disco;
            Cantidad = cantidad;
            Total = total;
        }

        public TLinea(string disco, string cantidad, string total)
        {
            CodFactura = Util.GenerarCodigo(this.GetType());
            Disco = disco;
            Cantidad = cantidad;
            Total = total;
        }

        public TLinea() { }

        public override string ToString()
        {
            return CodFactura+": " + Disco.ToUpper();
        }

    }

    

}
