using System;

namespace SantaClauseConsoleApp
{
    public class Child
    {
        int child_id;
        string name;
        DateTime date_of_birth;
        string address;
        BehaviorEnum behavior;
        Letter letter;

        public Child()
        {
        }

        public Child(int child_id, string name, DateTime date_of_birth, string address, BehaviorEnum behavior, Letter letter)
        {
            Child_id = child_id;
            Name = name;
            Date_of_birth = date_of_birth;
            Address = address;
            Behavior = behavior;
            Letter = letter;
        }

        public string Name { get; set; }
        public int Child_id { get; set; }
        public DateTime Date_of_birth { get; set; }
        public string Address { get; set; }
        public BehaviorEnum Behavior { get; set; }
        public Letter Letter { get; set; }

    }
}
