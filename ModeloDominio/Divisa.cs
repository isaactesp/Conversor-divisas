using System;
using System.Collections.Specialized;
using System.IO;

namespace ModeloDominio
{
    public class Divisa
    {
        // Modelo de dominio
        private string nombre;
        private double valorRef;
        // PRE: - nombre es el nombre de la divisa
        //      - valor es el valor con respecto a la divisa de referencia 
        //          de manera que 1 unidad de divisa de referencia = valorRef divisa nombre


        // A continuación implemento las propiedades para los atributos nombre y valorRef.
        // Tienen que ser public ya que las estamos utilizando fuera de la clase
        public double Valor
        {
            get { return valorRef; }
            set { valorRef = value; }
        }
        public string Nombre
        {
            // Popiedad solo de lectura
            get { return nombre; }
        }

        public Divisa(string nombre, double valor)
        {
            // PRE: nombre es el nombre que tendrá la divisa y valor su valor con respecto
            //  a la divisa de referencia
            // POST: inicializa una Divisa con nombre y valor
            this.nombre = nombre;
            this.valorRef = valor;
        }
        public Divisa()
        {
            // PRE: constructor sin parámetros 
            // por el momento no lo utilizaremos(igual en el futuro) pero por si acaso notificaríamos al usuario
            this.nombre = "";
            this.valorRef = 0;
        }

        





        /*
        public string getNombre()
        {
            return this.nombre;
        }

        public double getValor()
        {
            return this.valorRef;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;   

        }

        public void setValor(double valor)
        {
            this.valorRef = valor; 
        }
        */


    }
}
