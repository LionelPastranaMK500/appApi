namespace appApi.Model
{
    public class Procesador
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public int nucleos { get; set; }
        public int hilos { get; set; }
        public decimal frecuenciaBase { get; set; }
        public decimal frecuenciaTurbo { get; set; }
        public int tdp { get; set; }
        public int lanzamiento { get; set; }
    }
}
