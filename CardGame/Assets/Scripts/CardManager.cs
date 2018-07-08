using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CardGame.Abstract;
using CardGame.Cards;
using CardGame.Other;

// Every Player has their own CardManager
// This handles interaction between zones
public class CardManager {

	public CardZone Deck;
	public CardZone Hand;
	public CardZone Discard;

	private static int defaultMaxHandSize = 4;
	private int maxHandSize;
	
	public CardManager(int maxHandSize = -1) {
		SetMaxHandSize(maxHandSize);
		Initialize();
	}
	
	public void Initialize() {
		Deck = new CardZone();
		Hand = new CardZone();
		Discard = new CardZone();

		DemoInit();
	}

	public void DemoInit() {
		Deck.AddCard(new Strike());
		Deck.AddCard(new HorizonStrike());
		Deck.AddCard(new ViciousVigor());
		Deck.AddCard(new Respite());
		Deck.AddCard(new Strike());
		Deck.AddCard(new HorizonStrike());
		Deck.AddCard(new ViciousVigor());
		Deck.AddCard(new Respite());
		Deck.AddCard(new Strike());
		Deck.AddCard(new HorizonStrike());
		Deck.AddCard(new ViciousVigor());
		Deck.AddCard(new Respite());
		Discard.AddCard(new Strike());

		Shuffle(Deck);

		DrawHand();
	}

	public void SetMaxHandSize(int newSize) {
		if(newSize < 1) {
			newSize = defaultMaxHandSize;
		}
		maxHandSize = newSize;
	}

	public bool CastCardFromHand(Card card) {
		var takenCard = Hand.ConfirmExistsAndTake(card);
		if(takenCard != null) {
			Discard.AddCard(takenCard);
			return true;
		}

		return false;
	}

	public void DrawHand() {
		for(int i = 0; i < maxHandSize; i++) {
			Draw();
		}
	}

	public void Shuffle(CardZone zone) {
		zone.Shuffle();
	}

	public void Draw() {
		var cardToDraw = Deck.TakeTop();
		AddCard(cardToDraw);
	}

	public void AddCard(Card card) {
		Hand.AddCard(card);
	}

	public void DiscardCard(Card card) {
		var cardToDiscard = Hand.ConfirmExistsAndTake(card);
		if (cardToDiscard != null) {
			Discard.AddCard(cardToDiscard);
		}
	}

	public void DiscardRandom() {
		var cardToDiscard = Hand.TakeRandom();
		Discard.AddCard(cardToDiscard);
	}
	
	public void Mill() {
		var cardToMill = Deck.TakeTop();
		Discard.AddCard(cardToMill);
	}

	public void MillCard(Card card) {
		var cardToMill = Deck.ConfirmExistsAndTake(card);
		if (cardToMill != null) {
			Discard.AddCard(cardToMill);
		}
	}
}
