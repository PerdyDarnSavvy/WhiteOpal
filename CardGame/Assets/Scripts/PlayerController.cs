using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CardGame.Abstract;
using CardGame.UI;
using CardGame.Other;

public enum PlayerSelectionState {
    SelectCard, SelectTarget, Disabled
}

public class PlayerController {

    private CardUI CardUIPrefab;
    private CardZoneUI CardZoneUIPrefab;
    private TargetableOverlay TargetableOverlayPrefab;

    private Actor playerActor { get; set; }
    private List<Actor> Enemies { get; set; }

    public PlayerSelectionState currentState { get; set; }
    public CardUI currentCardSelected { get; set; }
    public List<Actor> targetsSelected { get; set; }

    public PlayerController(Actor playerActor, List<Actor> enemies, CardUI CardUIPrefab, CardZoneUI CardZoneUIPrefab, TargetableOverlay TargetableOverlayPrefab) {
        this.playerActor = playerActor;
        this.CardUIPrefab = CardUIPrefab;
        this.CardZoneUIPrefab = CardZoneUIPrefab;
        this.TargetableOverlayPrefab = TargetableOverlayPrefab;
        Enemies = enemies;
        CreatePlayerUI();
        currentState = PlayerSelectionState.SelectCard;
        targetsSelected = new List<Actor>();
    }

    public void CardClicked(CardUI cardUI) {
        if (currentState == PlayerSelectionState.SelectCard) {
            if (currentCardSelected == cardUI) {
                currentCardSelected = null;
            } else {
                currentCardSelected = cardUI;
                if(currentCardSelected.Card.TargetsNeeded > 0) {
                    currentState = PlayerSelectionState.SelectTarget;
                } else if(currentCardSelected.Card.TargetsNeeded == -1) {
                    targetsSelected.AddRange(Enemies);
                    CastCard();
                } else {
                    CastCard();
                }
            }
        }
    }
    
    public void TargetClicked(Actor target) {
        if (currentState == PlayerSelectionState.SelectTarget) {
            if (targetsSelected.IndexOf(target) >= 0) {
                targetsSelected.Remove(target);
            } else {
                targetsSelected.Add(target);
                if(targetsSelected.Count == currentCardSelected.Card.TargetsNeeded) {
                CastCard();
                }
            }
        }
    }

    public void CastCard() {
        bool canCastCard = playerActor.characterStats.CanCastCard(currentCardSelected.Card);
        if (canCastCard) {
            bool cardWasCast = ActionManager.Instance.CastCard(currentCardSelected.Card, playerActor, targetsSelected.Select(x => x.characterStats).ToList());

            if (cardWasCast) {
                playerActor.CardManager.CastCardFromHand(currentCardSelected.Card);
                currentCardSelected.DestroySelf();
            } else {
            }
            currentCardSelected = null;
            targetsSelected = new List<Actor>();
            currentState = PlayerSelectionState.SelectCard;
        } else {
        }
    }

    public void CreatePlayerUI() {
        var globalCanvasTransform = GameManager.Instance.canvas.transform;
        CreatePlayerHand(globalCanvasTransform);
        CreateTargetOverlays(globalCanvasTransform);
        CreateZoneUI(playerActor.CardManager.Deck, "Deck", globalCanvasTransform, false);
        CreateZoneUI(playerActor.CardManager.Discard, "Discard", globalCanvasTransform, true);
    }

    private void CreatePlayerHand(Transform globalCanvasTransform) {
        var cardsInHand = playerActor.CardManager.Hand.GetAllCards();
        int counter = 0;
        foreach(var card in cardsInHand) {
            CreateCardUI(card, globalCanvasTransform, counter);
            counter++;
        }
    }

    private void CreateCardUI(Card card, Transform globalCanvasTransform, int counter) {
        var newCardUIinstance = MonoBehaviour.Instantiate(CardUIPrefab) as CardUI;
        newCardUIinstance.Initialize(card, this);
        newCardUIinstance.transform.SetParent(globalCanvasTransform, false);
        newCardUIinstance.transform.position = new Vector2(globalCanvasTransform.localPosition.x + ((counter * 2.5f) - 4f), (globalCanvasTransform.localPosition.y -2.5f));
    }

    private CardZoneUI CreateZoneUI(CardZone zone, string name, Transform globalCanvasTransform, bool isRight) {
        float direction = (isRight) ? 1f : -1f;
        var newCardZoneUI = MonoBehaviour.Instantiate(CardZoneUIPrefab) as CardZoneUI;
        newCardZoneUI.transform.SetParent(globalCanvasTransform, false);
        newCardZoneUI.transform.position = new Vector2(globalCanvasTransform.localPosition.x + (8f * direction), (globalCanvasTransform.localPosition.y -2.5f));
        newCardZoneUI.Initialize(zone, name);
        return newCardZoneUI;
    }

    private void CreateTargetOverlays(Transform globalCanvasTransform) {
        CreateTargetOverlay(playerActor, globalCanvasTransform);
        foreach(Actor enemy in Enemies) {
            CreateTargetOverlay(enemy, globalCanvasTransform);
        }
    }

    private void CreateTargetOverlay(Actor actor, Transform globalCanvasTransform) {
        var newOverlay = MonoBehaviour.Instantiate(TargetableOverlayPrefab) as TargetableOverlay;
        newOverlay.Initialize(actor, this);
        newOverlay.transform.SetParent(globalCanvasTransform, false);
        newOverlay.transform.position = new Vector2(actor.transform.position.x, actor.transform.position.y);
    }
}
