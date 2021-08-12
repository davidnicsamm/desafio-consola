using Xunit;
using System.Collections;
using System.Collections.Generic;


namespace desafio_consola
{

    public class TestClass{


        // ************** Test sobre validación de la cadena *******************************

        [Fact]
        public void validarMensaje_Null(){
            //Se envía una cadena inválida y se verifica que sea null la devolución de la función.
            Assert.Null(Program.validarMensaje("1a"));
        }


        [Fact]
        public void validarMensaje_NotNull(){    
            // Se envía una cadena válida y se verifica que se recibe una lista o un valor no nulo. 
            Assert.NotNull(Program.validarMensaje("aa"));
        }


        // ***************** Test sobre tamaño de la lista devuelta y valores recibidos *********


        [Fact]
        public void validarMensaje_LongitudLista(){
            // Verificar la longitud de la lista devuelta por la función validarMensaje
            string mensaje = "aa bb";
            List<string> lista = new List<string>();

            lista = Program.validarMensaje(mensaje);
            Assert.Equal(2,lista.Count);
        }

        [Fact]
        public void ValidarMensaje_EspaciosEnBlanco(){
            // Verificar que el contenido de la lista devuelta a partir de una cadena
            // no incluya espacios en blanco.

            string mensaje = " aa  ab   ";
            List<string> lista = new List<string>();
        
            lista = Program.validarMensaje(mensaje);

            Assert.Equal(2,lista.Count);

            Assert.DoesNotContain(" ",lista);
            Assert.DoesNotContain("  ",lista);
            Assert.DoesNotContain("   ",lista);           
        }

        [Fact]
        public void validarMensaje_ValoresDevueltos(){
            // Verificar el contenido de la lista devuelta a partir de una cadena
            // sin espacios al principio y al final, con un espacio en blanco entre las subcadenas.

            string mensaje = "aa bb";
            List<string> lista = new List<string>();
        
            lista = Program.validarMensaje(mensaje);
            Assert.Contains("aa",lista);
            Assert.Contains("bb",lista); 
        }
        
        [Fact]
        public void ValidarMensajeConEspacios_ValoresDevueltos(){
            // Verificar el contenido de la lista devuelta a partir de una cadena
            // con espacios al principio y al final, con más de un espacio en blanco entre las subcadenas.

            string mensaje = "    aa       ab    ";
            List<string> lista = new List<string>();
        
            lista = Program.validarMensaje(mensaje);

            Assert.Equal(2,lista.Count);

            Assert.Contains("aa",lista);
            Assert.Contains("ab",lista); 
        }



        //*************** Test sobre obtener la secuencia la secuencia obtenida según la cadena enviada **************

       
        [Fact]
        public void validarSecuencia(){

            string mensaje = "hi";
            string secuenciaEsperada = "44 444";
            List<string> listaMensaje = Program.validarMensaje(mensaje);
            string secuenciaDevuelta = Program.obtenerSecuencia(listaMensaje);

            Assert.Equal(secuenciaEsperada, secuenciaDevuelta);

        }

        [Theory]
        [InlineData("hi","44 444")]
        [InlineData("yes","999337777")]
        [InlineData("foo bar","333666 666022 2777")]
        [InlineData("hello world","4433555 555666096667775553")]
        [InlineData("    hi     ","44 444")]
        [InlineData("foo          bar","333666 666022 2777")]
       

        public void validarSecuencia_ByTheory(string mensaje, string secuenciaEsperada){
            // Validar secuencias develtas según parámetros ingresados.
            
            List<string> listaMensaje = Program.validarMensaje(mensaje);
            string secuenciaDevuelta = Program.obtenerSecuencia(listaMensaje);

            Assert.Equal(secuenciaEsperada, secuenciaDevuelta);
        }
    }
}