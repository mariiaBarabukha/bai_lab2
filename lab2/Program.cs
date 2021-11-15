using System;
using System.Collections.Generic;

namespace lab2
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Mark mainCharacter = new Mark("Ivan", Color.GREEN);
            Mark princess = new Mark("Vasilisa", Color.RED);
            Mark competition = new Mark("find treasure", Color.BLUE);
            Mark helper = new Mark("wizard", Color.WHITE);
            List<Mark> marks = new List<Mark>();
            marks.Add(mainCharacter);
            marks.Add(princess);
            marks.Add(competition);
            marks.Add(helper);
            PetriNet petri = new PetriNet(marks);
            Console.WriteLine(petri.Run());
        }
    }
}
