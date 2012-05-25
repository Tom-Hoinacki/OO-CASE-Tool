#region Copyright � 2007 Rotem Sapir
/*
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from the
 * use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not claim
 * that you wrote the original software. If you use this software in a product,
 * an acknowledgment in the product documentation is required, as shown here:
 *
 * Portions Copyright � 2007 Rotem Sapir
 *
 * 2. No substantial portion of the source code of this library may be redistributed
 * without the express written permission of the copyright holders, where
 * "substantial" is defined as enough code to be recognizably from this library.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Text;

namespace TreeGenerator
{
    public class NodePos
    {
        public NodePos()
        {
            //throw new System.NotImplementedException();
        }
        private string _NodeID;

        public string NodeID
        {
            get { return _NodeID; }
            set { _NodeID = value; }
        }
        private System.Drawing.RectangleF _NodePosition;

        public System.Drawing.RectangleF NodePosition
        {
            get { return _NodePosition; }
            set { _NodePosition = value; }
        }
        
        
    }
}
