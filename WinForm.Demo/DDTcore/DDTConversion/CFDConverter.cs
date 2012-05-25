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
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace DDT
{
    public static class CFDConverter
    {
        public static void displayTable(DDTDiagram cfd)
        {
            /*
            DataGridView stt = new DataGridView();
            stt.DataSource = getSTT(cfd);

            // want to make our DataGridView look good.
            stt.ReadOnly = true;
            stt.AutoResizeColumns();
            stt.AutoResizeRows();
            stt.AutoSize = true;
            /*
            int width = 0;
            foreach (DataGridViewColumn c in stt.Columns)
            {
                //c.Width = 200;
                width += c.Width;
            }
            int fixedWidth = width;
            stt.Width = fixedWidth;
            stt.Height = 200*stt.RowCount;// stt.GetRowDisplayRectangle(stt.NewRowIndex, true).Bottom + stt.GetRowDisplayRectangle(stt.NewRowIndex, false).Height;
            */

           // Form newForm = new Form();
           // stt.Dock = DockStyle.Fill;
           
            
 
            /*
         
            newForm.Controls.Add(stt);
            newForm.Size = stt.Size;
            newForm.BackColor = Color.White;
            newForm.Show();

             */
            Netron.NetronLight.Demo.STTForm newform = new Netron.NetronLight.Demo.STTForm();
            newform.dataGridView1.DataSource = getSTT(cfd);
            newform.dataGridView1.ReadOnly = true;
            newform.Show();
        }


      

        static DataTable getSTT(DDTDiagram cfd)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Present State", typeof(string));
            table.Columns.Add("Event", typeof(string));
            table.Columns.Add("Action", typeof(string));
            table.Columns.Add("Next State", typeof(string));

            
            // TODO Panos- add more logic.
 

            foreach (int relationID in cfd.RelIDList)
            {
                DataRow newRow = table.NewRow();

                // get Relation
                DDTRelation relation = DDTHelper.manager.project.getDDTRelation(relationID);

                // get source name
                string presentState = DDTHelper.manager.project.getDDTObject(relation.from.objectId).name;
                string eventName = relation.text.from;
                string actionName = relation.text.middle;
                string nextState = DDTHelper.manager.project.getDDTObject(relation.to.objectId).name;
                // get destination name

                newRow["Present State"] = presentState;
                newRow["Event"] = eventName;
                newRow["Action"] = actionName;
                newRow["Next State"] = nextState;

                table.Rows.Add(newRow);
            }
            return table;
        }




        /// <summary>
        /// Function to sort a DataTable.  newForm can be used to format our converted STT nicely.
        /// For example AlphabeticSort((DataTable)stt.DataSource, 0, "Present State");
        /// would sort Panos' orignal chart in a nice way.
        /// </summary>
        /// <param name="dtTable">table to sort</param>
        /// <param name="sortOrder">see switch statement for meanings</param>
        /// <param name="columnName">What column to sort by</param>
        /// <returns></returns>
        private static DataTable AlphabeticSort(DataTable dtTable, int sortOrder, string columnName)
        {
            DataSet dsSorted = new DataSet();
            string columnKey = "TabName";
            string sortDirection = "";
            string sortFormat = "{0} {1}";
            switch (sortOrder)
            {
                case 0:
                    sortDirection = "ASC";
                    break;
                case 1:
                    sortDirection = "DESC";
                    break;
                default:
                    sortDirection = "ASC";
                    break;
            }
            dtTable.DefaultView.Sort = string.Format(sortFormat, columnKey, sortDirection);
            return dtTable.DefaultView.Table;
        }


    }
}
