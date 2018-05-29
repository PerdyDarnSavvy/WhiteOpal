using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardGame.Abstract;
using CardGame.UI;

public enum PlayerSelectionState {
    SelectCard, SelectTarget, Disabled
}

public class PlayerController {

    private CardUI CardUIPrefab;
    private TargetableOverlay TargetableOverlayPrefab;

    private Actor playerActor { get; set; }
    private List<Actor> Enemies { get; set; }

    public PlayerSelectionState currentState { get; set; }
    public Card currentCardSelected { get; set; }
    public Actor targetSelected { get; set; }

    public PlayerController(Actor playerActor, List<Actor> enemies, CardUI CardUIPrefab, TargetableOverlay TargetableOverlayPrefab) {
        Debug.Log("PlayerController");
        this.playerActor = playerActor;
        this.CardUIPrefab = CardUIPrefab;
        this.TargetableOverlayPrefab = TargetableOverlayPrefab;
        Enemies = enemies;
        CreatePlayerUI();
        currentState = PlayerSelectionState.SelectCard;
    }

    public void CardClicked(CardUI cardUI) {
        if (currentState == PlayerSelectionState.SelectCard) {
            if (currentCardSelected == cardUI.Card) {
                currentCardSelected = null;
            } else {
                currentCardSelected = cardUI.Card;
                currentState = PlayerSelectionState.SelectTarget;
            }
        }
    }
    
    public void TargetClicked(Actor target) {
        if (currentState == PlayerSelectionState.SelectTarget) {
            if (targetSelected == target) {
                targetSelected = null;
            } else {
                targetSelected = target;
                var cardWasCast = playerActor.CardManager.CastCard(currentCardSelected, playerActor.characterStats, targetSelected.characterStats);
                if (cardWasCast) {
                    currentCardSelected = null;
                    targetSelected = null;
                    currentState = PlayerSelectionState.SelectCard;
                } else {
                    Debug.Log("Card was unable to be cast");
                    targetSelected = null;
                    currentState = PlayerSelectionState.SelectTarget;
                }
            }
        }
    }

    public void CreatePlayerUI() {
        var globalCanvasTransform = GameManager.Instance.canvas.transform;
        CreatePlayerHand(globalCanvasTransform);
        CreateTargetOverlays(globalCanvasTransform);
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
