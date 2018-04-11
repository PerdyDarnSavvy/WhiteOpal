using CardGame.Abstract;
using CardGame.Interfaces;

namespace CardGame.Actions {
    public class ToDamage : iAction {
        private int Amount {get;set;}

        public ToDamage(int amount) {
            this.Amount = amount;
        }

        public void execute(Character Target, Character Source) {
            //Target.applyDamage(amount, Source);
        }
    }
}