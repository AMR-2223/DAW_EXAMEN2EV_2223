using System;

namespace LotoClassNS
{

    // Clase que almacena una combinación de la lotería
    //
    public class LotoAMR2223
    {
        // definición de constantes
        public const int MAX_NUMEROS = 6;
        public const int NUMERO_MENOR = 1;
        public const int NUMERO_MAYOR = 49;

        private int[] _numeros = new int[MAX_NUMEROS];   // numeros de la combinación
        public bool combinacionValida = false;      // combinación válida (si es aleatoria, siempre es válida, si no, no tiene porqué)

        public int[] Numeros
        {
            get => _numeros;
            set => _numeros = value;
        }

        /// <summary>
        /// Constructor que genera combinaciones de números aleatorios del 1 al 49
        /// </summary>
        /// <remarks>En el caso de que el constructor sea vacío, se genera una combinación aleatoria correcta</remarks>
        /// <returns>Genera 6 números no repetidos</returns>
        public LotoAMR2223()
        {
            GeneradorNumerosAleatorios();
        }

        private void GeneradorNumerosAleatorios()
        {
            Random numeroaleatorio = new Random();    // clase generadora de números aleatorios

            int i = 0, j, num;

            do             // generamos la combinación
            {
                num = numeroaleatorio.Next(NUMERO_MENOR, NUMERO_MAYOR + 1);     // generamos un número aleatorio del 1 al 49
                for (j = 0; j < i; j++)    // comprobamos que el número no está
                {
                    if (Numeros[j] == num)
                    {
                        break;
                    }
                }
                if (i == j)               // Si i==j, el número no se ha encontrado en la lista, lo añadimos
                {
                    Numeros[i] = num;
                    i++;
                }
            } while (i < MAX_NUMEROS);

            combinacionValida = true;
        }

        /// <summary>
        /// <para>
        /// Crea una combinación pasando el conjunto de números
        /// misnums es un array de enteros con la combinación que quiero crear
        /// </para>
        /// <paramref name="misnumeros">
        /// combinación con la que queremos inicializar la clase
        /// </paramref>
        /// </summary>
        /// <remarks>Este método usa sobrecarga</remarks>
        /// <returns>Genera 6 números no repetidos</returns>
        public LotoAMR2223(int[] misnumeros)
        {
            for (int i = 0; i < MAX_NUMEROS; i++)
            {
                if (misnumeros[i] >= NUMERO_MENOR && misnumeros[i] <= NUMERO_MAYOR)
                {
                    int j;
                    for (j = 0; j < i; j++)
                        if (misnumeros[i] == Numeros[j])
                            break;
                    if (i == j)
                        Numeros[i] = misnumeros[i]; // validamos la combinación
                    else
                    {
                        combinacionValida = false;
                        return;
                    }
                }
                else
                {
                    combinacionValida = false;     // La combinación no es válida, terminamos
                    return;
                }
            }
            combinacionValida = true;
        }

        /// <summary>
        /// <para>
        /// Método que comprueba el número de aciertos
        /// premio es un array con la combinación ganadora
        /// </para>
        /// </summary>
        /// <returns>se devuelve el número de aciertos</returns>
        public int Comprobar(int[] premio)
        {
            int a = 0;                    // número de aciertos
            for (int i = 0; i < MAX_NUMEROS; i++)
                for (int j = 0; j < MAX_NUMEROS; j++)
                    if (premio[i] == Numeros[j]) a++;
            return a;
        }
    }

}
