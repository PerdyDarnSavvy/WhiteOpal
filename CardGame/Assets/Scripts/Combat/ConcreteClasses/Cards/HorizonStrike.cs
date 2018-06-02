using System.Collections.Generic;
using CardGame.Abstract;
using CardGame.Interfaces;
using CardGame.Actions;

namespace CardGame.Cards {
    public class HorizonStrike : Card {
        public override List<iAction> Actions { get; set; }
        public HorizonStrike() : base("Horizon Strike", 10, -1) {
            
            Actions = new List<iAction>();
            Actions.Add(new ToDamage(5));
        }
    }
}