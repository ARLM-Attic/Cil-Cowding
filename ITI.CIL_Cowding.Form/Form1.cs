using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ITI.bacASable;
using System.Threading;

namespace ITI.bacASable
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics _stackGraphics;
        private ITI.bacASable.IEngine engine = new ITI.bacASable.Engine();
        StringWriter _stringWriter;
       // StringReader _stringReader;
       // string _leTrucALire;


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
                        _richTextBox.Text = File.ReadAllText(openFileDialog1.FileName);
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
                    writer.Write(_richTextBox.Text);
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

        public void UpdateConsole()
        {
            System.Drawing.Graphics consoleGraphics = _pictureBox2.CreateGraphics();
            Font drawFont = new Font( "Arial", 12 );
            SolidBrush drawBrush = new SolidBrush( Color.Black );
            consoleGraphics.DrawString( _stringWriter.ToString(), drawFont, drawBrush, 0, 10 );

        }

        /// <summary>
        /// Update the stack
        /// </summary>
        /// <param name="container"></param>
        /// <param name="stack"></param>
        public void UpdateStack( ITI.bacASable.IStack stack )
        {
            int x = 10;
            int y = 600;

            Font drawFont = new Font("Arial",12);
            SolidBrush drawBrush = new SolidBrush(Color.White);

            _pictureBox1.Refresh();
            string message = "";
            int ligne = 20;     // PX

            foreach ( ITI.bacASable.Container plouf in stack.Frame )
           {
               // Nom de la fct toussa sisi la famille
               
               message = "Function \"" + plouf.Fct.Name.ToString() + "\" Return type : " + plouf.Fct.ReturnType.FullName+"\n";

               // On affiche les arguments
               message += "Arguments : \n";
               int i = 0;
               foreach ( ITI.bacASable.IValue valeur in plouf.ArgsVars )
               {

                   message += "["+i+"] : "+valeur.Type.FullName+ " " + valeur.Data+"\n";

                   i++;
               }

               // On affiche les variables locales
               message += "Variables Locales : \n";
               i = 0;
               foreach ( ITI.bacASable.IValue valeur in plouf.LocalVars )
               {

                   message += "[" + i + "] : " + valeur.Type.FullName + " " + valeur.Data + "\n";

                   i++;
               }


               // On compte le nb de '\n'
               int nb_ligne=1;
               foreach(var c in message) {
                   if(c== '\n') nb_ligne ++; 
               }
               var taille_fenetre = ligne * nb_ligne;

               Rectangle drawRect = new Rectangle(x, y, 500, taille_fenetre);
               _stackGraphics.FillRectangle(Brushes.Green, x, y, 500, taille_fenetre);

               _stackGraphics.DrawString(message, drawFont, drawBrush, drawRect);
               y -= taille_fenetre+50;

           }
           
            // Dessin de la TopFrame
           message = "";

            foreach(var frame in stack.TopFrame)
            {
                message += "" + frame.Type.FullName + " '" + frame.Data.ToString() + " '\n";
            }

            int nb_ligne_ = 1;
            foreach (var c in message)
            {
                if (c == '\n') nb_ligne_++;
            }
            var taille_fenetre_ = ligne * nb_ligne_;

            Rectangle drawRect_ = new Rectangle(x, y, 500, taille_fenetre_);
            _stackGraphics.FillRectangle(Brushes.DarkRed, x, y, 500, taille_fenetre_);
            _stackGraphics.DrawString(message, drawFont, drawBrush, drawRect_);


        }

        #region ButtonManagment

        private void StartInit()
        {
            _pictureBox2.Refresh();
            /*
            _stringWriter = new StringWriter();
            Console.SetOut( _stringWriter );

            _leTrucALire = "2";
            Input b = new Input();
            b.ShowDialog();
            _leTrucALire = b.Text;
            Console.WriteLine( _leTrucALire );

            _stringReader = new StringReader( _leTrucALire );
            Console.SetIn( _stringReader );
            */

            // Graphique
            _pictureBox1.Refresh();
            _richTextBox.Enabled = false;

            _stackGraphics = _pictureBox1.CreateGraphics();

            Font drawFont = new Font( "Arial", 10 );
            SolidBrush drawBrush = new SolidBrush( Color.White );
        }
        private void butStepByStep_Click(object sender, EventArgs e)
        {
            _butStartAll.Visible = true;
            _butStepByStep.Visible = false;
            _butContinue.Visible = true;
            _butStop.Visible = true;

            if ( !String.IsNullOrWhiteSpace( _richTextBox.Text ) )
            {
                StartInit();

                // Start engine
                engine.SourceCode = _richTextBox.Text;
                engine.Start();
            }
        }

        private void butStartAll_Click(object sender, EventArgs e)
        {
            _butStartAll.Visible = true;
            _butStepByStep.Visible = false;
            _butContinue.Visible = false;
            _butStop.Visible = true;

            if ( !String.IsNullOrWhiteSpace( _richTextBox.Text ) )
            {
                StartInit();

                engine.SourceCode = _richTextBox.Text;
                engine.Start();

                while ( engine.NextInstruction() ) ;
                //butStop.Visible = true;
            }

        }

        private void butContinue_Click(object sender, EventArgs e)
        {           
            // On lance la prochaine instruction à faire
            engine.NextInstruction();
            // Et MaJ de la Stack
            if (engine.IsRunning)
            {
                UpdateStack( engine.GetStack() );
            }
          //  UpdateConsole();

        }
        
        private void butStop_Click(object sender, EventArgs e)
        {
            _butStartAll.Visible = true;
            _butStepByStep.Visible = true;
            _butContinue.Visible = false;
            _butStop.Visible = false;
            _richTextBox.Enabled = true;
        }
        
        #endregion ButtonManagment

        #region Draw lines number
        private void DrawLines(Graphics g, int firstLine)
        {
            // Number of text lines
            int linesCount = _richTextBox.Lines.Length;

            // Last visible line (used to determine numbers panel width)
            int lastChar = this._richTextBox.GetCharIndexFromPosition(new Point(this._richTextBox.ClientRectangle.Width, this._richTextBox.ClientRectangle.Height));
            int lastLine = this._richTextBox.GetLineFromCharIndex(lastChar);

            // Line numbers layout (position, width)
            int rightMargin = 2, leftMargin = 5, topMargin = 2, bottomMargin = 15, verticalMargin = 2;
            SizeF maxTextSize = g.MeasureString(new string((char)48, lastLine.ToString().Length), this._richTextBox.Font);
            this._panelNum.Width = (int)maxTextSize.Width + leftMargin + rightMargin;

            // Clear existing numbers
            g.Clear(this._panelNum.BackColor);

            // First line name
            int lineNumber = firstLine + 1;

            // Y position for first line number
            int firstLineY = this._richTextBox.GetPositionFromCharIndex(this._richTextBox.GetFirstCharIndexFromLine(firstLine)).Y;
            int lineY = topMargin + firstLineY;

            // Write all visible line numbers
            while (true)
            {
                // Draw line number string
                string lineNumberLabel = lineNumber.ToString().PadLeft(lastLine.ToString().Length);
                g.DrawString(lineNumberLabel, this._richTextBox.Font, Brushes.Black, leftMargin, lineY);

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
            int firstChar = this._richTextBox.GetCharIndexFromPosition(new Point(0, 0));
            int firstLine = this._richTextBox.GetLineFromCharIndex(firstChar);

            DrawLines(e.Graphics, firstLine);
        }

        private void richTextBox_SelectionChanged(object sender, System.EventArgs e)
        {
            this._panelNum.Invalidate(); // Request repaint => line numbers update
        }

        private void richTextBox_VScroll(object sender, System.EventArgs e)
        {
            this._panelNum.Invalidate(); // Request repaint => line numbers update
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            _pictureBox1.Invalidate();
            _pictureBox2.Invalidate();
        }
        private void _pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (engine.IsRunning)
            {
                UpdateStack(engine.GetStack());
               // UpdateConsole();
            }
            
        }
        private void TextEditor_Load(object sender, EventArgs e)
        {
            // Required properties
            this._richTextBox.ScrollBars = RichTextBoxScrollBars.Both;
            this._richTextBox.WordWrap = false;

            // Required events
            this._richTextBox.SelectionChanged += new System.EventHandler(this.richTextBox_SelectionChanged);
            this._richTextBox.VScroll += new System.EventHandler(this.richTextBox_VScroll);
            this._panelNum.Paint += new PaintEventHandler(this.panelNum_Paint);
            this._pictureBox2.Paint += new PaintEventHandler(this._pictureBox1_Paint);
            this.splitContainer2.SplitterMoved += new SplitterEventHandler(this.splitContainer2_SplitterMoved);
        }

        #endregion    
    }
       
}