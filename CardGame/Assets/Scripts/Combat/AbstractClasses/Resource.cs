using System.Collections;
using System.Collections.Generic;

namespace CardGame.Abstract {
    public abstract class Resource {
        public string Name { get; set; }
        public int Type;
        
        private int Amount { get; set; }
        private int MaxAmount { get; set; }
        

        public Resource(int amount, int maxAmount, string name, int type) {
            Name = name;
            Type = type;
            SetAmount(amount);
            SetMaxAmount(maxAmount);
        }

        public int GetAmount() {
            return Amount;
        }
        public int GetMaxAmount() {
            return MaxAmount;
        }
        public float GetCurrentPercent() {
            return (float)Amount / (float)MaxAmount;
        }

        public void SetMaxAmount(int maxAmount) {
            MaxAmount = maxAmount;
        }

        public void SetAmount(int amount) {
            Amount = amount;
        }

        public void SupplyResource(int addition) {
            SetAmount(Amount + addition);
        }
        
        public void DepleteResource(int depletion) {
            SetAmount(Amount - depletion);
        }

        public void PayCost(int cost) {
            DepleteResource(cost);
        }

        public bool CanCostBePaid(int cost) {
            return MeetsThreshold(cost, false, true, true);
        }

        // 'above' is false if checking Resource is below threshold, otherwise true
        public bool MeetsThreshold(int threshold, bool isPercent, bool above, bool allowEqual) {
            if(!isPercent)
                return (above && Amount > threshold) || (!above && Amount < threshold) || (allowEqual && Amount == threshold);           
            else {
                float currentPercent = GetCurrentPercent();
                return (above && currentPercent > threshold) || (!above && currentPercent < threshold) || (allowEqual && currentPercent == threshold);
            }
        }
    }
}
