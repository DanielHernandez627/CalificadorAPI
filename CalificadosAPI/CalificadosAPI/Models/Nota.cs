namespace CalificadosAPI.Models
{
    public class Nota
    {
        public int id { get; set; }
        public int Id_estudiante { get; set; }
        public double Calificacion { get; set; }
        public string Descripcion { get; set; }
    }
}
