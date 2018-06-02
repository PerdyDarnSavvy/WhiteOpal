using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CardGame.Abstract;
using CardGame.Interfaces;
using CardGame.Cards;
using CardGame.Other;

public class ActionManager : Singleton<ActionManager> {

	public void ExecuteActions(List<iAction> actions,  Character caster, List<Character> targets) {
		foreach(var action in actions) {
			action.execute(targets, caster);
		}
	}
	
	public bool CastCard(Card card, Actor caster, List<Character> targets) {
		if(caster.characterStats.CanCastCard(card)) {
			caster.characterStats.CastCard(card, targets);
			ExecuteActions(card.Actions, caster.characterStats, targets);
			return true;
		}

		return false;
	}
}
