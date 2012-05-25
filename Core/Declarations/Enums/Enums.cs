using System;

namespace Netron.NetronLight
{
    public enum CanvasBackgroundTypes
    {

        FlatColor,
        Gradient,
        Image

    }
    public enum ShapeTypes
	{
        //add cumstomized objects
        CustomizedObject=1,
        DataStoreObject=2,
        DataSinkObject=3,
        Terminator=4,
        CObject=5,
        ADTObject=6,
        SMObject=7,
		SimpleRectangle=8,
		SimpleEllipse=9,
		TextLabel=10,
		ClassShape=11,
        TextOnly=12,
        ImageShape=13,
        DecisionShape=14
	}
    public enum SelectionTypes
    {
        Inclusion,
        Partial
    }
    public enum SortByType
    {
        Method = 0,
        Property = 1
    }

    public enum SortDirection
    {
        Ascending = 0,
        Descending = 1
    }

    public enum TransformTypes
    { 
        NW,
        N,
        NE,
        E,
        SE,
        S,
        SW,
        W
    }
}
