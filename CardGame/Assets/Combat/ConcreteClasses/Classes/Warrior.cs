using CardGame.Abstract;
using CardGame.Resources;

namespace CardGame.Classes {
	public class Warrior : Character {

		private Stamina Stamina { get;set; }

		public override void Start() {
			HP = new Health(100);
			Stamina = new Stamina(100);
		}

		public override Resource GetResource(){
			return Stamina;
		}

		public override void CastCard(Card card, Character target) {
			if(Stamina.CanCostBePaid(card.Cost)) {
				Stamina.PayCost(card.Cost);
				foreach(var action in card.Actions) {
					action.execute(target, this);
				}

			}
		}
	}
}
