using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardGame.Abstract;
using CardGame.Resources;

namespace CardGame.Abstract {
	public abstract class Character {

		public Health HP { get; set; }

		// List<Card> Deck { get; set; }

		public Character() {
			HP = new Health(100, 100);
			HP.Name = "Health";
		}

		public void ApplyDamage(int amount) {
			HP.DepleteResource(amount);
			UnityEngine.Debug.Log("ApplyDamage()");
			UnityEngine.Debug.Log("Current HP: " + HP.GetAmount() + " / " + HP.GetMaxAmount());
		}

		abstract public Resource GetResource();

		abstract public void CastCard(Card card, Character target);
	}
}
