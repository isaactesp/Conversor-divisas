using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;

namespace PresentacionWindows
{

    public partial class Form1 : Form
    {
        
        private ServicioConversor servicio;
         
        public Form1(ServicioConversor servicio)
        {
            InitializeComponent();
            this.servicio = servicio;

            // Estética
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;


            // El resultado solo será de lectura
            textBoxResultado.ReadOnly = true;

            // Rellenamos los combobox con las divisas disponibles
            //rellenarCombos
            rellenarCombos();


        }

        private void rellenarCombos()
        {
            //PRE: función que rellena los comboBox
            //POST: los comboBox quedan rellenos con las divisas disponibles en el servicio asociado al formulario
            
            // Limpiamos los elementos actuales de los comboBox, por si cambian las divisas
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();    

            List<string> lista1 = servicio.Divisas.getTodasDivisas();
            List<string> lista2 = servicio.Divisas.getTodasDivisas();

            
            // Añadismos los elementos a los comboBox
            comboBox1.Items.AddRange(lista1.ToArray());
            comboBox2.Items.AddRange(lista2.ToArray());

            // Por si cambian las divisas 
            comboBox1.SelectionChangeCommitted += ComboChanged;
            comboBox2.SelectionChangeCommitted += ComboChanged;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // PRE: función que convierte la cantidad de una divisa a otra al pulsar el btConvertir,
            // se verifican los parámetros para ser validos antes de hacer la conversión
            // POST: se muestra el resultado en el textBoxResultado
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || textBox1.Text == "")
            {
                MessageBox.Show("Por favor, rellene todos los campos");
                return;
            }   

            if(!double.TryParse(textBox1.Text, out double cantidad) || cantidad < 0)
            {
                MessageBox.Show("Por favor, introduzca una cantidad positiva");
                return;
            }   

            // Las comboBox son de strings, por lo que el metodo ToString no hará nada raro, no hace falta implementarlo de nuevo
            string origen = comboBox1.SelectedItem.ToString();
            string destino = comboBox2.SelectedItem.ToString(); 
            double resultado = servicio.convertir(origen, destino, cantidad);

            // Expresamos el resultado con 2 decimales
            textBoxResultado.Text = resultado.ToString("F2");





        }
        
        private void ComboChanged(object sender, EventArgs e)
        {
            // Si se cambia alguna de las comboBox, se borra el resultado
            textBoxResultado.Clear();
        }

        private void btIntroducirNueva_Click(object sender, EventArgs e)
        {
            // PRE: función que añade una nueva divisa al conversor al pulsar el btIntroducirNueva,
            // se verifican los parámetros para ser validos antes de crear una divisa nueva
            // POST: se añade la divisa al conversor si no existía ya, y se notifica al usuario
            // la divisa desaparecerá del conversor cuando el programa se cierre

            if (textBoxNombre.Text == "" || textBoxValor.Text == "")
            {
                MessageBox.Show("Por favor, rellene todos los campos necesarios para introducir una divisa");
                return;
            }

            if(!double.TryParse(textBoxValor.Text, out double valor) || valor <= 0)
            {
                MessageBox.Show("Por favor, introduzca un valor positivo");
                return;
            }

            string nombre = textBoxNombre.Text;
            //Creo divisa vacía para usar el método createNewDivisa
            Divisa d = new Divisa(nombre,valor);
            if(servicio.anadirDivisaAlConversor(d))
            {
                MessageBox.Show("Divisa añadida correctamente");
                // Rellenamos los combos de nuevo
                rellenarCombos();
                // Limpiamos los textBox
                textBoxNombre.Clear();
                textBoxValor.Clear();

                // Borramos el resultado por si acaso
                textBoxResultado.Clear();
                // Borramos la cantidad por si acaso
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("La divisa ya existe");
            }

        }
    }
}
