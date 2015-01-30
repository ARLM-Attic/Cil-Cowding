using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ITI.CIL_Cowding;
using System.Threading;

namespace ITI.CIL_Cowding
{
    public partial class Cil_Cowding : Form
    {
        private System.Drawing.Graphics _stackGraphics;
        private ITI.CIL_Cowding.IEngine _engine;

        // Timer
        static System.Windows.Forms.Timer _myTimer;

        public Cil_Cowding()
        {
            InitializeComponent();
            _buttonContinueRun.Visible = false;
            _buttonBreak.Visible = false;
            API_Canvas.Init(_pictureBox2);
            _stackGraphics = _pictureBox1.CreateGraphics();
            _engine = new ITI.CIL_Cowding.Engine();
            _myTimer = new System.Windows.Forms.Timer();
            _myTimer.Tick += new EventHandler( TimerEventProcessor );
            _myTimer.Interval = 1;
        }

        private void PictureBox1()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

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


        

        /// <summary>
        /// Update the stack
        /// </summary>
        /// <param name="container"></param>
        /// <param name="stack"></param>
        public void UpdateStack( ITI.CIL_Cowding.IStack stack )
        {
            Bitmap bmp = new Bitmap(_pictureBox1.Width, 10000);
            using (Graphics image = Graphics.FromImage(bmp))
            {

            int x = 10;
            int y = 10;

            Font drawFont = new Font("Arial",12);
            SolidBrush drawBrush = new SolidBrush(Color.White);

            _pictureBox1.Refresh();
            string message = "";
            int ligne = 20;     // PX

            foreach ( ITI.CIL_Cowding.Container plouf in stack.Frame )
           {
               // Nom de la fct toussa sisi la famille
               
               message = "Function \"" + plouf.Fct.Name.ToString() + "\" Return type : " + plouf.Fct.ReturnType.FullName+"\n";

               // On affiche les arguments
               message += "Arguments : \n";
               int i = 0;
               foreach ( ITI.CIL_Cowding.IValue valeur in plouf.ArgsVars )
               {

                   message += "["+i+"] : "+valeur.Type.FullName+ " " + valeur.Data+"\n";

                   i++;
               }

               // On affiche les variables locales
               message += "Variables Locales : \n";
               i = 0;
               foreach ( ITI.CIL_Cowding.IValue valeur in plouf.LocalVars )
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
               image.FillRectangle(Brushes.Green, x, y, 500, taille_fenetre);

               image.DrawString(message, drawFont, drawBrush, drawRect);
               y += taille_fenetre+50;

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
            image.FillRectangle(Brushes.DarkRed, x, y, 500, taille_fenetre_);
            image.DrawString(message, drawFont, drawBrush, drawRect_);
            }
                //_pictureBox1.Size = bmp.Size;
                _pictureBox1.Height = bmp.Height;
                _pictureBox1.BackgroundImage = bmp;
        }


        #region ButtonManagment

        private void StartInit()
        {
            _richTextBox.Enabled = false;
            _butStop.Visible = true;
            _butStartAll.Visible = false;
            _butStepByStep.Visible = false;
            _buttonBreak.Visible = true;
        }

        private void butStepByStep_Click(object sender, EventArgs e)
        {
            if ( !String.IsNullOrWhiteSpace( _richTextBox.Text ) )
            {
                StartInit();
                _currentLineTextBox.Visible = true;
                _butContinue.Visible = true;

                // Start engine
                _engine.SourceCode = _richTextBox.Text;
                _engine.Start();
            }
        }

        private void butStartAll_Click(object sender, EventArgs e)
        {
            if( !String.IsNullOrWhiteSpace( _richTextBox.Text ) )
            {
                StartInit();
                // Start engine
                _engine.SourceCode = _richTextBox.Text;
                _engine.Start();
                _myTimer.Start();
            }

        }

        void TimerEventProcessor( Object myObject, EventArgs myEventArgs )
        {
            for ( int i = 0 ; i < 6000 ; ++i )
            {
                if ( !_engine.NextInstruction() || !_engine.IsRunning )
                {
                    EndExecution();                    
                    break;
                }
            }
        }

        private void butContinue_Click(object sender, EventArgs e)
        {           
            _currentLineTextBox.Text = "Current Instruction " + _engine.Ctx.Stack.LastFrame.CurrentInstruction.ToString() + " at line " + _engine.Ctx.Stack.LastFrame.CurrentInstruction.Line;
            
            _engine.NextInstruction();
            
            // Et MaJ de la Stack
            if (_engine.IsRunning)
            {
                UpdateStack( _engine.GetStack() );
            }

            // HighLight current instruction support
        }

        private void _buttonBreak_Click( object sender, EventArgs e )
        {
            _myTimer.Stop();
            _buttonBreak.Visible = false;
            _butContinue.Visible = true;
            _buttonContinueRun.Visible = true;
            _currentLineTextBox.Visible = true;
        }

        private void _buttonContinueRun_Click( object sender, EventArgs e )
        {
            _buttonBreak.Visible = true;
            _buttonContinueRun.Visible = false;
            _butContinue.Visible = false;
            _currentLineTextBox.Visible = false;
            _myTimer.Start();
        }
        
        private void butStop_Click(object sender, EventArgs e)
        {
            EndExecution();
            _pictureBox2.Refresh();
        }
        private void EndExecution()
        {
            _butStartAll.Visible = true;
            _butStepByStep.Visible = true;
            _butContinue.Visible = false;
            _butStop.Visible = false;
            _buttonContinueRun.Visible = false;
            _buttonBreak.Visible = false;
            _buttonBreak.Visible = false;
            _richTextBox.Enabled = true;
            _currentLineTextBox.Visible = false;
            _pictureBox1.Refresh();
            _myTimer.Stop();
            _engine.Stop();
            Console.Clear();
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
               // if ( _engine.IsRunning && lineNumber == _engine.Ctx.Stack.LastFrame.CurrentInstruction.Line )
                //{
                  //  g.DrawString( "->", this._richTextBox.Font, Brushes.Black, leftMargin, lineY );
                //}
                //else
                //{
                    g.DrawString( lineNumberLabel, this._richTextBox.Font, Brushes.Black, leftMargin, lineY );
                //}
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
        #endregion

        #region Graphics managment

        /// <summary>
        /// Split Vertical and redraw in the pictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (_engine.IsRunning)
            {
                UpdateStack(_engine.GetStack());
            }

        }
    
        /// <summary>
        /// Split Horizontal and redraw in the pictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (_engine.IsRunning)
            {
                UpdateStack(_engine.GetStack());
            }   
            API_Canvas.ReDraw();
        }

        /// <summary>
        /// Update the event of split vertical and horizontal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            splitContainer1.Invalidate();
            splitContainer2.Invalidate();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cil_Cowding_Resize(object sender, EventArgs e)
        {
            if (_engine.IsRunning)
            {
                UpdateStack(_engine.GetStack());
            }
            _pictureBox1.Width = panel1.Width;
            _pictureBox1.Height = panel1.Height;
            
        }

        private void TextEditor_Load(object sender, EventArgs e)
        {
            // Required properties
            this._richTextBox.ScrollBars = RichTextBoxScrollBars.Both;
            this._richTextBox.WordWrap = false;
            _richTextBox.AcceptsTab = true;

            // Required events
            this._richTextBox.SelectionChanged += new System.EventHandler(this.richTextBox_SelectionChanged);
            this._richTextBox.VScroll += new System.EventHandler(this.richTextBox_VScroll);
            this._panelNum.Paint += new PaintEventHandler(this.panelNum_Paint);
            this._pictureBox1.Paint += new PaintEventHandler(this._pictureBox1_Paint);
            this.splitContainer2.SplitterMoved += new SplitterEventHandler(this.splitContainer2_SplitterMoved);
            this.splitContainer1.SplitterMoved += new SplitterEventHandler(this.splitContainer2_SplitterMoved);
            
        }

        private void _pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            splitContainer1.Invalidate();
            splitContainer2.Invalidate();
        }
        #endregion


    }
       
}