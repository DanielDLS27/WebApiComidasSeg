namespace WebApiComidasSeg.Services
{
    public class EscribirArchivoGet
    {
        private readonly string nombreDelArchivo = "registroConsultado.txt";

        public void DoWork(string nombre)
        {
            Escribir(nombre);
        }
        private void Escribir(string msg)
        {
            var ruta = $@"wwwroot\{nombreDelArchivo}";
            using (StreamWriter writer = new StreamWriter(ruta, append: true))
            {
                writer.WriteLine(msg);
                writer.Close();
            }
        }
    }
}
