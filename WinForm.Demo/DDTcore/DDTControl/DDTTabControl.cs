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
using System.Windows.Forms;

namespace DDT
{
    class DDTTabControl:System.Windows.Forms.TabControl
    {
        public DDT_Diagram_Type diagramType;
        public List<TabPage> CreatedTabpages = new List<TabPage>();
        public DDTTabControl(DDT_Diagram_Type type)
            : base()
        {
            this.diagramType = type;
        }
        
        public DDTTabControl()
            : base() { }
        

        public void savePage(TabPage tp)
        {

            CreatedTabpages.Add(tp);
        
        }


        public void removePage(TabPage tp)
        {
            CreatedTabpages.Remove(tp);

        }


        public void removeAllPages()
        {
            CreatedTabpages.Clear();

        }

         
    }
}
