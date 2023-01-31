using MusicaLMFL.Comun;

namespace MusicaLMFL.Modelo
{
    public class TTeclado
    {
        public string CodTeclado { get; set; }
        public string Designer { get; set; }
        public string Nombre { get; set; }
        public string Switch { get; set; }
        public string Keycaps { get; set; }
        public string Hotswap { get; set; }
        public string Qmk { get; set; }
        public string Via { get; set; }
        public string Rgb { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }
        public string Imagen { get; set; }
        public string Borrado { get; set; }

        public TTeclado(string codTeclado, string designer, string nombre, string switches, string keycaps, string hotswap, string qmk, string via, string rgb, string descripcion, string precio, string imagen, string borrado)
        {
            this.CodTeclado = codTeclado;
            this.Designer = designer;
            this.Nombre = nombre;
            this.Switch = switches;
            this.Keycaps = keycaps;
            this.Hotswap = hotswap;
            this.Qmk = qmk;
            this.Via = via;
            this.Rgb = rgb;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Imagen = imagen;
            this.Borrado = borrado;
        }
        public TTeclado(string designer, string nombre, string switches, string keycaps, string hotswap, string qmk, string via, string rgb, string descripcion, string precio, string imagen)
        {
            this.CodTeclado = Util.GenerarCodigo(this.GetType());
            this.Designer = designer;
            this.Nombre = nombre;
            this.Switch = switches;
            this.Keycaps = keycaps;
            this.Hotswap = hotswap;
            this.Qmk = qmk;
            this.Via = via;
            this.Rgb = rgb;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Imagen = imagen;
            this.Borrado = "0";
        }
        public TTeclado() { }
    }
}
