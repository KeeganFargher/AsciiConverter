﻿using System.Collections.Generic;
using System.Drawing;

namespace ConverterLibrary
{
    public class Frame
    {
        public List<int> X { get; } = new List<int>();
        public List<int> Y { get; } = new List<int>();

        public List<Color> Color { get; } = new List<Color>();
    }
}