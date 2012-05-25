using System;
using System.Collections.Generic;
using System.Text;

namespace Netron.NetronLight.Win
{
    class Controller : ControllerBase
    {

        #region Constructor
        public Controller(IDiagramControl surface) : base(surface)
        {
            //create the view
            View = new View(surface);
            View.AttachToModel(Model);
        }
        #endregion
  
    }
}
