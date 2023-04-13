public class Boxeador
{
   public string nombre{get; set;}
   public string pais{get; set;}
   public int peso{get; set;}
   public int potenciaGolpes{get;set;}
   public int velocidadPiernas{get; set;}
   public int inteligencia{get; set;}

   public Boxeador(string nombre, string pais, int peso, int potenciaGolpes, int velocidadPiernas, int inteligencia)
   {
      this.nombre = nombre;
      this.pais = pais;
      this.peso = peso;
      this.potenciaGolpes = potenciaGolpes;
      this.velocidadPiernas = velocidadPiernas;
      this.inteligencia = inteligencia;
   }

   public double ObtenerSkill()
   {
      Random rd = new Random();
      return velocidadPiernas * 0.6 + potenciaGolpes * 0.8 + inteligencia * 0.25 + rd.Next(1, 3);
   }

   public void GenerarAtributosAleatorios()
   {
      Random rd = new Random();
      this.potenciaGolpes = rd.Next(1, 100);
      this.velocidadPiernas = rd.Next(1, 100);
      this.inteligencia = rd.Next(1, 100);

   }
}

