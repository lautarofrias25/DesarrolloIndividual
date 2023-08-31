namespace DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                textBox2.Text = "";
                label4.Text = "";
                label2.Visible = true;
                label2.Text = "Ingrese la primera cadena:";
                textBox2.Visible = true;
                label3.Visible = true;
                label3.Text = "Ingrese la segunda cadena:";
                textBox1.Visible = true;
                button3.Visible = true;
                button3.Text = "Concatenar";
                button3.Tag = "concatenar";
                label4.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los campos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                textBox2.Text = "";
                label4.Text = "";
                label2.Visible = true;
                label2.Text = "Ingrese una cadena:";
                textBox2.Visible = true;
                label3.Visible = false;
                textBox1.Visible = false;
                button3.Visible = true;
                button3.Tag = "eliminarEspacios";
                button3.Text = "Eliminar Espacios";
                label4.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los campos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string accion = (string)button3.Tag;
            label4.Text = "";

            try
            {
                if (accion == "concatenar")
                {
                    string cadena1 = textBox2.Text;
                    string cadena2 = textBox1.Text;
                    string resultado = cadena1 + " " + cadena2;
                    label4.Text = "Resultado: " + resultado;
                }
                else if (accion == "eliminarEspacios")
                {
                    string cadena = textBox2.Text;
                    string resultado = cadena.Replace(" ", "");
                    label4.Text = "Resultado: " + resultado;
                }
                textBox1.Text = "";
                textBox2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la operación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}