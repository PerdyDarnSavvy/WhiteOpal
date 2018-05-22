using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentScale : MonoBehaviour {

	[SerializeField]
	private int Percent;
	private Transform VariableBar { get; set; }

	// Use this for initialization
	void Start() {
		VariableBar = transform.Find("HPContainer");
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
}
