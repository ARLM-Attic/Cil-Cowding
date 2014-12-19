using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ITI.CIL_Cowding
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Brushes.Green, 2F);

        private IEngine engine = new Engine();


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
                        richTextBox.Text = File.ReadAllText(openFileDialog1.FileName);
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
                    writer.Write(richTextBox.Text);
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

        /// <summary>
        /// Update the stack
        /// </summary>
        /// <param name="container"></param>
        /// <param name="stack"></param>
        public void UpdateStack(IStack stack)
        {
            /*
            int x = 10;
            int y = 300;

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
            
            */
        }

        #region ButtonManagment

        private void butStepByStep_Click(object sender, EventArgs e)
        {

            // Graphique
            pictureBox1.Refresh();
            richTextBox.ReadOnly = true;

            g = pictureBox1.CreateGraphics();

            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.White);

            if (richTextBox.Text != "")
            {
                butStepByStep.Visible = false;
                butContinue.Visible = true;
                butStop.Visible = true;

            }

            // Lancement du moteur 
            engine.SourceCode = richTextBox.Text;
            engine.Start();

        }

        private void butStartAll_Click(object sender, EventArgs e)
        {

            //butStop.Visible = true;

        }

        private void butContinue_Click(object sender, EventArgs e)
        {           
            // On lance la prochaine instruction à faire
            engine.NextInstruction();
            // Et MaJ de la Stack
            UpdateStack(engine.GetStack());   
        }
        
        private void butStop_Click(object sender, EventArgs e)
        {
            butStepByStep.Visible = true;
            butContinue.Visible = false;
            butStop.Visible = false;
            richTextBox.ReadOnly = false;
        }
        
        #endregion ButtonManagment

        #region Draw lines number
        private void DrawLines(Graphics g, int firstLine)
        {
            // Number of text lines
            int linesCount = richTextBox.Lines.Length;

            // Last visible line (used to determine numbers panel width)
            int lastChar = this.richTextBox.GetCharIndexFromPosition(new Point(this.richTextBox.ClientRectangle.Width, this.richTextBox.ClientRectangle.Height));
            int lastLine = this.richTextBox.GetLineFromCharIndex(lastChar);

            // Line numbers layout (position, width)
            int rightMargin = 2, leftMargin = 5, topMargin = 2, bottomMargin = 15, verticalMargin = 2;
            SizeF maxTextSize = g.MeasureString(new string((char)48, lastLine.ToString().Length), this.richTextBox.Font);
            this.panelNum.Width = (int)maxTextSize.Width + leftMargin + rightMargin;

            // Clear existing numbers
            g.Clear(this.panelNum.BackColor);

            // First line name
            int lineNumber = firstLine + 1;

            // Y position for first line number
            int firstLineY = this.richTextBox.GetPositionFromCharIndex(this.richTextBox.GetFirstCharIndexFromLine(firstLine)).Y;
            int lineY = topMargin + firstLineY;

            // Write all visible line numbers
            while (true)
            {
                // Draw line number string
                string lineNumberLabel = lineNumber.ToString().PadLeft(lastLine.ToString().Length);
                g.DrawString(lineNumberLabel, this.richTextBox.Font, Brushes.Black, leftMargin, lineY);

                // Next line
                lineNumber += 1;
                lineY += Font.Height + verticalMargin;

                // End of numeration if end of text content or end of RichTextBox height
                if (lineY > ClientRectangle.Height - bottomMargin || lineNumber > linesCount)
                    break;
            }
        }

        private void panelNum_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Update the line numbers
            int firstChar = this.richTextBox.GetCharIndexFromPosition(new Point(0, 0));
            int firstLine = this.richTextBox.GetLineFromCharIndex(firstChar);

            DrawLines(e.Graphics, firstLine);
        }

        private void richTextBox_SelectionChanged(object sender, System.EventArgs e)
        {
            this.panelNum.Invalidate(); // Request repaint => line numbers update
        }

        private void richTextBox_VScroll(object sender, System.EventArgs e)
        {
            this.panelNum.Invalidate(); // Request repaint => line numbers update
        }

        private void TextEditor_Load(object sender, EventArgs e)
        {
            // Required properties
            this.richTextBox.ScrollBars = RichTextBoxScrollBars.Both;
            this.richTextBox.WordWrap = false;

            // Required events
            this.richTextBox.SelectionChanged += new System.EventHandler(this.richTextBox_SelectionChanged);
            this.richTextBox.VScroll += new System.EventHandler(this.richTextBox_VScroll);
            this.panelNum.Paint += new PaintEventHandler(this.panelNum_Paint); 
        }

        #endregion
    
    
    }
       
}