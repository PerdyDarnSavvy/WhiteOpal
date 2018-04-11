using CardGame.Abstract;

namespace CardGame.Resources {
    public class Health : Resource {
        private int Amount { get; set; }

        public Health(int amount) {
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
