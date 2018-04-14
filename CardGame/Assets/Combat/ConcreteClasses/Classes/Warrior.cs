using CardGame.Abstract;
using CardGame.Resources;

namespace CardGame.Classes {
	public class Warrior : Character {

		private Stamina Stamina { get;set; }

		public Warrior() : base() {
			UnityEngine.Debug.Log("Warrior()");
			Stamina = new Stamina(100, 100);
		}

		public override Resource GetResource(){
			return Stamina;
		}

		public override void CastCard(Card card, Character target) {
			if(Stamina.CanCostBePaid(card.Cost)) {
				Stamina.PayCost(card.Cost);
				UnityEngine.Debug.Log("Paid stamina, current stamina: " + Stamina.GetAmount() + " / " + Stamina.GetMaxAmount());

				foreach(var action in card.Actions) {
					action.execute(target, this);
				}

			}
		}
	}
}
