using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Drawing = System.Drawing;

namespace Cyotek.Windows.Forms.Demo
{
  public class MyImageBox:ImageBox
  {

    private Drawing.RectangleF _dragRectangle = new Drawing.RectangleF();
    private Drawing.Point _dragOffset;
    private bool _isDragging;
    public MyImageBox()
    {

    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      Drawing.Point imagePoint = this.PointToImage(e.Location);
      if (_dragRectangle.Contains(imagePoint) && e.Button == MouseButtons.Left)
      {
        _isDragging = true;
        _dragOffset = new Drawing.Point(imagePoint.X - (int)_dragRectangle.Location.X, imagePoint.Y - (int)_dragRectangle.Location.Y);
      }
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      Drawing.Point imagePoint = this.PointToImage(e.Location, true);
      this.Cursor = _dragRectangle.Contains(imagePoint) ? Cursors.SizeAll : Cursors.Default;
      if (_isDragging)
      {
        int x = Math.Max(0, imagePoint.X - _dragOffset.X);
        int y = Math.Max(0, imagePoint.Y - _dragOffset.Y);
        //if(x+_dragRectangle.Width>=this.VirtualSize.Width)
        //{

        //}
        _dragRectangle.Location = new Drawing.PointF(x, y);
        this.Invalidate();
      }
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      _isDragging = false;
    }
    protected override void OnSelecting(ImageBoxCancelEventArgs e)
    {
      if (_dragRectangle.Contains(this.PointToImage(e.Location)))
      {
        e.Cancel = true;
      }
    }
    protected override void OnSelectionRegionChanged(EventArgs e)
    {
      base.OnSelectionRegionChanged(e);
      if (!this.SelectionRegion.IsEmpty)
      {
        _dragRectangle = this.SelectionRegion;
        this.SelectionRegion = Drawing.RectangleF.Empty;
      }
    }

  }
}
