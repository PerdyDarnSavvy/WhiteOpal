using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentScale : MonoBehaviour {

	[SerializeField]
	private int Percent;
	private Transform VariableBar { get; set; }

	// Use this for initialization
	void Awake() {
		VariableBar = transform.Find("Container");
		UpdateScale(100);
	}

	public void UpdateScale(int? newPercent) {
		if(newPercent.HasValue) {
			Percent = newPercent.Value;
		}

		if(VariableBar != null) {
			float newScale = GetNewScale();
			if(VariableBar.localScale.x != newScale) {
				VariableBar.localScale = new Vector3(newScale, VariableBar.localScale.y, VariableBar.localScale.z);
			}
		}
	}

	private float GetNewScale() {
		return ((float)Percent / 100f);
	}

	public void SetType(int type) {
		var BarFront = VariableBar.Find("BarFront");
		if (BarFront != null) {
			var BarSprite = BarFront.GetComponent<SpriteRenderer>();
			switch(type) {
				case 1:
					BarSprite.color = Color.red;
					break;
				case 2:
					BarSprite.color = Color.green;
					break;
				default:
					BarSprite.color = Color.blue;
					break;
			}
			Debug.Log(BarSprite.color);
		}
		Debug.Log("Made it here!");
	}
}
