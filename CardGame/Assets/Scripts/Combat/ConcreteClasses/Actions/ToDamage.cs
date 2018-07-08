using System.Collections.Generic;
using CardGame.Abstract;
using CardGame.Interfaces;

namespace CardGame.Actions {
    public class ToDamage : iAction {
        private int DamageAmount { get; set; }

        public ToDamage(int amount) {
            this.DamageAmount = amount;
        }

        public void execute(List<Character> targets, Character source) {
            foreach(var target in targets) {
                target.ApplyDamage(DamageAmount);
            }
        }
    }
}