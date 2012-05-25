using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Netron.NetronLight 
{
    public interface IDDTDiagramEntity : IDiagramEntity
    {
      void OnDoubleClick(MouseEventArgs e);
      void OnRightDoubleClick(MouseEventArgs e);
      void OnRightClick(MouseEventArgs e);
     
      string getText();
      Point getLocation();
    }
}
