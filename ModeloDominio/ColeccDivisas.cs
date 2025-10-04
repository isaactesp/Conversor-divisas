using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    // Modelo de dominio
    //Hacer las clases public para que pueda ser usada desde otra capa
    public class ColeccDivisas : Dictionary<string, Divisa>
    {
        // PRE: Representa la colección de divisas que vamos a manejar.
        // No vemos más que los métodos concretos de nuestro problema, los generales los hereda de Dictionary, 
        // la cual nos va a permitir construir, insertar, eliminar y acceder en ColeccDivisas
        // Destacar que no permitiremos una Divisa con un nombre en la colección y otro como nombre de la divisa



        // Con los siguientes métodos permitimos que la capa de negocio funcione con respecto al
        // modelo de domino independientemente de como hayamos implementado la colección de divisas
        public Divisa getDivisa(string name)
        {
            // PRE: name es el nombre de una divisa que pertenece a la colección
            // POST: devuelve la divisa cuyo nombre es name
            return this[name];
        }


        public bool existeDivisa(string name)
        {
            // PRE: name es el nombre de una divisa
            // POST: devuelve true si la divisa con nombre name está en la colección

            return this.ContainsKey(name);
        }

        public bool existeDivisa(Divisa d)
        {
            // PRE: d es una divisa
            // POST: devuelve true si la divisa d está en la colección
            return this.ContainsKey(d.Nombre);
        }

        public List<string> getTodasDivisas()
        {
            // PRE: -
            // POST: devuelve una lista con todas las divisas de la colección
            return this.Keys.ToList();
        }

        public bool anadirDivisa(Divisa d)
        {
            // PRE: d es una divisa
            // POST: añade la divisa d a la colección si no existía ya, devolviendo true. Si ya existía devuelve false
            if (existeDivisa(d))
            {
                return false;
            }
            // Forma correcta de añadir para que no haya incoherencias entre clave y valor
            this.Add(d.Nombre, d);
            return true;
        }



        // Empecé implementando la colección de divisas como KeyedCollection, pero
        // cambié a Dictionary porque tengo más experiencia con él
        /*
        protected override string getKeyFromItem(Divisa item)
        {
            return item.getNombre();
        }

        */




    }
}
