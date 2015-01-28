using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace System
{
    public static class API_Canvas
    {
        static PictureBox _canvas;
        static Graphics _graphics;

        static Pen _pen;
        
        static int _x;
        static int _y;

        #region Pen_is_my_name
        public static Color PenColor
        {
            set { _pen.Color = value; }
        }
        public static Single PenWidth
        {
            set { _pen.Width = value; }
        }
        #endregion

        public static void Init(PictureBox canvas)
        {
            _x = 0;
            _y = 0;
            _canvas = canvas;
            _graphics = _canvas.CreateGraphics();
            _pen = new Pen( Color.Black );
        }

        
        public static void DrawLine(int x1, int y1, int x2, int y2)
        {
            _graphics.DrawLine( _pen, x1, y1, x2, y2 );
        }


        public static void PlacePoint(int x, int y)
        {
            _x = x;
            _y = y;
        }
        
        public static void MoveTo(int x, int y)
        {
            _graphics.DrawLine(_pen, _x, _y, x, y);

            // On met à jour nos coordonnées
            _x = x;
            _y = y;

            // A FINI :D
            // Hum... très étrange cette façon de faire, on dirait qu'on gère un pinceau ^^ 
            // Mais bon carrément chelou otd
            // What ?? De quoi tu parles mon gars ? xD
        }


        public static void DrawPixel(int x, int y) {
            //_graphics.DrawLine(_pen, x, y, x + 1, y + 1);
            _graphics.DrawRectangle(_pen, x, y, 1, 1);
        }
        public static void DrawPixel(double x, double y)
        {
            //_graphics.DrawLine(_pen, x, y, x + 1, y + 1);
            _graphics.DrawRectangle(_pen, (int)x, (int)y, 1, 1);
        }

        public static void Clear()
        {
            _canvas.Refresh();  // On efface tout // Oui vu le nom de la fonction on peut s'en douter :p
        }


        public static void ReDraw() 
        {
            _canvas.Invalidate();
        }
    
    }
}
