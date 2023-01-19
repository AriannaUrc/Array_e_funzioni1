using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_e_funzioni
{
    internal class Program
    {

        //aggiunta di un elemento all'array in coda
        static bool aggiunta_in_coda(ref int lenght, ref int[] array, int elemento)
        {
            bool max_lenght = false;
            if (lenght < array.Length - 1)
            {
                array[lenght] = elemento;
                lenght++;
            }
            else
            {
                max_lenght = true;
            }
            return max_lenght;
        }


        //scrittura codice html della stringa
        static string fun_codice_html(int[] array, int lenght)
        {
            string codice_html = "<ul>";
            for (int i = 0; i < lenght + 1; i++)
            {
                codice_html = codice_html + "<li>" + array[i] + "</li>";
            }
            codice_html = codice_html + "</ul>";
            return codice_html;
        }

        //funzione per cercare un elemento dell'array, restituire o la posizione o se non possibile -1
        static int fun_posizione(int[] array, int ricerca, int lenght)
        {
            int posizione = -1;

            for (int i = 0; i < lenght + 1; i++)
            {
                if (array[i] == ricerca)
                {
                    posizione = i;
                }
            }
            return posizione;
        }

        //cancellazione di un elemento da un array
        static int[] remove(int[] array, int rem, ref int lenght)
        {

            for (int i = rem - 1; i <= lenght; i++)
            {
                array[i] = array[i + 1];
            }
            lenght--;
            return array;
        }

        //Inserimento di un valore in una posizione dell'array.
        static bool add(ref int[] array, int ele_agg, ref int lenght, int pos_agg)
        {
            bool max = false;
            for (int i = lenght; i > pos_agg; i--)
            {
                if (pos_agg <= lenght)
                {
                    array[i + 1] = array[i];
                }
                else
                {
                    max = true;
                }
            }
                
            array[pos_agg-1] = ele_agg;
            lenght++;
            return max;
        }

        static void Main(string[] args)
        {
            int[] array = new int[100];
            int lenght = 0, ricerca, posizione, elemento, rem, ele_agg, pos_agg, continua, menu;
            string codice_html = "";
            bool confirm_max, confirm_position;

            //aggiunta di un elemento all'array in coda
            Console.WriteLine("Inserire l'array iniziale.");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Inserire elemento: ");
                elemento = int.Parse(Console.ReadLine());
                aggiunta_in_coda(ref lenght, ref array, elemento);
            }




            Console.WriteLine("inserisci 1 se vuoi continuare, 0 se vuoi terminare il programma: ");

            continua = int.Parse(Console.ReadLine());

            while (continua == 1)
            {
                Console.WriteLine("Hai varie opzioni a tua disposizione:\n\n 1 - Stampa l'array\n 2 - Aggiungere un elemento in coda\n 3 - ottenere codice html dell'array\n 4 - trovare posizione di un elemento\n 5 - Cancellare elemento\n 6 - inserire elemento in posizione specifica\n");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        for (int i = 0; i < lenght; i++)
                        {
                            Console.Write(array[i]);
                        }
                        break;

                    case 2:
                        //aggiunta di un elemento all'array in coda
                        Console.WriteLine("Inserire l'elemento da aggiungere in coda: ");
                        elemento = int.Parse(Console.ReadLine());
                        confirm_max = aggiunta_in_coda(ref lenght, ref array, elemento);
                        if (confirm_max)
                        {
                            Console.WriteLine("La grandezza massima dell'array e stata raggiunta");
                        }
                        break;


                    case 3:
                        //scrittura codice html della stringa
                        codice_html = fun_codice_html(array, lenght);
                        Console.WriteLine(codice_html);
                        break;

                    case 4:
                        //funzione per cercare un elemento dell'array, restituire o la posizione o se non possibile -1
                        Console.WriteLine("Inserire l'elemento da ricercare: ");
                        ricerca = int.Parse(Console.ReadLine());
                        posizione = fun_posizione(array, ricerca, lenght);
                        Console.WriteLine("La posizione dell'elemento ricercato è uguale a: "+posizione);
                        break;


                    case 5:
                        //cancellazione di un elemento da un array
                        Console.WriteLine("Inserire la posizione dell'elemento da cancellare: ");
                        rem = int.Parse(Console.ReadLine());
                        array = remove(array, rem, ref lenght);

                        break;


                    case 6:
                        //Inserimento di un valore in una posizione dell'array.
                        Console.WriteLine("Inserire la posizione desiderata: ");
                        pos_agg = int.Parse(Console.ReadLine());
                        Console.WriteLine("Inserire il nuovo valore: ");
                        ele_agg = int.Parse(Console.ReadLine());
                        confirm_position = add(ref array, ele_agg, ref lenght, pos_agg);
                        if (confirm_position)
                        {
                            Console.WriteLine("posizione non valida");
                        }

                        break;

                    default:
                        Console.WriteLine("valore non valido");
                        break;
                }

                Console.WriteLine("\ninserisci 1 se vuoi continuare, 0 se vuoi terminare il programma: ");

                continua = int.Parse(Console.ReadLine());
            }
        }
    }
}