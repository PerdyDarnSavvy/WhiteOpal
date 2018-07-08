using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardGame.Abstract;
using CardGame.UI;

public class ResourceUI : MonoBehaviour {

	private Resource currentResource;
	private PercentScale currentPercentScale;


	public ResourceUI(Resource actorResource, Transform actorTransform, PercentScale percentScale, float counter){
		currentResource = actorResource;
		currentPercentScale = percentScale;
		currentPercentScale.transform.SetParent(actorTransform, false);
        currentPercentScale.transform.position = new Vector2(actorTransform.localPosition.x, (actorTransform.localPosition.y - counter));
		currentPercentScale.SetType(currentResource.Type);

	}

	public void updateValue() {
		int newPercent = (int)(currentResource.GetCurrentPercent() * 100f);
		currentPercentScale.UpdateScale(newPercent);
	}


}
