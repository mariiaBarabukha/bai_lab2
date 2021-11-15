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
            Mark villian1 = new Mark("bad guy 1", Color.BLACK);
            Mark villian2 = new Mark("bad guy 2", Color.BLACK);
            Mark lord = new Mark("Lord", Color.YELLOW);
            List<Mark> marks = new List<Mark>();
            marks.Add(mainCharacter);
            marks.Add(princess);
            marks.Add(competition);
            marks.Add(helper);
            //marks.Add(villian1);
            //marks.Add(villian2);
            marks.Add(lord);
            PetriNet petri = new PetriNet(marks);
            Console.WriteLine(petri.Run());
        }
    }
}
