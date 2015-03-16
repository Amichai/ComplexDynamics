using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PlotTools {
    public class CartesianCanvas {
        public CartesianCanvas(int width, int height, int pixelWidth, int pixelHeight)
            : this(0, 0, width, height, pixelWidth, pixelHeight) {
        }

        public CartesianCanvas(int xMin, int yMin, int width, int height, int pixelWidth, int pixelHeight) {
            this.XMin = xMin;
            this.YMin = yMin;
            this.CanvasWidth = width;
            this.CanvasHeight = height;
            this.pixelWidth = pixelWidth;
            this.pixelHeight = pixelHeight;
            this.bitmap = BitmapFactory.New(pixelWidth, pixelHeight);
            this.bitmap.FillRectangle(0, 0, pixelWidth, pixelHeight, Colors.LightGray);
        }
        public int XMin { get; private set; }
        public int YMin { get; private set; }
        public int CanvasWidth { get; private set; }
        public int CanvasHeight { get; private set; }
        private int pixelWidth, pixelHeight;

        public int XMax {
            get {
                return XMin + CanvasWidth;
            }
        }

        public int YMax {
            get {
                return YMin + CanvasHeight;
            }
        }

        private WriteableBitmap bitmap;

        private int transformX(double x) {
            return (((x - this.XMin) / (double)this.CanvasWidth) * this.pixelWidth).Round();
        }

        private int transformY(double y) {
            return (((this.CanvasHeight - (y - this.YMin)) * (this.pixelHeight / (double)this.CanvasHeight))).Round();
        }

        public void FillSquare(double x1, double y1, int sideInPixels, Color color) {
            int _x1 = transformX(x1);
            int _x2 = _x1 + sideInPixels;
            int _y1 = transformY(y1);
            int _y2 = _y1 + sideInPixels;
            if (_y2 < _y1) {
                int t = _y1;
                _y1 = _y2;
                _y2 = t;
            }
            int half = sideInPixels / 2;
            bitmap.FillRectangle(_x1 - half, _y1 - half, _x2 - half, _y2 - half, color);
        }

        public void FillRectangle(double x1, double y1, double x2, double y2, Color color) {
            int _x1 = transformX(x1);
            int _x2 = transformX(x2);
            int _y1 = transformY(y1);
            int _y2 = transformY(y2);
            if (_y2 < _y1) {
                int t = _y1;
                _y1 = _y2;
                _y2 = t;
            }
            bitmap.FillRectangle(_x1, _y1, _x2, _y2, color);
        }

        public void DrawLine(double x1, double y1, double x2, double y2, Color color) {
            int _x1 = transformX(x1);
            int _x2 = transformX(x2);
            int _y1 = transformY(y1);
            int _y2 = transformY(y2);
            bitmap.DrawLine(_x1, _y1, _x2, _y2, color);
        }

        public void ShowDialog() {
            var ctrl = new Image();
            ctrl.Source = bitmap;
            ctrl.ShowDialog();
        }
    }
}
