/*
 * CECS 543 Spring 2011
 * Team Number 1:
 *   Philip Brack(project Manager)
 *   Tom Hoinacki
 *   Ayan Kar
 *   Ravi Mahana
 *   Michael Ngo
 *   Panos Zoumpoulidis
 *   Yang Zhao
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDT
{
    class DDTTabPage:System.Windows.Forms.TabPage
    {
        public DDT_Diagram_Type type;
        public int ID;
        public DDTTabPage(DDT_Diagram_Type type)
            : base()
        {

            this.type = type;
        }
        
        public DDTTabPage(int id)
            : base() { ID = id; }

        public DDTTabPage() : base() { }
    
    }
}
