int opcion;
Boxeador boxeador1 = null;
Boxeador boxeador2 = null;
Boxeador[] boxeadores = {boxeador1, boxeador2};

do
{
   Console.WriteLine("\nPulsa cualquier tecla para continuar");
   Console.ReadKey();
   Console.Clear();
   Console.WriteLine("1. Cargar Datos Boxeador 1");
   Console.WriteLine("2. Cargar Datos Boxeador 2");
   Console.WriteLine("3. Generar Atributos Aleatorios de un Boxeador");
   Console.WriteLine("4. Cambiar Atributos de un Boxeador");
   Console.WriteLine("5. Pelear!");
   Console.WriteLine("6. Salir");
   opcion = Funciones.IngresarEnteroEnRango("Elija opción: ", 1, 6);

   switch (opcion)
   {
      case 1:
         boxeadores[opcion - 1] = ObtenerBoxeador();
         break;
      case 2:
         boxeadores[opcion - 1] = ObtenerBoxeador();
         break;
      case 3:
         GenerarAtributosAleatoriosBoxeador();
         break;
      case 4:
         CambiarAtributos();
         break;
      case 5:
         Pelear();
         break;
   }

} while (opcion != 6);

Boxeador ObtenerBoxeador()
{
   string nombre = Funciones.IngresarTexto("Ingresa el nombre del boxeador: ");
   string pais = Funciones.IngresarTexto("Ingresa el pais del boxeador: ");
   int peso = Funciones.IngresarEntero("Ingresa el peso del boxeador: ");
   int potenciaGolpes = Funciones.IngresarEnteroEnRango("Ingresa la potencia de los golpes del boxeador: ", 1, 100);
   int velocidadPiernas = Funciones.IngresarEnteroEnRango("Ingresa la velocidad de piernas del boxeador: ", 1, 100);
   int inteligencia = Funciones.IngresarEnteroEnRango("Ingresa la inteligencia del boxeador: ", 1, 100);
   Console.WriteLine("Se ha creado el boxeador ", nombre);
   return new Boxeador(nombre, pais, peso, potenciaGolpes, velocidadPiernas, inteligencia);
}

bool VerificarBoxeador(int boxeador)
{
   if (boxeadores[boxeador - 1] != null) return true;
   else return false;
}

void GenerarAtributosAleatoriosBoxeador()
{
   int numeroBoxeador = Funciones.IngresarEnteroEnRango("Selecciona el boxeador (1 o 2): ", 1, 2);
   bool boxeadorExiste = VerificarBoxeador(numeroBoxeador);
   if (boxeadorExiste)
   {
      boxeadores[numeroBoxeador - 1].GenerarAtributosAleatorios();
      Console.WriteLine($"Se han generado los atributos aleatorios del boxeador {numeroBoxeador}.");
   }
   else Console.WriteLine("El boxeador aún no existe.");
}

void CambiarAtributos()
{
   int numeroBoxeador = Funciones.IngresarEnteroEnRango("Selecciona el boxeador (1 o 2): ", 1, 2);
   bool boxeadorExiste = VerificarBoxeador(numeroBoxeador);
   if (boxeadorExiste)
   {
      boxeadores[numeroBoxeador - 1].potenciaGolpes = Funciones.IngresarEnteroEnRango("Ingresa la potencia actualizada de los golpes del boxeador: ", 1, 100);
      boxeadores[numeroBoxeador - 1].velocidadPiernas = Funciones.IngresarEnteroEnRango("Ingresa la velocidad actualizada de piernas del boxeador: ", 1, 100);
      boxeadores[numeroBoxeador - 1].inteligencia = Funciones.IngresarEnteroEnRango("Ingresa la inteligencia actualizada del boxeador: ", 1, 100);
      Console.WriteLine($"Se han cambiado los atributos del boxeador {numeroBoxeador}.");
   }
   else Console.WriteLine("El boxeador aún no existe.");
}

void Pelear()
{
   if (boxeadores[0] != null && boxeadores[1] != null)
   {
      double skill1 = boxeadores[0].ObtenerSkill();
      double skill2 = boxeadores[1].ObtenerSkill();
      double diferencia = Math.Abs(skill1 - skill2);

      string ganador;

      if (skill1 > skill2) ganador = boxeadores[0].nombre;
      else ganador = boxeadores[1].nombre;

      if (diferencia >= 30)
         {
            Console.WriteLine($"Ganó {ganador} por KO");
         }
         else if (diferencia >= 10)
         {
            Console.WriteLine($"Ganó {ganador} por puntos en fallo unánime");
         }
         else
         {
            Console.WriteLine($"Ganó {ganador} por puntos en fallo dividido");
         }
      }
   else Console.WriteLine("Uno o los dos de los boxeadores no existe aún.");
}