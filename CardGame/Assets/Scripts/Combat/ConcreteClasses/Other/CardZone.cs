using System.Collections.Generic;
using System.Linq;
using CardGame.Interfaces;
using CardGame.Abstract;
using UnityEngine;

namespace CardGame.Other {
    // These are classes for "actual" cards and decks being used in a combat

    // A "Zone" is a "Stack", of a sort.
    // [ Card A ] - Index = 3 (Cards.Last() - CardZone.Top() - AKA "Top")
    // [ Card B ] - Index = 2
    // [ Card C ] - Index = 1
    // [ Card D ] - Index = 0 (Cards.First() - CardZone.Bottom() - AKA "Bottom")

    // Actual collections (Deck, Hand, Discard)
    public class CardZone {
        private List<Card> Cards { get; set; }

        public CardZone(List<Card> initialList = null) {
            if (initialList == null) {
                Cards = new List<Card>();
            } else {
                Cards = initialList;
            }
        }

        public void ReplaceAll(List<Card> newSet) {
            Cards = newSet;
        }

        public List<Card> GetAllCards() {
            return Cards;
        }

        public int Count() {
            return Cards.Count;
        }

        // Top
        public Card Top() {
            // Cards.Last() because List.Last() is last index
            return Cards.LastOrDefault();
        }

        // Bottom
        public Card Bottom() {
            // Cards.First() because List.First() is 0-th index
            return Cards.FirstOrDefault();
        }
        
        public Card GetAtIndex(int index) {
            index = ClampIndex(index);
            return Cards[index];
        }

        public Card GetRandom() {
            return GetAtIndex(Random.Range(0, Cards.Count));
        }

        public void AddCard(Card card) {
            Cards.Add(card);
        }

        public void AddCard(Card card, int index = -1) {
            index = ClampIndex(index);
            Cards.Insert(index, card);
        }

        public Card TakeTop() {
            return Take(Top());
        }
        
        public Card TakeBottom() {
            return Take(Bottom());
        }

        // Returns -1 if card does not exist
        public int IndexOfCard(Card card) {
            return Cards.IndexOf(card);
        }

        public Card ConfirmExistsAndTake(Card card) {
            if (IndexOfCard(card) >= 0) {
                return Take(card);
            } else {
                return null;
            }
        }

        public Card TakeRandom() {
            var randomCard = GetRandom();
            return Take(randomCard);
        }

        private Card Take(Card card) {
            if (card != null) {
                RemoveCard(card);
                return card;
            }
            return null;
        }

        public List<Card> TakeAll() {
            List<Card> output = new List<Card>();
            output.AddRange(Cards);
            Cards = new List<Card>();
            return output;
        }

        public void RemoveCard(Card card) {
            if(!Cards.Remove(card)) {
                Debug.Log("Error Removing Card - Card (" + card.Name + ") not found in List of Cards!");
            }
        }

        public void Shuffle() {
            int n = Cards.Count;  
            while (n > 1) {  
                n--;  
                int k = Random.Range(0, n + 1);
                Card value = Cards[k];  
                Cards[k] = Cards[n];  
                Cards[n] = value;  
            }  
        }

        // Not sure this will be used;
        // Replaces the card at the given index
        public void ReplaceCardAtIndex(int index, Card card) {
            index = ClampIndex(index);
            Cards[index] = card;
        }

        // Forces the given index to be within the list of cards
        private int ClampIndex(int index) {
            if (index < 0) {
                return 0;
            } else if (index > Cards.Count) {
                return Cards.Count;
            } else {
                return index;
            }
        }
    }
}