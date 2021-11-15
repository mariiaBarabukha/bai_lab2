using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    
    class Transition
    {
        Dictionary<Color, int> m;
        public List<Place> out_places { get; set; }
        public string Name { get; set; }

        public delegate string CondiotionOfTransition(Dictionary<Color, int> m,
            List<Place> ent);

        //public void Next(Dictionary<Color, int> m,
        //    List<Place> ent, CondiotionOfTransition f) {
        //    f(m, ent);
        //}

        CondiotionOfTransition _Next;

        public Transition(Dictionary<Color, int> m, List<Place> places, string name, CondiotionOfTransition f)
        {
            this.m = m;
            out_places = places;
            Name = name;
            _Next = f;
            //Condition = condition;
        }

        public string Next()
        {
           return _Next != null ? _Next(m, out_places) : "";
        }
                
    }
}
