using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace desafio_consola
{
    class Program
    {
        public static void Main(string[] args)
        {
            int contador = 1;
            Console.WriteLine("Ingrese una palabra o frase nro: " + contador);
            Console.WriteLine("O presione enter para terminar");
            string mensajeCadena;
            mensajeCadena = Console.ReadLine();

            while(mensajeCadena != ""){

                List<string>  lista = validarMensaje(mensajeCadena); 

                if( lista != null){

                    Console.WriteLine("Cadena válida: " + lista.Count);
                    foreach(string c in lista){
                        Console.WriteLine("Palabra: " + c + " - ");
                    }
                }else{
                    Console.WriteLine("Cadena inválida");
                }

                contador = contador++;
                Console.WriteLine("Ingrese una palabra o frase nro: " + contador);
                Console.WriteLine("O presione enter para terminar");              
                mensajeCadena = Console.ReadLine();
            } 

            limpiarBufferTeclado();            
        }

        /*********************************************** Funciones *********************************************/

        //Limpia el buffer del teclado
        public static void limpiarBufferTeclado(){
            while (Console.KeyAvailable) 
            {
                Console.ReadKey();
            }
        }


        // Valida que una cadena posea sólo letras y espacios.
        // Si la cadena no es vacía o sólo espacios, devuelve una lista con las palabras de la misma,
        // caso contrario devuelvee una lista con valor null.        
        public static List<string> validarMensaje(string mensajeCadena){

            // Caracteres aceptados en la cadena
            string expresion = @"^[a-zA-Z\s]*$";
            Regex r = new Regex(expresion);
            List<string> listaCadena = null;            
           
            if(r.IsMatch(mensajeCadena)){ 

                mensajeCadena = mensajeCadena.TrimStart(' ');
                mensajeCadena = mensajeCadena.TrimEnd(' ');                
                Regex espacio = new Regex(@"\s+"); 
                string cadena = espacio.Replace(mensajeCadena,"-");
                Console.WriteLine("Cadena: " + cadena);                
                listaCadena = cadena.Split('-').ToList();              
            }

            return listaCadena;
        }
    }
}
