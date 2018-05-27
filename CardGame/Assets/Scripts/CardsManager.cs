using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CardGame.Abstract;
using CardGame.Cards;

public class CardsManager : Singleton<CardsManager> {

	// This deck is the 'Instantiated Deck' 
	public List<Card> Deck;
	public List<Card> Hand;
	public List<Card> Grave;

	// Use this for initialization
	void Start () {
		InitializeDeck();
		InitializeHand();
		InitializeGrave();
	}

	public void InitializeDeck() {
		Deck = new List<Card>();
		for(int i = 0; i < 4; i++) {
			Deck.Add(new Strike());
		}
		Deck.Add(new Respite());
		Deck.Add(new Respite());
		Deck.Add(new ViciousVigor());
		Deck.Add(new ViciousVigor());
	}

	public void InitializeHand() {
		Hand = new List<Card>();
	}

	public void InitializeGrave() {
		Grave = new List<Card>();
	}

	public void Draw() {
		DrawCard(Deck.First());
	}

	public void DrawCard(Card cardToDraw) {
		if(cardToDraw != null) {
			Deck.Remove(cardToDraw);
			Hand.Add(cardToDraw);
		}
	}
	
	public void Discard(Card cardToDiscard) {
		if(cardToDiscard != null) {
			Deck.Remove(cardToDiscard);
			Hand.Add(cardToDiscard);
		}
	}

	public void ShuffleDeck() {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
