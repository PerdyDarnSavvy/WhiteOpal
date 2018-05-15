using CardGame.Abstract;
using CardGame.Interfaces;

namespace CardGame.Actions {
    public class ToDamageWithThreshold : iAction {
        private int DamageAmount { get; set; }
        private int Threshold { get; set; }
        private bool IsPercent { get; set; }
        private bool Above { get; set; }
        private bool Equal { get; set; }

        public ToDamageWithThreshold(int amount, int threshold, bool isPercent, bool above, bool equal) {
            DamageAmount = amount;
            Threshold = threshold;
            IsPercent = isPercent;
            Above = above;
            Equal = equal;
        }

        public void execute(Character target, Character source) {
            Resource resource = source.GetResource();

            if(resource.MeetsThreshold(Threshold, IsPercent, Above, Equal)) {
                target.ApplyDamage(DamageAmount);
            }
        }
    }
}