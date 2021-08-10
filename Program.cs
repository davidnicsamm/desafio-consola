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
            string mensajeSecuencia = "";

            while(mensajeCadena != ""){

                List<string>  lista = validarMensaje(mensajeCadena); 

                if( lista != null){
                    //Obtengo la secuencia correspondinte.
                    mensajeSecuencia = obtenerSecuencia(lista);     
                    Console.WriteLine("Secuencia obtenida: " + mensajeSecuencia);               
                }else{
                    Console.WriteLine("Cadena inválida");
                }

                contador++;
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
                listaCadena = cadena.Split('-').ToList(); 
            }

            return listaCadena;
        }

        //Devuelve un string con la secuencia de acuerdo a las cadenas contenidas en la lista.
        public static string obtenerSecuencia(List<string> listaCadena){
            
            string cadenaSalida = "";        
            
            foreach(string cadena in listaCadena){
               
                String cadenaPalabra = "";
                string numeroAnterior = "0";
                string numero = "";
                foreach(char caracter in cadena.ToLower()){
                    string cadenaCaracter = "";
                    switch (caracter){
                        case 'a': 
                            cadenaCaracter = "2";
                            numero = "2";
                            break;
                        case 'b': 
                            cadenaCaracter = "22";
                            numero = "2";
                            break;
                        case 'c': 
                            cadenaCaracter = "222";
                            numero = "2";
                            break;
                        case 'd': 
                            cadenaCaracter = "3";
                            numero = "3";
                            break;
                        case 'e': 
                            cadenaCaracter = "33";
                            numero = "3";
                            break;
                        case 'f': 
                            cadenaCaracter = "333";
                            numero = "3";
                            break;
                        case 'g': 
                            cadenaCaracter = "4";
                            numero = "4";
                            break;
                        case 'h': 
                            cadenaCaracter = "44";
                            numero = "4";
                            break;
                        case 'i': 
                            cadenaCaracter = "444";
                                numero = "4";
                            break;
                        case 'j': 
                            cadenaCaracter = "5";
                            numero = "5";
                            break;
                        case 'k': 
                            cadenaCaracter = "55";
                            numero = "5";
                            break;
                        case 'l': 
                            cadenaCaracter = "555";
                            numero = "5";
                            break;
                        case 'm': 
                            cadenaCaracter = "6";
                            numero = "6";
                            break;
                        case 'n': 
                            cadenaCaracter = "66";
                            numero = "6";
                            break;
                        case 'o': 
                            cadenaCaracter = "666";
                            numero = "6";
                            break;
                        case 'p': 
                            cadenaCaracter = "7";
                            numero = "7";
                            break;
                        case 'q': 
                            cadenaCaracter = "77";
                            numero = "7";
                            break;
                        case 'r': 
                            cadenaCaracter = "777";
                            numero = "7";
                            break;
                        case 's': 
                            cadenaCaracter = "7777";
                            numero = "7";
                            break;
                        case 't': 
                            cadenaCaracter = "8";
                            numero = "8";
                            break;
                        case 'u': 
                            cadenaCaracter = "88";
                            numero = "8";
                            break;
                        case 'v': 
                            cadenaCaracter = "888";
                            numero = "8";
                            break;
                        case 'w': 
                            cadenaCaracter = "9";
                            numero = "9";
                            break;
                        case 'x': 
                            cadenaCaracter = "99";
                            numero = "9";
                            break;
                        case 'y': 
                            cadenaCaracter = "999";
                            numero = "9";
                            break;
                        case 'z': 
                            cadenaCaracter = "9999";
                            numero = "9";
                            break; 
                    }

                    //Verifica si corresponde a la misma tecla
                    if(numero == numeroAnterior){
                        cadenaPalabra = cadenaPalabra + " ";
                    }
                    cadenaPalabra = cadenaPalabra + cadenaCaracter;
                    numeroAnterior = numero;
                    
                }                        
                
                //Si es la primer palabra, no grega espacio en la cadena de salida
                if(cadenaSalida == ""){
                    cadenaSalida = cadenaSalida + cadenaPalabra;
                }else{
                    cadenaSalida = cadenaSalida + "0" + cadenaPalabra;
                }


            }
            
            return cadenaSalida;
        }
    }
}
