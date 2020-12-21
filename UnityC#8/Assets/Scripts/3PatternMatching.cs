using System;

public class Square
{
    public double Side { get; }

    public Square(double side)
    {
        Side = side;
    }
}
public class Circle
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }
}
public struct Rectangle
{
    public double Length { get; }
    public double Height { get; }

    public Rectangle(double length, double height)
    {
        Length = length;
        Height = height;
    }
}
public class Triangle
{
    public double Base { get; }
    public double Height { get; }

    public Triangle(double @base, double height)
    {
        Base = @base;
        Height = height;
    }
}

class CSharp8_PatternMatching
{
    // C# 7之前
    public static double ComputeArea(object shape)
    {
        if (shape is Square)
        {
            var s = (Square)shape;
            return s.Side * s.Side;
        }
        else if (shape is Circle)
        {
            var c = (Circle)shape;
            return c.Radius * c.Radius * Math.PI;
        }
        // elided
        throw new ArgumentException(
            message: "shape is not a recognized shape",
            paramName: nameof(shape));
    }
    
    // C# 7
    public static double ComputeAreaModernIs(object shape)
    {
        if (shape is Square s)
            return s.Side * s.Side;
        else if (shape is Circle c)
            return c.Radius * c.Radius * Math.PI;
        else if (shape is Rectangle r)
            return r.Height * r.Length;
        // elided
        throw new ArgumentException(
            message: "shape is not a recognized shape",
            paramName: nameof(shape));
    }
    
    //C#7之前，switch 语句支持的唯一模式是常量模式。 数字类型和 string 类型
    public static string GenerateMessage(params string[] parts)
    {
        switch (parts.Length)
        {
            case 0:
                return "No elements to the input";
            case 1:
                return $"One element: {parts[0]}";
            case 2:
                return $"Two elements: {parts[0]}, {parts[1]}";
            default:
                return $"Many elements. Too many to write";
        }
    }
    
    //C#7以后可以使用类型模式
    public static double ComputeAreaModernSwitch(object shape)
    {
        switch (shape)
        {
            case Square s:
                return s.Side * s.Side;
            case Circle c:
                return c.Radius * c.Radius * Math.PI;
            case Rectangle r:
                return r.Height * r.Length;
            default:
                throw new ArgumentException(
                    message: "shape is not a recognized shape",
                    paramName: nameof(shape));
        }
    }
    
    // case 表达式中的 when 语句
    public static double ComputeArea_Version3(object shape)
    {
        switch (shape)
        {
            case Square s when s.Side == 0:
            case Circle c when c.Radius == 0:
                return 0;

            case Square s:
                return s.Side * s.Side;
            case Circle c:
                return c.Radius * c.Radius * Math.PI;
            default:
                throw new ArgumentException(
                    message: "shape is not a recognized shape",
                    paramName: nameof(shape));
        }
    }
    
    // case 表达式中的 var 声明
    static object CreateShape(string shapeDescription)
    {
        switch (shapeDescription)
        {
            case "circle":
                return new Circle(2);

            case "square":
                return new Square(4);

            case "large-circle":
                return new Circle(12);

            case var o when (o?.Trim().Length ?? 0) == 0:
                // white space
                return null;
            default:
                return "invalid shape description";
        }
    }
}
