using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class Place
    {
        public List<Mark> marks;
        public Dictionary<Color, int> m;
        List<Transition> transitions;
        Random r = new Random();

        public string text;

        private string _replace(string text, string w, Color c)
        {
            var rep = marks.FindAll(e => e.MarkColor == c);
            return rep.Count > 0 ? text.Replace(w,rep[r.Next(m[c] - 1)].Name) 
                : text;
        }

        public string Text
        {
            get => _replace(_replace(_replace(_replace(text, "<t>", Color.BLUE),
                "<h>", Color.WHITE), 
                "<p>", Color.RED),
                "<b>", Color.GREEN);
            
            set => text = value; 
        }
        public Place(List<Mark> marks, Dictionary<Color, int> m, string text)
        {
            this.marks = marks;
            this.m = m;
            transitions = new List<Transition>();
            this.text = text;
        }

        //public Place(List<Mark> marks, string text)
        //{
        //    this.marks = marks;
        //    this.text = text;
        //    transitions = new List<Transition>();
        //}

        public void AddTransition(Transition transition)
        {
            transitions.Add(transition);
        }

        public Transition NextTransition()
        {
            if (transitions!=null || transitions.Count > 0)
            {
                int i = r.Next(transitions.Count - 1);
                return transitions[i];
            }
            return null; 
        }


    }
}
