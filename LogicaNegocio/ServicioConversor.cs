using System.Collections.ObjectModel;
using ModeloDominio;


namespace LogicaNegocio
{
    public class ServicioConversor
    {
        // Capa de negocio
        private Divisa divisaRef;
        private ColeccDivisas divisas;

        // PRE: - divisaRef es la divisa de referencia
        //      - divisas es la ColeccDivisas que vamos a manejar, no nos importa como esté implementada


        // Defino constructor
        public ServicioConversor(Divisa divisaRef, ColeccDivisas divisas)
        {
            this.divisaRef = divisaRef;
            this.divisas = divisas;
        }


        // Propiedades para los atributos
        public Divisa DivisaRef
        {
            get { return this.divisaRef; }
            set { this.divisaRef = value; }
        }

        public ColeccDivisas Divisas
        {
            get { return this.divisas; }
            set { this.divisas = value; }
        }


        public double convertir(string divisaInicio, string divisaFin, double cantidadDivInicio)
        {
            // PRE: divisaInicio y divisaFin son dos divisas que pertenecen a la colección de divisas y cantidad es un valor positivo
            // POST: devuelve la cantidad convertida de divisaInicio a divisaFin
            Divisa d1 = this.divisas.getDivisa(divisaInicio);
            Divisa d2 = this.divisas.getDivisa(divisaFin);
            return cantidadDivInicio * d2.Valor / d1.Valor;
        }


        public bool existeDivisa(string name)
        {
            // PRE: name es el nombre de una divisa
            // POST: devuelve true si la divisa con nombre name está en la colección de nuestro ServicioConversor y falso en caso contrario
            return this.divisas.existeDivisa(name);
        }

        public bool anadirDivisaAlConversor(Divisa d)
        {
            // PRE: d es una divisa
            // POST: añade la divisa d a la colección si no existía ya, devolviendo true. Si ya existía devuelve false

            // me parece más cómodo usar el método desde ColeccDivisas
            return this.divisas.anadirDivisa(d);
        }







    }
}
