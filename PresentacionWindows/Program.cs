using LogicaNegocio;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionWindows
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Creación de las divisas que vamos a manejar
            Divisa euro = new Divisa("Euro", 1);
            Divisa dolar = new Divisa("Dólar Americano", 1.18);
            Divisa libra = new Divisa("Libra", 0.87);
            Divisa aud = new Divisa("Dólar Australiano", 1.78);
            Divisa sgpd = new Divisa("Dólar Singapur", 1.51);
            Divisa yen = new Divisa("Yen Japonés", 174.31);
            Divisa cad = new Divisa("Dólar Canadiense", 1.63);


            ColeccDivisas divisas = new ColeccDivisas();

            // Podríamos haber usado keyedCollection, pero al final usamos Dictionary, para evitar que se 
            // añadan a la colección de divisas una misma divisa con diferente nombre en la divisa que en 
            // la clave del diccionario usamos getNombre()


            // Las propiedades de Divisa, saben en tiempo de ejecución que método utilizar(get/set)?
            divisas.Add(euro.Nombre, euro);
            divisas.Add(dolar.Nombre, dolar);
            divisas.Add(libra.Nombre, libra);
            divisas.Add(aud.Nombre, aud);
            divisas.Add(sgpd.Nombre, sgpd);
            divisas.Add(yen.Nombre, yen);
            divisas.Add(cad.Nombre, cad);


            // Creamos el servicio de conversión
            ServicioConversor service = new ServicioConversor(euro, divisas);


            Application.Run(new Form1(service));
        }
    }
}
