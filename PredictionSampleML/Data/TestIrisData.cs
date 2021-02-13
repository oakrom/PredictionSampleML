using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Data
{
    static class TestIrisData
    {
        internal static readonly IrisData Setosa = new IrisData
        {
            SepalLength = 6.0f,
            SepalWidth = 2.9f,
            PetalLength = 4.5f,
            PetalWidth = 1.5f
        };
    }
}
