using System.Collections.Generic;
using CardGame.Interfaces;

namespace CardGame.Abstract {
    public abstract class Card {
        public abstract int Cost { get;set; }
        public abstract List<iAction> Actions { get;set; }
    }
}