using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardGame.Abstract;
using CardGame.Resources;

namespace CardGame.Abstract {
	public abstract class Character : MonoBehaviour {

		public Health HP { get; set; }

		// List<Card> Deck { get; set; }

		public Character() {
			HP = new Health(100);
		}

		public abstract void Start ();
		
		// Update is called once per frame
		public void Update () {
			
		}

		public void ApplyDamage(int amount) {
			HP.DepleteResource(amount);
		}

		abstract public Resource GetResource();

		abstract public void CastCard(Card card, Character target);
	}
}
