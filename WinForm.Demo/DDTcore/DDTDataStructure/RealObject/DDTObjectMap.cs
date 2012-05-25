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
    /// The DDTObjectMap allows us to go between a Cobject and the DDTObject "representing" it.
    /// </summary>
    public class DDTObjectMap
    {
        public int oId;
        public int ddtOId;
        public DDTObjectMap() { }
        public DDTObjectMap(int oId, int ddtOId)
        {
            this.oId = oId;
            this.ddtOId = ddtOId;
        }
    }
}