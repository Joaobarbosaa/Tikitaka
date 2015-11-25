using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{
    private Text text;

	private float tempo;

	// Use this for initialization
	void Start () 
    {
		this.text = this.gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () 
    {
		tempo += Time.deltaTime;
		this.text.text = "Time: " + Mathf.RoundToInt(tempo).ToString();
		PlayerPrefs.SetInt ("Score", Mathf.RoundToInt(tempo));
	}
}
