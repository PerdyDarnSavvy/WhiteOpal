using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardGame.Abstract;
using CardGame.Resources;

namespace CardGame.Abstract {
	public abstract class Character {

		public string Name { get; set; }

		public Health HP { get; set; }

		// List<Card> Deck { get; set; }

		public Character(string name) {
			Name = name;
			HP = new Health(100, 100);
		}

		public void ApplyDamage(int amount) {
			HP.DepleteResource(amount);
		}

		abstract public Resource GetResource();

		abstract public void CastCard(Card card, Character target);

		abstract public List<Resource> GetAllResources();
	}
}
