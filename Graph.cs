using System.Drawing;

namespace bitmapGen
{
  class Graph
  {
    private Bitmap _bm;
    private Graphics _g;
    private SolidBrush _sb;
    private const int _graphSize = 2650;
    private const int _dotSize = 50;
    private const int _edge = 4;
    private const int _offset = 50;
    private Color[] _col = new Color[7];
    public Graph()
    {
      _bm = new Bitmap(_graphSize, _graphSize);
      _g = Graphics.FromImage(_bm);
      _sb = new SolidBrush(_col[0]);
      _g.FillRectangle(Brushes.WhiteSmoke, _g.VisibleClipBounds);
      _col[0] = Color.Black;
      _col[1] = Color.Purple;
      _col[2] = Color.Blue;
      _col[3] = Color.Orange;
      _col[4] = Color.Green;
      _col[5] = Color.Yellow;
      _col[6] = Color.Red;
    }

    public void plotData(Data data)
    {
      _sb = new SolidBrush(_col[0]);
      _g.FillRectangle(_sb, _offset + intPos(data.x) - _edge, _offset + intPos(data.y) - _edge, _dotSize + 2 * _edge, _dotSize + 2 * _edge);
      _sb = new SolidBrush(_col[data.label]);
      _g.FillRectangle(_sb, _offset + intPos(data.x), _offset + intPos(data.y), _dotSize, _dotSize);
    }
    public void saveImg(string name)
    {
      _bm.Save(name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
    }
    private int intPos(float p)
    {
      return (int)(p * 100.0);
    }
  }
}
