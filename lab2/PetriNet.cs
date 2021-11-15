using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{

    
    class PetriNet
    {
        
        Place curr_state;
        Place root;

        string resultText;

        Dictionary<Color, int> analizedMarks;

        public PetriNet(List<Mark> marks)
        {
            resultText = "";
            analizedMarks = new Dictionary<Color, int>();
            analizedMarks.Add(Color.BLACK, 0);
            analizedMarks.Add(Color.RED, 0);
            analizedMarks.Add(Color.YELLOW, 0);
            analizedMarks.Add(Color.BLUE, 0);
            analizedMarks.Add(Color.GREEN, 0);
            analizedMarks.Add(Color.WHITE, 0);
            foreach (var mark in marks)
            {
                analizedMarks[mark.MarkColor]++;
            }
            root = new Place(marks, analizedMarks, "");
            curr_state = root;
            Place entrence1 = new Place(marks, analizedMarks, "In the city of gold is living a beautiful" +
                " princess <p>. Her father is a ruler of the biggest kingdom. In honor of " +
                "<p>'s birthday, the king decides to hold a huge ball and invite all " +
                " young princes from the nearest countries to choose a worthy husband for" +
                " his lovely daughter.\nIn the day of event a lot of people gather in the huge " +
                "hall. When all guests have arrived, the king announce, that a prince, who wants his " +
                "<p>'s hand should <t>. And all princes hit the road...\n");
            Place entrence2 = new Place(marks, analizedMarks, "In a small town on the end of the geography is living" +
                " <b>. His famaly isn't rich, but isn't poor. The boy have a dream - one" +
                " day he become a knight. When he has turned 16, he got a letter, which says that" +
                " he can take an exam and if he succeeds, he'll have an opportunity to become" +
                " a student of the best knight in the kingdom. In few weeks <b> arrives to the place," +
                "where he'll take an exam. A tall guy in shining armor speak to the growd: 'If you want to " +
                "become a part of us, you should <t>'. And all boys hit the road...\n");
            
            Place helper1 = new Place(marks, analizedMarks, "In the forest <b> meets <h>. He gives his a clue where <b> " +
                "should go next to find more clues.\n");
            Place helper2 = new Place(marks, analizedMarks, "In the forest <b> falls into a dip hole. He finds a <h> and <h>" +
                " so now he knows how to defeat the monster.\n");
            Place helper3 = new Place(marks, analizedMarks, "In the forest <b> meets <h>. He said that he will " +
                "help him, instead he must give him the most meaningfull thing for him. And <b> agrees.\n ");

            Place villain1 = new Place(marks, analizedMarks, "<b> finds a cave. He has went " +
                " inside of it and then he see, what he had been searching. Suddenly, <v>" +
                " appeares. He says that everybody who have ever walked in, would never leave this place." +
                "<v> attacks first. But <b>" +
                " is not afraid, he know what to do.\n");
            Place villain2 = new Place(marks, analizedMarks, "One moment, <b> starts to think that he's lost the road." +
                " He hasn't seen nothing special in few hours! But suddenly <v> and <v> appears. They say 'You are " +
                "not allowed to be here. It's <m> residence'. <b> turns around and starts leaving that place, but has" +
                " felt that guys go after him. They stops him and ask for money. After rejection they say that he" +
                "won't leave them until he give some money. After one more rejection they simply attack but has been " +
                "defeated. <b> continues his searching...\n ");
            Place novillain = new Place(marks, analizedMarks, "");

            Place ending1 = new Place(marks, analizedMarks, "Finally, <b> <t>. And now he happily live with <p> ever after.");
            Place ending2 = new Place(marks, analizedMarks, "Unfortunatly, <b> haven't <t>. " +
                "But the princess liked him so much, that after a conversation with her father, king agreed." +
                " And they end with happily ever after.");
            
            Place ending3 = new Place(marks, analizedMarks, "Finally, <b> <t>. And now his dream come true. Few years after he" +
                " meet <p> and lives happily with she ever after.");
            Place ending4 = new Place(marks, analizedMarks, "Unfortunatly, <b> haven't <t>. " +
                "He returns home and decited to use his new skills and experience to" +
                " help his town.");
            List<Place> entrence = new List<Place>();
            entrence.Add(entrence1);
            entrence.Add(entrence2);            

            List<Place> helper_1 = new List<Place>();
            helper_1.Add(helper1);           

            List<Place> helper_2 = new List<Place>();
            helper_2.Add(helper2);
            helper_2.Add(helper3);

            List<Place> villain = new List<Place>();
            villain.Add(villain1);
            villain.Add(villain2);
            villain.Add(novillain);

            List<Place> ending_1 = new List<Place>();
            ending_1.Add(ending1);
            ending_1.Add(ending2);
            
            List<Place> ending_2 = new List<Place>();
            ending_2.Add(ending3);
            ending_2.Add(ending4);

            Transition t1 = new Transition(analizedMarks, entrence, 
                "entrence", ChooseEntrence);
            //t1.Condition = ChooseEntrence(analizedMarks, entrence);
            Transition t2 = new Transition(analizedMarks, helper_1,
                "helpers 1", ChooseHelper1);
            Transition t3 = new Transition(analizedMarks, helper_2,
                "helpers 2", ChooseHelper2);
            Transition t4 = new Transition(analizedMarks, villain,
                "helpers 2", ChooseVillain);
            Transition t5 = new Transition(analizedMarks, ending_1,
                "ending 1", ChooseEnding1);
            Transition t6 = new Transition(analizedMarks, ending_2, 
                "ending 2", ChooseEnding2);

            
            root.AddTransition(t1);
            entrence1.AddTransition(t2);
            entrence2.AddTransition(t3);
            helper1.AddTransition(t4);
            helper2.AddTransition(t4);
            helper3.AddTransition(t4);
            villain1.AddTransition(t5);
            villain2.AddTransition(t5);
            villain1.AddTransition(t6);
            villain2.AddTransition(t6);
            novillain.AddTransition(t5);
            novillain.AddTransition(t6);
        }

        public string Run()
        {
            return root.NextTransition().Next();
        }

        public string GetText(List<Mark> marks)
        {
            return "";
        }

        public string ChooseEntrence(Dictionary<Color, int> m, List<Place> ent)
        {
            Place curr_state = null;
            if (m[Color.GREEN] == 0)
            {
                throw new Exception("No main character exists!");
            }
            if (m[Color.RED] == 0)
            {
                throw new Exception("No princess etc exists!");
            }
            if (m[Color.BLUE] == 0)
            {
                throw new Exception("No competition has been given!");
            }
            if (m[Color.WHITE] >= 2)
            {
               curr_state = ent[0];
            }
            
            else
            {
                Random r = new Random();
                curr_state = ent[r.Next(ent.Count)];
            }

            return curr_state.Text + curr_state.NextTransition().Next();
        }

        public string ChooseVillain(Dictionary<Color, int> m, List<Place> ent)
        {
            Place curr_state = null;
            if (m[Color.BLACK] == 0)
            {
                curr_state = ent[2];
            }
            else
            {
                if (m[Color.BLACK] >= 2 && m[Color.YELLOW] > 0)
                {
                    curr_state = ent[1];
                }
                else
                {
                    curr_state = ent[0];
                }
            }

            
            return curr_state.Text + curr_state.NextTransition().Next();
        }

        public string ChooseHelper1(Dictionary<Color, int> m, List<Place> ent)
        {
            Place curr_state = null;
            curr_state = ent[0];
            if (m[Color.WHITE] >= 2)
            {
                Random r = new Random();
                int i = r.Next(2);
                

                return curr_state.Text +
                    (i == 0 ? curr_state.NextTransition().Next() : ChooseHelper1(m, ent));
            }
            return curr_state.Text + curr_state.NextTransition().Next();

        }

        public string ChooseHelper2(Dictionary<Color, int> m, List<Place> ent)
        {
            Place curr_state = null;
            if (m[Color.WHITE] >= 2)
            {
                curr_state = ent[0];
            }
            else
            {
                
                curr_state = ent[1];
            }

            return curr_state.Text + curr_state.NextTransition().Next();
        }

        public string ChooseEnding1(Dictionary<Color, int> m, List<Place> ent)
        {
            Place curr_state = null;
            Random r = new Random();
            curr_state = ent[r.Next(ent.Count - 1)];            

            return curr_state.Text;
        }

        public string ChooseEnding2(Dictionary<Color, int> m, List<Place> ent)
        {
            Place curr_state = null;
            Random r = new Random();
            if (m[Color.RED] == 0)
            {
                curr_state = ent[1];
            }
            else
            {
                curr_state = ent[0];
            }
            

            return curr_state.Text;
        }
    }
}
