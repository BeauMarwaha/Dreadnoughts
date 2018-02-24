using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptNumber : MonoBehaviour {
	public Text mText;
	// Use this for initialization
	void Start () {
		for(int x = 0 ; x < 400; x++){
			
			mText.text += x%366 + " | ";
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.localPosition = this.gameObject.transform.localPosition - new Vector3(1.0f,0.0f,0.0f);
		if (this.gameObject.transform.localPosition.x < 595.0f) {
			Vector3 loop = new Vector3 (4862.0f, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z);
			this.gameObject.transform.localPosition = loop;
		}
	}
}
