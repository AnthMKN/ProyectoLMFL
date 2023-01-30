using MusicaLMFL.Comun;


namespace MusicaLMFL.Modelo
{
    public class TDisco
    {
        public string CodDisco { get; set; }
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Canciones { get; set; }
        public string Precio { get; set; }
        public string Formatouno { get; set; }
        public string Formatodos { get; set; }
        public string Formatotres { get; set; }
        public string Estado { get; set; }
        public string Imagen { get; set; }
        public string Borrado { get; set; }

        public TDisco(string codDisco, string autor, string titulo, string genero, string canciones, string precio, string formatouno, string formatodos, string formatotres, string estado, string imagen, string borrado)
        {   this.CodDisco = codDisco;
            this.Autor = autor;
            this.Titulo = titulo;
            this.Genero = genero;
            this.Canciones = canciones;
            this.Precio = precio;
            this.Formatouno = formatouno;
            this.Formatodos = formatodos;
            this.Formatotres = formatotres;
            this.Estado = estado;
            this.Imagen = imagen;
            this.Borrado = borrado;
        }
        public TDisco(string autor, string titulo, string genero, string canciones, string precio, string formatouno, string formatodos, string formatotres, string estado, string imagen)
        {   
            this.CodDisco = Util.GenerarCodigo(this.GetType());
            this.Autor = autor;
            this.Titulo = titulo;
            this.Genero = genero;
            this.Canciones = canciones;
            this.Precio = precio;
            this.Formatouno = formatouno;
            this.Formatodos = formatodos;
            this.Formatotres = formatotres;
            this.Estado = estado;
            this.Imagen = imagen;
            this.Borrado = "0";
        }
        public TDisco() { }

        public override string ToString()
        {
            return CodDisco + ": " +Titulo.ToUpper();
        }

    }

    

}
