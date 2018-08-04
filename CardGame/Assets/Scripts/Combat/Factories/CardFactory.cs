using System.Collections;
using System.Collections.Generic;
using CardGame.Abstract;
using CardGame.Cards;
using CardGame.Enums;

namespace CardGame.Factories {
    public static class CardFactory {

        public static List<Card> GetCards(ClassType actorClass, RaceType actorRace) {
            var output = new List<Card>();
            output.AddRange(GetClassCards(actorClass));
            output.AddRange(GetRaceCards(actorRace));                        
            return output;
        }

        public static List<Card> GetClassCards(ClassType actorClass) {
            var output = new List<Card>();
            switch (actorClass) {
                case ClassType.FIGHTER:
                    output = GetFighterCards();
                    break;
                case ClassType.KNIGHT:
                    output = GetKnightCards();
                    break;
                case ClassType.TEMPLAR:
                    output = GetTemplarCards();
                    break;
                default:
                    output = GetDefault();
                    break;
            }
            return output;
        }
        public static List<Card> GetRaceCards(RaceType actorRace) {
            var output = new List<Card>();
            switch (actorRace) {
                case RaceType.HUMAN:
                    output = GetHumanCards();
                    break;
                case RaceType.UNDEAD:
                    output = GetUndeadCards();
                    break;
                default:
                    break;
            }
            return output;
        }

        public static List<Card> GetHumanCards() {
            var output = new List<Card>();
            return output;
        }

        public static List<Card> GetUndeadCards() {
            var output = new List<Card>();
            return output;
        }

        public static List<Card> GetFighterCards() {
            var output = new List<Card>();
            output.Add(new Strike());
            output.Add(new Strike());
            output.Add(new Strike());
            output.Add(new Strike());
            output.Add(new Respite());
            return output;
        }
        public static List<Card> GetKnightCards() {
            var output = new List<Card>();
            output.Add(new Strike());
            output.Add(new Strike());
            output.Add(new Strike());
            output.Add(new Strike());
            output.Add(new Respite());
            return output;
        }
        public static List<Card> GetTemplarCards() {
            var output = new List<Card>();
            output.Add(new Strike());
            output.Add(new Strike());
            output.Add(new Strike());
            output.Add(new Strike());
            output.Add(new Respite());
            return output;
        }
        public static List<Card> GetDefault() {
            var output = new List<Card>();
            output.Add(new Strike());
            output.Add(new Strike());
            output.Add(new Strike());
            output.Add(new Strike());
            output.Add(new Respite());
            return output;
        }
    }
}
