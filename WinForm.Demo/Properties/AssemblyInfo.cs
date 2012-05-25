/// A 'light' version of the Netron graph control
/// without all the advanced diagramming stuff
/// see however http://www.netronproject.com for more info.
/// 
/// This control shows the simplicity with which you can still achieve good results,
/// it's a toy-model to explore and can eventually help you if you want to go for a 
/// bigger adventure in the full Netron control.
/// 
/// Question and comments are welcome via the forum of The Netron Project or mail me
/// [Francois.Vanderseypen@netronproject.com]
/// 
/// Thank you for downloading the code and your feedback!
/// 

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Resources;
using System;
using System.IO;
[assembly: AssemblyTitle("Netron Light 2006")]
[assembly: AssemblyDescription("A lighter version of the Netron diagramming library for .Net 2.0")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("The Netron Project [http://www.netronproject.com]")]
[assembly: AssemblyProduct("Netron Light")]
[assembly: AssemblyCopyright("Open Source")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]		


[assembly: AssemblyVersion("2.4.*")]

[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]
[assembly: ComVisibleAttribute(false)]
[assembly: NeutralResourcesLanguageAttribute("en-US")]

/// <summary>
/// Static class which collects info about the graph library assembly
/// </summary>
static class AssemblyInfo
{

    static string binPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\";
     const string AssemblyName = "Netron.NetronLight.dll";
    #region Assembly Attribute Accessors

  

    /// <summary>
    /// Gets the assembly title.
    /// </summary>
    /// <value>The assembly title.</value>
    public static string AssemblyTitle
    {
        get
        {
            Assembly embly = Assembly.LoadFile(binPath + AssemblyName);
            // Get all Title attributes on this assembly
            object[] attributes = embly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            // If there is at least one Title attribute
            if(attributes.Length > 0)
            {
                // Select the first one
                AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute) attributes[0];
                // If it is not an empty string, return it
                if(titleAttribute.Title != "")
                    return titleAttribute.Title;
            }
            // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
            return System.IO.Path.GetFileNameWithoutExtension(embly.CodeBase);
        }
    }

    /// <summary>
    /// Gets the assembly version.
    /// </summary>
    /// <value>The assembly version.</value>
    public static string AssemblyVersion
    {
        get
        {

            Assembly embly = Assembly.LoadFile(binPath + AssemblyName);
            return embly.GetName().Version.ToString();
        }
    }

    /// <summary>
    /// Gets the assembly description.
    /// </summary>
    /// <value>The assembly description.</value>
    public static string AssemblyDescription
    {
        get
        {

            Assembly embly = Assembly.LoadFile(binPath + AssemblyName);
            // Get all Description attributes on this assembly
            object[] attributes = embly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            // If there aren't any Description attributes, return an empty string
            if(attributes.Length == 0)
                return "";
            // If there is a Description attribute, return its value
            return ((AssemblyDescriptionAttribute) attributes[0]).Description;
        }
    }

    /// <summary>
    /// Gets the assembly product.
    /// </summary>
    /// <value>The assembly product.</value>
    public static string AssemblyProduct
    {
        get
        {
            Assembly embly = Assembly.LoadFile(binPath + AssemblyName);
            // Get all Product attributes on this assembly
            object[] attributes = embly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            // If there aren't any Product attributes, return an empty string
            if(attributes.Length == 0)
                return "";
            // If there is a Product attribute, return its value
            return ((AssemblyProductAttribute) attributes[0]).Product;
        }
    }

    /// <summary>
    /// Gets the assembly copyright.
    /// </summary>
    /// <value>The assembly copyright.</value>
    public static string AssemblyCopyright
    {
        get
        {
            Assembly embly = Assembly.LoadFile(binPath + AssemblyName);
            // Get all Copyright attributes on this assembly
            object[] attributes = embly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            // If there aren't any Copyright attributes, return an empty string
            if(attributes.Length == 0)
                return "";
            // If there is a Copyright attribute, return its value
            return ((AssemblyCopyrightAttribute) attributes[0]).Copyright;
        }
    }

    /// <summary>
    /// Gets the assembly company.
    /// </summary>
    /// <value>The assembly company.</value>
    public static string AssemblyCompany
    {
        get
        {
            Assembly embly = Assembly.LoadFile(binPath + AssemblyName);
            // Get all Company attributes on this assembly
            object[] attributes = embly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            // If there aren't any Company attributes, return an empty string
            if(attributes.Length == 0)
                return "";
            // If there is a Company attribute, return its value
            return ((AssemblyCompanyAttribute) attributes[0]).Company;
        }
    }
    #endregion

}
