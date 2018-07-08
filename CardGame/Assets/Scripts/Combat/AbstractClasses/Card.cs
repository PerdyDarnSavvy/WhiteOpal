using System.Collections.Generic;
using CardGame.Interfaces;

namespace CardGame.Abstract {
    public abstract class Card {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int TargetsNeeded { get; set; }

        public Card(string name, int cost, int targetsNeeded) {
            Name = name;
            Cost = cost;
            TargetsNeeded = targetsNeeded;
        }

        public abstract List<iAction> Actions { get; set; }
    }
}