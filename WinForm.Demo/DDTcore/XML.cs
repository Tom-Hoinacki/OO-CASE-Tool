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
    /// <summary>
    /// The XML class contains two static methods to load projects from file,
    /// and save projects to file.
    /// </summary>
    class XML
    {
        public static DDTProject deserialize(string filename) //XML save the entire Project object
        {
            DDTProject newProject = null; // a new Project object will be empty when created
            try
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(DDTProject)); //perform serializer on project
                System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open);//file stream using filename (ie Project object name selected)
                newProject = (DDTProject)x.Deserialize(fs);// a new project will be able to receive and output all information stored to it
                fs.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return newProject;
        }



        public static void serialize(DDTProject pIn, string filename)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(pIn.GetType());
                System.IO.TextWriter file = new System.IO.StreamWriter(filename);
                x.Serialize(file, pIn);
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
