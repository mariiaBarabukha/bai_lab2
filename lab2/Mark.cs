using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class Mark
    {
        public string Name { get; set; }
        public Color MarkColor { get; set; }

        public Mark(string name, Color color)
        {
            Name = name;
            MarkColor = color;
        }
    }

    public enum Color
    {
        BLACK, //bad guys
        GREEN, //main cheracters
        RED, //main cheracters's crush
        YELLOW, //minor characters
        WHITE, //"helpers"
        BLUE //competitions
    }
}
