using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Netron.NetronLight 
{
    public enum LineType { NORMAL, HIGHLIGHTED}
    public enum ConnectionType { NORMAL, SINGLEARROW, DOUBLEARROW, ONETOONE,ONETOMANY,MANYTOMANY,DIAMONDARROW,WIDEARROW,DASHEDARROW }
    public static class ConnectionPenFactory
    {

        public static Pen getConnection(LineType LineType, ConnectionType ConnectionType, Graphics g)
        {
            Pen pen = ConnectionPen.getConnection(ConnectionType, g);

            switch (LineType) 
            {
                case LineType.NORMAL: //normal
                    ConnectionPen.setPen(Color.Black, 1.3F);
                    break;
                case LineType.HIGHLIGHTED:
                    ConnectionPen.setPen(Color.Red, 2F);
                    break;
                default:
                    ConnectionPen.setPen(Color.Blue, 1.5F);
                    break;
            }
            return pen ;
        }

    }
}
