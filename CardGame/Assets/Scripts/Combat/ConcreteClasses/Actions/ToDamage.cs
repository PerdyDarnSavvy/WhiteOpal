using CardGame.Abstract;
using CardGame.Interfaces;

namespace CardGame.Actions {
    public class ToDamage : iAction {
        private int DamageAmount { get; set; }

        public ToDamage(int amount) {
            this.DamageAmount = amount;
        }

        public void execute(Character target, Character source) {
            target.ApplyDamage(DamageAmount);
        }
    }
}