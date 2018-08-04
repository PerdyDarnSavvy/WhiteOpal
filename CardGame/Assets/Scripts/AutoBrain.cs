using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardGame.Abstract;

public class AutoBrain : MonoBehaviour {

	private List<Card> cards;

	public void Initialize(List<Card> cards) {
		this.cards = cards;
	}

	public void TakeTurn() {
		Debug.Log("Take Turn");
		Debug.Log(cards.Count);
        var randomCard = cards[Random.Range(0, cards.Count)];
		Debug.Log(randomCard.Name);
		List<Character> targets = new List<Character>();
		targets.Add(GameManager.Instance.Player.characterStats);
		ActionManager.Instance.CastCard(randomCard, this.GetComponent<Actor>(), targets);
	}
}
