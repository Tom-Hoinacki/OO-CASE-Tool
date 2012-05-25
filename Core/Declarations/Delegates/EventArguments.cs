using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
namespace Netron.NetronLight
{
    #region ConnectorAttachmentEventArgs
    public sealed class ConnectorAttachmentEventArgs : EventArgs
    {
        IConnector child;
        IConnector parent;
        IConnection connection;


        public IConnector Child
        {
            get
            {
                return child;
            }
        }

        public IConnector Parent
        {
            get
            {
                return parent;
            }
        }

        public IConnection Connection
        {
            get
            {
                return connection;
            }
        }

        public ConnectorAttachmentEventArgs(IConnector child, IConnector parent, IConnection connection)
        {
            this.child = child;
            this.parent = parent;
            this.connection = connection;
        }
    }
    #endregion

    #region EntityMenuEventArgs
    public sealed class EntityMenuEventArgs : EventArgs
    {
        #region Fields
        private IDiagramEntity entity;
        private MouseEventArgs e;
        private MenuItem[] additionalItems;
        #endregion;

        #region Properties
        public IDiagramEntity Entity
        {
            get
            {
                return entity;
            }
        }

        public MouseEventArgs MouseEventArgs
        {
            get
            {
                return e;
            }
        }

        public MenuItem[] AdditionalItems
        {
            get
            {
                return additionalItems;
            }
        }

        #endregion

        #region Constructor
        public EntityMenuEventArgs(IDiagramEntity entity, MouseEventArgs e, ref MenuItem[] additionalItems)
        {
            this.entity = entity;
            this.e = e;
            this.additionalItems = additionalItems;
        }
        #endregion

    }
    #endregion

    #region CursorEventArgs
    public sealed class CursorEventArgs : EventArgs
    {
        public static readonly new CursorEventArgs Empty = new CursorEventArgs();
        private Cursor mCursor;
        public Cursor Cursor
        {
            get
            {
                return mCursor;
            }
            set
            {
                mCursor = value;
            }
        }



        #region Constructor
        public CursorEventArgs(Cursor cursor)
        {
            this.mCursor = cursor;
        }
        public CursorEventArgs()
        {
        }
        #endregion

    }
    #endregion

    #region ToolEventArgs
    public sealed class ToolEventArgs : EventArgs
    {

        private ITool mTool;
        public ITool Properties
        {
            get
            {
                return mTool;
            }
            set
            {
                mTool = value;
            }
        }
        public static readonly new ToolEventArgs Empty = new ToolEventArgs();

        #region Constructor
        public ToolEventArgs(ITool tool)
        {
            this.mTool = tool;
        }
        public ToolEventArgs()
        {
        }
        #endregion

    }
    #endregion

    #region PropertiesEventArgs
    public sealed class PropertiesEventArgs : EventArgs
    {

        private Document mProperties;
        public Document Properties
        {
            get
            {
                return mProperties;
            }
            set
            {
                mProperties = value;
            }
        }
        public static readonly new PropertiesEventArgs Empty = new PropertiesEventArgs();

        #region Constructor
        public PropertiesEventArgs(Document document)
        {
            this.mProperties = document;
        }
        public PropertiesEventArgs()
        {
        }
        #endregion

    }
    #endregion

    #region AmbienceEventArgs
    public sealed class AmbienceEventArgs : EventArgs
    {


        private Ambience mAmbience;
        public Ambience Ambience
        {
            get
            {
                return mAmbience;
            }
            set
            {
                mAmbience = value;
            }
        }

        public static readonly new AmbienceEventArgs Empty = new AmbienceEventArgs();


        #region Constructor
        public AmbienceEventArgs()
        {

        }
        public AmbienceEventArgs(Ambience ambience)
        {
            this.mAmbience = ambience;
        }
        #endregion

    }
    #endregion

    #region ConnectionCollectionEventArgs
    public sealed class ConnectionCollectionEventArgs : EventArgs
    {

        private IConnection mConnection;
        public IConnection Connection
        {
            get
            {
                return mConnection;
            }
            set
            {
                mConnection = value;
            }
        }

        public static readonly new ConnectionCollectionEventArgs Empty = new ConnectionCollectionEventArgs();


        #region Constructor
        public ConnectionCollectionEventArgs()
        {

        }
        public ConnectionCollectionEventArgs(IConnection connection)
        {
            this.mConnection = connection;
        }
        #endregion

    }
    #endregion

    #region DiagramInformationEventArgs
    public sealed class DiagramInformationEventArgs : EventArgs
    {

        private DocumentInformation mInformation;
        public DocumentInformation Information
        {
            get
            {
                return mInformation;
            }
            set
            {
                mInformation = value;
            }
        }

        #region Constructor
        private DiagramInformationEventArgs()
        {

        }
        public DiagramInformationEventArgs(DocumentInformation info)
        {
            this.mInformation = info;
        }
        #endregion
        public static readonly new DiagramInformationEventArgs Empty = new DiagramInformationEventArgs();
    }
    #endregion

    #region RectangleEventArgs
    public sealed class RectangleEventArgs : EventArgs
    {
        private RectangleF mRectangle;

        public RectangleF Rectangle
        {
            get
            {
                return mRectangle;
            }
        }
        public static readonly new RectangleEventArgs Empty = new RectangleEventArgs();


        #region Constructor
        public RectangleEventArgs(RectangleF rectangle)
        {
            this.mRectangle = rectangle;
        }
        private RectangleEventArgs()
        {
        }
        #endregion

    }
    #endregion

    #region EntityEventArgs
    public sealed class EntityEventArgs : EventArgs
    {
        IDiagramEntity mEntity;

        public IDiagramEntity Entity
        {
            get
            {
                return mEntity;
            }
            set
            {
                mEntity = value;
            }
        }
        public EntityEventArgs(IDiagramEntity entity)
        {
            this.Entity = entity;
        }
    }
    #endregion

    #region EntityMouseEventArgs
    public sealed class EntityMouseEventArgs : MouseEventArgs
    {


        IDiagramEntity mEntity;

        public IDiagramEntity Entity
        {
            get
            {
                return mEntity;
            }
            set
            {
                mEntity = value;
            }
        }
        public EntityMouseEventArgs(IDiagramEntity entity, MouseButtons button, int clicks, int x, int y, int delta)
            : base(button, clicks, x, y, delta)
        {
            this.mEntity = entity;
        }
        public EntityMouseEventArgs(IDiagramEntity entity, MouseEventArgs e)
            : base(e.Button, e.Clicks, e.X, e.Y, e.Delta)
        {
            if(e == null)
                throw new ArgumentNullException("The argument object is 'null'");
            this.mEntity = entity;
        }
    }
    #endregion

    #region StringEventArgs
    public sealed class StringEventArgs : EventArgs
    {

        string mData;
        public string Data
        {
            get
            {
                return mData;
            }

        }
        public StringEventArgs(string data)
        {
            this.mData = data;
        }
    }
    #endregion

    #region SingleDataEventArgs
    public sealed class SingleDataEventArgs<T> : EventArgs
    {
        T mData;

        public T Data
        {
            get
            {
                return mData;
            }
        }

        public SingleDataEventArgs(T data)
        {
            //if (data is default(T))
            //    throw new ArgumentNullException("The argument does not contain any data.");

            this.mData = data;
        }
    }

    #endregion

    #region HistoryChangeEventArgs

    public sealed class HistoryChangeEventArgs : EventArgs
    {
        private string mRedoText;
        public string RedoText
        {
            get
            {
                return mRedoText;
            }
            set
            {
                mRedoText = value;
            }
        }

        private string mUndoText;
        public string UndoText
        {
            get
            {
                return mUndoText;
            }
            set
            {
                mUndoText = value;
            }
        }

        #region Constructor
        public HistoryChangeEventArgs(string redoText, string undoText)
        {
            this.mRedoText = redoText;
            this.mUndoText = undoText;
        }

        #endregion

    }
    #endregion

    #region SelectionEventArgs
    public sealed class SelectionEventArgs : EventArgs
    {
        private object[] mObjects;
        public object[] SelectedObjects
        {
            get
            {
                return mObjects;
            }
            set
            {
                mObjects = value;
            }
        }
        public static readonly new PropertiesEventArgs Empty = new PropertiesEventArgs();

        #region Constructor
        public SelectionEventArgs(object[] objects)
        {
            this.mObjects = objects;
        }
        public SelectionEventArgs()
        {
        }
        #endregion

    }
    #endregion

    #region CancelableEntityEventArgs
    public sealed class CancelableEntityEventArgs : EventArgs
    {

        private bool mCancel;
        public bool Cancel
        {
            get
            {
                return mCancel;
            }
            set
            {
                mCancel = value;
            }
        }


        IDiagramEntity mEntity;

        public IDiagramEntity Entity
        {
            get
            {
                return mEntity;
            }
            set
            {
                mEntity = value;
            }
        }
        public CancelableEntityEventArgs(IDiagramEntity entity)
        {
            this.Entity = entity;
        }
    }
    #endregion
}
