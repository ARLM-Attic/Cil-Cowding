using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITI.CIL_Cowding
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Brushes.Green, 2F);
        private CIL_Cowding.Container container;
        ITokenizer _mytokenizer;
        Analyser anal;

        public Form1()
        {
            InitializeComponent();
        }

        #region Quit
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region LoadFile
        /// <summary>
        /// Load a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : Could not read file from disk. Original error" + ex.Message);
                }
                finally
                {
                    myStream.Close();
                }
            }
        }

        #endregion

        #region SaveFile
        /// <summary>
        /// Save a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Specify the extensions allowed
            saveFileDialog1.Filter = "All files (*.*)|*.*";
            //Empty the FileName text box of the dialog
            saveFileDialog1.FileName = String.Empty;
            //Set default extension as .txt
            saveFileDialog1.DefaultExt = ".txt";

            //Open the dialog and determine which button was pressed
            DialogResult result = saveFileDialog1.ShowDialog();

            //If the user presses the Save button
            if (result == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write);

                //Create a writer that will write to the stream
                StreamWriter writer = new StreamWriter(fs);

                try
                {
                    //Write the contents of the text box to the stream
                    writer.Write(textBox1.Text);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error : Could not save file from disk. Original error : " + ex.Message);
                }
                finally
                {
                    //Close the writer and the stream
                    writer.Close();
                }
            }
        }
        #endregion

        private void butStepByStep_Click(object sender, EventArgs e)
        {
            
            // Gestion du graphique
            pictureBox1.Refresh();
            textBox1.ReadOnly = true;

            g = pictureBox1.CreateGraphics();
            string s = textBox1.Text;
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.White);

            if (textBox1.Text != "")
            {
                butStepByStep.Visible = false;
                butContinue.Visible = true;
                butStop.Visible = true;
            }

            // Gestion du moteur d'execution
            _mytokenizer = new StringTokenizer(textBox1.Text);
            anal = new Analyser(_mytokenizer);



        }

        private void butStartAll_Click(object sender, EventArgs e)
        {
            
            //butStop.Visible = true;
            
        }

        /// <summary>
        /// Update the stack
        /// </summary>
        /// <param name="container"></param>
        /// <param name="stack"></param>
        public void UpdateStack()
        {
            int x = 10;
            int y = 300;
            var container = CIL_Stack.Frame;
            var stack = CIL_Stack.TopFrame;
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.White);

            pictureBox1.Refresh();

            // Dessin de la frame
            foreach (KeyValuePair<String, Variable> Var in container.Var)
            {
                Rectangle drawRect = new Rectangle(x, y, 500, 50);
                g.FillRectangle(Brushes.Green, x, y, 500, 50);

                // ecrire les infos de la variable en cours
                String message = Var.Value.Type.ToString() + " " + Var.Value.Data.ToString() +" "+ Var.Value.Label.ToString();

                g.DrawString( message, drawFont, drawBrush, drawRect);

                y -= 80;
            }

            // Dessin de la Top Frame
            var tmp = stack.ToArray();
            Array.Reverse(tmp);

            foreach (var Var in tmp)
            {
                Rectangle drawRect = new Rectangle(x, y, 500, 50);
                g.FillRectangle(Brushes.DarkRed, x, y, 500, 50);
                
                // ecrire les infos de la variable en cours
                String message = Var.Type.ToString() + " " + Var.Data.ToString();
                g.DrawString(message, drawFont, drawBrush, drawRect);


                y -= 80;
            }
            

        }

        private void butContinue_Click(object sender, EventArgs e)
        {
            anal.ParseBody();

            UpdateStack();   
        }

        private void butStop_Click(object sender, EventArgs e)
        {
            butStepByStep.Visible = true;
            butContinue.Visible = false;
            butStop.Visible = false;
            textBox1.ReadOnly = false;           
        }



    }
}
