using CardGame.Abstract;
using CardGame.Interfaces;

namespace CardGame.Actions {
    public class RestoreResource : iAction {
        private int RestoreAmount { get; set; }
        private int CurrentAmount { get; set; }
        private int MaxAmount {get; set; }
        public RestoreResource(int amount) {
            this.RestoreAmount = amount;
        }

        public void execute(Character target, Character source) {
            Resource resource = source.GetResource();
            this.MaxAmount = resource.GetMaxAmount();
            this.CurrentAmount = resource.GetAmount();

            if (CurrentAmount + RestoreAmount <= MaxAmount) {
                resource.SupplyResource(RestoreAmount);
            } else {
                resource.SetAmount(MaxAmount);
            }
        }
    }
}