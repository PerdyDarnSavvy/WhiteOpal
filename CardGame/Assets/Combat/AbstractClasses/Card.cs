using System.Collections.Generic;
using CardGame.Interfaces;

namespace CardGame.Abstract {
    public abstract class Card {
        public string Name { get; set; }
        public abstract int Cost { get; set; }

        public Card(string name) {
            Name = name;
        }

        public abstract List<iAction> Actions { get; set; }
    }
}