using CardGame.Abstract;

namespace CardGame.Resources {
    public class Stamina : Resource {
        private int Amount { get; set; }

        public Stamina(int amount) {
            this.Amount = amount;
        }

        public override int GetAmount() {
            return Amount;
        }

        public override void SetAmount(int amount) {
            this.Amount = amount;
        }
    }
}
