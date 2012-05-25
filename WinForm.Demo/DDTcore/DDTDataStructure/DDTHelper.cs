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
    public static class DDTHelper
    {
        public static string savedPath = "";
        public static bool NewProj = true;
        public static bool Saved = false;
        public static DDTProjectDrawingManagement manager;
        public static void initialize(DDTProject project)
        {
            if (project == null)
            {
                manager = new DDTProjectDrawingManagement(new DDTProject());
            }
            else
            {
                manager = new DDTProjectDrawingManagement(project);
            }
        }

        public static void SAVED()
        {
            Saved = true;
        }

        public static void UNSAVED()
        {
            Saved = false;
        }
    }
}
