//To localize the descriptions see http://groups.google.be/group/microsoft.public.dotnet.languages.csharp/browse_thread/thread/3bb6895b49d7cbe/e3241b7fa085ba90?lnk=st&q=csharp+attribute+resource+file&rnum=4#e3241b7fa085ba90
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
namespace Netron.NetronLight
{
    [Serializable()]
    public class Document
    {
        #region Fields
        private IModel mModel;
        #endregion

        #region Properties
        [Browsable(true), Description("The background color of the canvas if the type is set to 'flat'"), Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BackColor
        {
            get { return mModel.Ambience.BackgroundColor; }
            set { mModel.Ambience.BackgroundColor = value; }
        }

        [Browsable(true), Description("The background type"), Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public CanvasBackgroundTypes BackgroundType
        {
            get { return mModel.Ambience.BackgroundType; }
            set { mModel.Ambience.BackgroundType = value; }
        }


        private DocumentInformation mInformation;
        public DocumentInformation Information
        {
            get { return mInformation; }
            set { mInformation = value; }
        }

        
        public IModel Model
        {
            get { return mModel; }
        }

        #endregion 

        #region Constructor
        public Document(IModel model)
        {
            mModel = model;
        }
        #endregion
        
        #region Methods

        #endregion

    }
}
