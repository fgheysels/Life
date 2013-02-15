using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Life.Domain;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Life
{
    class UniverseDrawer
    {
        private readonly Canvas _canvas;

        public UniverseDrawer( Canvas c )
        {
            _canvas = c;
        }

        private Bitmap b;
        private WriteableBitmap wb;

        public void DrawUniverse( Universe u )
        {
//            if( wb == null )
//            {
//                //b = new Bitmap ((int)_canvas.ActualWidth, (int)_canvas.ActualHeight, System.Drawing.Imaging.PixelFormat.DontCare);
                

//                int cellWidth = (int)_canvas.ActualWidth / u.DimensionX;
//                int cellHeight = (int)_canvas.ActualHeight / u.DimensionY;

//                wb = new WriteableBitmap ((int)_canvas.ActualWidth, (int)_canvas.ActualHeight, 96, 96, PixelFormats.Bgr32, BitmapPalettes.WebPalette);

//                for( int row = 0; row <= u.DimensionY; row++ )
//                {
//                    for( int column = 0; column <= u.DimensionX; column++ )
//                    {
//                        var color = u.GetCellAt (row, column).State == CellState.Alive ? System.Drawing.Color.Green : System.Drawing.Color.Black;

//                        //for( int j = 0; j < cellWidth; j++ )
//                       // {
//                        //    for( int k = 0; k < cellHeight; k++ )
//                         //   {
//                                wb.WritePixels(new Int32Rect(column * cellWidth, row * cellWidth, cellWidth, cellHeight), 
//                           //     wb. SetPixel (row + 1, column + k, color);
//                           // }
//                        }
//                    }
//                }

                
////wb.
////                wb.Source = b;
//            }



            int cellWidth = (int)_canvas.ActualWidth / u.DimensionX;
            int cellHeight = (int)_canvas.ActualHeight / u.DimensionY;

            _canvas.Children.Clear ();

            for( int row = 0; row <= u.DimensionY; row++ )
            {
                for( int column = 0; column <= u.DimensionX; column++ )
                {
                    {
                        var cell = new System.Windows.Shapes.Rectangle ()
                        {
                            Width = cellWidth,
                            Height = cellHeight,
                            Fill = ( u.GetCellAt (row, column).State == CellState.Alive ) ? System.Windows.Media.Brushes.Green : System.Windows.Media.Brushes.Black
                        };

                        _canvas.Children.Add (cell);

                        Canvas.SetLeft (cell, cellWidth * column);
                        Canvas.SetTop (cell, cellHeight * row);
                    }
                }
            }
        }
    }
}
