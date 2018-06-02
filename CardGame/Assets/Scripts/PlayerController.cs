using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public List<Actor> targetsSelected { get; set; }

    public PlayerController(Actor playerActor, List<Actor> enemies, CardUI CardUIPrefab, TargetableOverlay TargetableOverlayPrefab) {
        Debug.Log("PlayerController");
        this.playerActor = playerActor;
        this.CardUIPrefab = CardUIPrefab;
        this.TargetableOverlayPrefab = TargetableOverlayPrefab;
        Enemies = enemies;
        CreatePlayerUI();
        currentState = PlayerSelectionState.SelectCard;
        targetsSelected = new List<Actor>();
    }

    public void CardClicked(CardUI cardUI) {
        Debug.Log("CardClicked: " + cardUI.Card.Name);
        if (currentState == PlayerSelectionState.SelectCard) {
            if (currentCardSelected == cardUI.Card) {
                currentCardSelected = null;
            } else {
                currentCardSelected = cardUI.Card;
                if(currentCardSelected.TargetsNeeded > 0) {
                    currentState = PlayerSelectionState.SelectTarget;
                } else if(currentCardSelected.TargetsNeeded == -1) {
                    targetsSelected.AddRange(Enemies);
                    Debug.Log("Card targets all enemies");
                    CastCard();
                } else {
                    Debug.Log("Card doesnt need a target");
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
                if(targetsSelected.Count == currentCardSelected.TargetsNeeded) {
                CastCard();
                }
            }
        }
    }

    public void CastCard() {
        Debug.Log("CastCard: " + currentCardSelected.Name);
        Debug.Log("Targets: " + targetsSelected.Count);
        bool canCastCard = playerActor.characterStats.CanCastCard(currentCardSelected);
        if (canCastCard) {
            Debug.Log("Card can be cast");
            bool cardWasCast = ActionManager.Instance.CastCard(currentCardSelected, playerActor, targetsSelected.Select(x => x.characterStats).ToList());
            playerActor.CardManager.CastCardFromHand(currentCardSelected);

            if (cardWasCast) {
                Debug.Log("Card was cast");
            } else {
                Debug.Log("Card was unable to be cast");
            }
            currentCardSelected = null;
            targetsSelected = new List<Actor>();
            currentState = PlayerSelectionState.SelectCard;
        } else {
            Debug.Log("Card was unable to be cast");
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
