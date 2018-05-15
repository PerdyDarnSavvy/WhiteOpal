using CardGame.Abstract;
using CardGame.Resources;

namespace CardGame.Classes {
	public class Warrior : Character {

		public Stamina Stamina { get; set; }

		public Warrior() : base("Warrior") {
			Stamina = new Stamina(100, 100);
		}

		public override Resource GetResource(){
			return Stamina;
		}

		public override void CastCard(Card card, Character target) {
			UnityEngine.Debug.Log(this.Name + " casts " + card.Name + ", using " + card.Cost + " " + Stamina.Name);
			if(Stamina.CanCostBePaid(card.Cost)) {
				Stamina.PayCost(card.Cost);

				foreach(var action in card.Actions) {
					action.execute(target, this);
				}
			}
		}
	}
}
