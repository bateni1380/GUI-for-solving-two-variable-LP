using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphOfFunction
{
    public partial class FormFunction : Form
    {
        private FunctionColor fc;
        public FunctionColor Fc
        {
            get
            {
                return fc;
            }
        }
        public FormFunction(FunctionColor fc)
        {
            InitializeComponent();
            this.fc = fc;

        }

        private void panelColor_Click(object sender, EventArgs e)
        {
            DialogResult dr =  colorDialogFunction.ShowDialog();

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            //fc.Function = textBoxFunction.Text;
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox2.Text);
            double c = double.Parse(textBox3.Text);

            if (b == 0) // x <= 5
            {
                // we handel that by "x = 5" and sign 
                fc.Function = "x = " + (c / a).ToString();
                if ((comboBox1.Text == "<=" && a > 0) || (comboBox1.Text == ">=" && a < 0))
                    fc.Sign = -1;
                else
                    fc.Sign = 1;
            }
            else
            {
                // we handel that by "5*x + 2" and sign 
                //                or "5*x + -2"
                fc.Function = (-a / b).ToString() + "*x + " + (c / b).ToString();

                if ((comboBox1.Text == "<=" && b > 0) || (comboBox1.Text == ">=" && b < 0))
                    fc.Sign = -1;
                else
                    fc.Sign = 1;
            }
            fc.Color = Color.Red;

            this.DialogResult = DialogResult.OK;
            this.Visible = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Visible = false;
        }

        private void FormFunction_Load(object sender, EventArgs e)
        {

        }
    }
}
