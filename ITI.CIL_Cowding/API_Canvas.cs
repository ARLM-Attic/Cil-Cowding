using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace ITI.CIL_Cowding
{
    public static class API_Canvas
    {
        static PictureBox _canvas;
        static int _x;
        static int _y;

        public static void Init(PictureBox canvas)
        {
            _canvas = canvas;
            
        }


        public static void PlacePoint(int x, int y)
        {
            _x = x;
            _y = y;


        }
        
        public static void MoveTo(int x, int y)
        {

            // On fait nos petits traits traits
            Pen p = new Pen( Color.Black, 2f);
            Graphics g = _canvas.CreateGraphics();
            g.DrawLine(p, _x, _y, x, y);

            // On met à jour nos coordonnées
            _x = x;
            _y = y;

            // A FINI :D
        }

        public static void Clear()
        {
            _canvas.Refresh();  // On efface tout

        }

        public static void ReDraw() {
            _canvas.Invalidate();
        }
    }
}
