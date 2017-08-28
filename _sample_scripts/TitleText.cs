using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleText : MonoBehaviour {
    private Text txtRef;

    // Use this for initialization
    void Start () {
        txtRef = GameObject.Find("Text").GetComponent<Text>();
        txtRef.text = "less text";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
