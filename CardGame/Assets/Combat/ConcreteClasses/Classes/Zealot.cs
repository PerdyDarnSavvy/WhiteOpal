using CardGame.Abstract;
using CardGame.Resources;

namespace CardGame.Classes {
	public class Zealot : Character {

		//public Stamina Stamina { get; set; }

		public Zealot() : base("Zealot") {
			//Stamina = new Stamina(100, 100);
		}

		public override Resource GetResource(){
			return HP;
		}

		public override void CastCard(Card card, Character target) {
			UnityEngine.Debug.Log(this.Name + " casts " + card.Name + ", using " + card.Cost + " " + HP.Name);
			if(HP.CanCostBePaid(card.Cost)) {
			    HP.PayCost(card.Cost);

				foreach(var action in card.Actions) {
					action.execute(target, this);
				}
			}
		}
	}
}
