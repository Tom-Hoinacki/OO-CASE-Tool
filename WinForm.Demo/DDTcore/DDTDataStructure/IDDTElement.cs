﻿/*
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
using System.Text;

namespace DDT
{
    public abstract class IDDTElement
    {
       public int ID;

       public IDDTElement()
       {
           ID = staticId.getid();
       }
 
    }
}
