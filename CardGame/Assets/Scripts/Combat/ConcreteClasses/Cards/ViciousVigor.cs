using System.Collections.Generic;
using CardGame.Abstract;
using CardGame.Interfaces;
using CardGame.Actions;

namespace CardGame.Cards {
    public class ViciousVigor : Card {
        public override List<iAction> Actions { get; set; }
        public ViciousVigor() : base("Vicious Vigor", 28, 1) {
           
            Actions = new List<iAction>();
            Actions.Add(new ToDamageWithThreshold(18, 50, true, false, true, 28));
        }
    }
}