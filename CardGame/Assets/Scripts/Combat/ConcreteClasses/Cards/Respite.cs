﻿using System.Collections.Generic;
using CardGame.Abstract;
using CardGame.Interfaces;
using CardGame.Actions;

namespace CardGame.Cards {
    public class Respite : Card {
        public override List<iAction> Actions { get; set; }
        public Respite() : base("Respite", 0, 0) {
            Actions = new List<iAction>();
            Actions.Add(new ToRestore(15));
        }
    }
}
