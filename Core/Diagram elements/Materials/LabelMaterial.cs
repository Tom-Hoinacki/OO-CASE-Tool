using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace Netron.NetronLight
{
    public class LabelMaterial :  AbstractMaterial
    {
        #region Fields
        private string mText;

        private StringFormat stringFormat = StringFormat.GenericTypographic;
        #endregion

        #region Properties
        public string Text
        {
            get
            {
                return mText;
            }
            set
            {
                mText = value;
            }
        }
        #endregion


        #region Constructor
        public LabelMaterial() : base()
        {
            stringFormat.Trimming = StringTrimming.EllipsisWord;
            stringFormat.FormatFlags = StringFormatFlags.LineLimit;
        }
        #endregion
  

        #region Methods

        public override void Paint(System.Drawing.Graphics g)
        {
            if (!Visible) return;            
            //the text		
        if(!string.IsNullOrEmpty(Text))
        {
            //g.DrawRectangle(Pens.Orange, Rectangle);

            g.DrawString(Text, ArtPallet.DefaultFont, Brushes.Black, Rectangle, stringFormat);
        }
        }
        #endregion

    }
}
