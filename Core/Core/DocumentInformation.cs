using System;
using System.Collections.Generic;
using System.Text;

namespace Netron.NetronLight
{
    public class DocumentInformation 
    {

        #region Fields
        
        #endregion

        #region Properties
        private string mAuthor;
        public string Author
        {
            get { return mAuthor; }
            set { mAuthor = value; }
        }


        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        private string mTitle;
        public string Title
        {
            get { return mTitle; }
            set { mTitle = value; }
        }

        private string mCreationDate;
        public string CreationDate
        {
            get { return mCreationDate; }
            set { mCreationDate = value; }
        }


        #endregion
        #region Constructor
        public DocumentInformation()
        {
        	
        }
        #endregion
  

       

 
    }
}
