using System;

var point = new Point(); //parameterless constructor is always present for structs

Console.ReadKey();

public struct Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x; 
        Y = y;
    }

    //this will not work - structs can't have finalizers
    //~Point()
    //{

    //}

    //    //before C# 10 this would not compile - struct couldn't have
    //    //explicit parameterless constuctor
    //    public Point()
    //    {

    //    }

    //    //before C# 10 this would not compile - all fields must be
    //    //assigned in the constructor
    //    public Point(int x)
    //    {

    //    }
}

//This will not work - structs do not support inheritance
//public struct SpecialPoint : Point
//{

//}

//this works fine - structs can implement interfaces

public struct SpecialPoint : IComparable<SpecialPoint>
{
    public int CompareTo(SpecialPoint other)
    {
        throw new NotImplementedException();
    }
}

