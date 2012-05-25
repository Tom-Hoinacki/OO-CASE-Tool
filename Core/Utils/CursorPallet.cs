using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
namespace Netron.NetronLight
{
    static class CursorPallet
    {
        #region Fields
        private const string NameSpace = "Netron.NetronLight";
        private static Cursor mGrip = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream(NameSpace + ".Resources.Grip.cur"));
        private static Cursor mAdd = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream(NameSpace + ".Resources.Add.cur"));
        private static Cursor mCross = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream(NameSpace + ".Resources.Cross.cur"));
        private static Cursor mMove = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream(NameSpace + ".Resources.Move.cur"));
        private static Cursor mSelection = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream(NameSpace + ".Resources.Selection.cur"));
        private static Cursor mSelect = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream(NameSpace + ".Resources.Select.cur"));
        private static Cursor mDropText = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream(NameSpace + ".Resources.DropText.cur"));
        private static Cursor mDropShape = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream(NameSpace + ".Resources.DropShape.cur"));
        private static Cursor mDropImage = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream(NameSpace + ".Resources.DropImage.cur"));
        

        #endregion 

        #region Properties

        public static Cursor DropImage
        {
            get
            {
                return mDropImage;
            }
        }
        public static Cursor DropText
        {
            get
            {
                return mDropText;
            }
        }
        public static Cursor DropShape
        {
            get
            {
                return mDropShape;
            }
        }
        public static Cursor Grip
        {
            get
            {
                return mGrip;
            }
        }
        public static Cursor Add
        {
            get
            {
                return mAdd;
            }
        }

        public static Cursor Cross
        {
            get
            {
                return mCross;
            }
        }

        public static Cursor Move
        {
            get
            {
                return mMove;
            }
        }

        public static Cursor Selection
        {
            get
            {
                return mSelection;
            }
        }

        public static Cursor Select
        {
            get
            {
                return mSelect;
            }
        }
        #endregion

    }
}
