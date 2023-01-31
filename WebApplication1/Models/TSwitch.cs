namespace MusicaLMFL.Modelo
{
    public class TSwitch
    {
        public string Tipo { get; set; }
        public string Borrado { get; set; }

        public TSwitch()
        {
        }

        public TSwitch(string tipo)
        {
            this.Tipo = tipo;
        }
    }
}