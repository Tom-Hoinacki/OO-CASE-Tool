using System;
using System.Collections.Generic;
using System.Text;

namespace Netron.NetronLight
{
    //http://www.theserverside.net/blogs/showblog.tss?id=pluginArchitectures
    //http://www.martinfowler.com/articles/injection.html
    //http://www.codeproject.com/csharp/components.asp
    public interface ITool : IServiceProvider
    {

        bool Enabled { get; set; }

        string Name { get; set; }

        bool IsActive { get; set;}

        bool CanActivate { get; }

        bool DeactivateTool();

        bool ActivateTool();


        bool IsSuspended { get; set;}
    }

    
}
