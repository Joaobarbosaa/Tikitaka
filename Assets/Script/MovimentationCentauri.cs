using UnityEngine;
using System.Collections;

public class MovimentationCentauri : MonoBehaviour 
{
	[SerializeField]
	float speedx;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	// Update is called once per frame
	void Update () 
	{
		this.transform.Translate(speedx, 0, 0);
		
		
		if(this.transform.position.x < -19)
		{
			this.transform.position = new Vector3(19,0.58f,0);
		}
		
	}
}
