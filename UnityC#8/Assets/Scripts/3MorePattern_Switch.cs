// 在更多位置中使用更多模式

using System;

public class CSharp8_3MorePattern
{
    public enum Rainbow
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }

    public static RGBColor FromRainbow(Rainbow colorBand) =>
        colorBand switch
        {
            Rainbow.Red => new RGBColor(0xFF, 0x00, 0x00),
            Rainbow.Orange => new RGBColor(0xFF, 0x7F, 0x00),
            Rainbow.Yellow => new RGBColor(0xFF, 0xFF, 0x00),
            Rainbow.Green => new RGBColor(0x00, 0xFF, 0x00),
            Rainbow.Blue => new RGBColor(0x00, 0x00, 0xFF),
            Rainbow.Indigo => new RGBColor(0x4B, 0x00, 0x82),
            Rainbow.Violet => new RGBColor(0x94, 0x00, 0xD3),
            _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand)),
        };
    
    /*
     这里有几个语法改进：
        变量位于 switch 关键字之前。 不同的顺序使得在视觉上可以很轻松地区分 switch 表达式和 switch 语句。
        将 case 和 : 元素替换为 =>。 它更简洁，更直观。
        将 default 事例替换为 _ 弃元。
        正文是表达式，不是语句。
     */
    
    public static RGBColor FromRainbowClassic(Rainbow colorBand)
    {
        switch (colorBand)
        {
            case Rainbow.Red:
                return new RGBColor(0xFF, 0x00, 0x00);
            case Rainbow.Orange:
                return new RGBColor(0xFF, 0x7F, 0x00);
            case Rainbow.Yellow:
                return new RGBColor(0xFF, 0xFF, 0x00);
            case Rainbow.Green:
                return new RGBColor(0x00, 0xFF, 0x00);
            case Rainbow.Blue:
                return new RGBColor(0x00, 0x00, 0xFF);
            case Rainbow.Indigo:
                return new RGBColor(0x4B, 0x00, 0x82);
            case Rainbow.Violet:
                return new RGBColor(0x94, 0x00, 0xD3);
            default:
                throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand));
        };
    }
    
    // 属性模式
    public static decimal ComputeSalesTax(Address location, decimal salePrice) =>
        location switch
        {
            { State: "WA" } => salePrice * 0.06M,
            { State: "MN" } => salePrice * 0.075M,
            { State: "MI" } => salePrice * 0.05M,
            // other cases removed for brevity...
            _ => 0M
        };
    
    // 元组模式
    public static string RockPaperScissors(string first, string second)
        => (first, second) switch
        {
            ("rock", "paper") => "rock is covered by paper. Paper wins.",
            ("rock", "scissors") => "rock breaks scissors. Rock wins.",
            ("paper", "rock") => "paper covers rock. Paper wins.",
            ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
            ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
            ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
            (_, _) => "tie"
        };
    
    // 位置模式
    static Quadrant GetQuadrant(Point point) => point switch
    {
        (0, 0) => Quadrant.Origin,
        var (x, y) when x > 0 && y > 0 => Quadrant.One,
        var (x, y) when x < 0 && y > 0 => Quadrant.Two,
        var (x, y) when x < 0 && y < 0 => Quadrant.Three,
        var (x, y) when x > 0 && y < 0 => Quadrant.Four,
        var (_, _) => Quadrant.OnBorder,
        _ => Quadrant.Unknown
    };
}

public class Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y) => (X, Y) = (x, y);

    public void Deconstruct(out int x, out int y) =>
        (x, y) = (X, Y);
}

public enum Quadrant
{
    Unknown,
    Origin,
    One,
    Two,
    Three,
    Four,
    OnBorder
}

public class Address
{
    public string State { get; set; }
}

public class RGBColor
{
    public RGBColor(int R, int G, int B)
    {
        (string Alpha, string Beta) namedLetters = ("a", "b");
        Console.WriteLine($"{namedLetters.Alpha}, {namedLetters.Beta}");

        throw new NotImplementedException();
    }
}