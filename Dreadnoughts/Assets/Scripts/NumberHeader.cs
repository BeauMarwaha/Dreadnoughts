using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberHeader : MonoBehaviour {
	public Text mText;
	public GameObject turret;
	public float angle;
	public float start = 526.0f;
	// Use this for initialization
	void Start () {
        turret = GameObject.Find("Dreadnought");
		for(int x = 360 ; x < 365; x++){

			mText.text += x%366 + " | ";

		}

		for(int x = 0 ; x < 400; x++){

			mText.text += x%366 + " | ";

		}
	}

	// Update is called once per frame
	void Update () {
		angle = turret.transform.rotation.eulerAngles.y;
		this.gameObject.transform.localPosition = new Vector3(start - angle*99, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z);

	}
}
