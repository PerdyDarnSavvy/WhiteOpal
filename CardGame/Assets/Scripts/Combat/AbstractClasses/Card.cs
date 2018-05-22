using System.Collections.Generic;
using CardGame.Interfaces;

namespace CardGame.Abstract {
    public abstract class Card {
        public string Name { get; set; }
        public abstract int Cost { get; set; }

        public Card(string name, int cost) {
            Name = name;
            Cost = cost;
        }

        public abstract List<iAction> Actions { get; set; }
    }
}