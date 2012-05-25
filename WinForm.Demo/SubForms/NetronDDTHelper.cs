using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Netron.NetronLight.Demo
{
    public static class NetronDDTHelper
    {
        private static Netron.NetronLight.DDTConnection DDTConnection;
        private static Netron.NetronLight.IDDTObject IDDT;

        public static Netron.NetronLight.DDTConnection getDDTConnection()
        {
            Netron.NetronLight.DDTConnection temp = DDTConnection;
           // DDTConnection = null;
            return temp;
        }
        public static void setDDTConnection(Netron.NetronLight.DDTConnection conn)
        {
            DDTConnection = conn;
        }



        public static Netron.NetronLight.IDDTObject getIDDTObject()
        {
            Netron.NetronLight.IDDTObject temp = IDDT;
            //IDDT = null;
            return temp;
        }
        public static void setIDDTObject(Netron.NetronLight.IDDTObject obj)
        {
            IDDT = obj;
        }
    }
}
