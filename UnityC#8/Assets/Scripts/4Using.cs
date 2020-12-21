using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharp8_4Using
{
    // 以前的写法
    static int WriteLinesToFileOld(IEnumerable<string> lines)
    {
        using (var file = new System.IO.StreamWriter("WriteLines2.txt"))
        {
            int skippedLines = 0;
            foreach (string line in lines)
            {
                if (!line.Contains("Second"))
                {
                    file.WriteLine(line);
                }
                else
                {
                    skippedLines++;
                }
            }
            return skippedLines;
        } // file is disposed here
    }
    
    static int WriteLinesToFileNew(IEnumerable<string> lines)
    {
        //C#8 新的写法
        using var file = new System.IO.StreamWriter("WriteLines2.txt");
        int skippedLines = 0;
        foreach (string line in lines)
        {
            if (!line.Contains("Second"))
            {
                file.WriteLine(line);
            }
            else
            {
                skippedLines++;
            }
        }
        // Notice how skippedLines is in scope here.
        return skippedLines;
        // file is disposed here
    }
}
