using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {

	public float alturaInicial;

	public float alturaRecorrida;
	GameObject player;
	// Use this for initialization
	void Start () {
		player=GameObject.FindWithTag("Player").gameObject;
		alturaInicial=player.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(alturaRecorrida<=player.transform.position.y){
			alturaRecorrida=alturaRecorrida+(player.transform.position.y-alturaRecorrida);
		}
		this.GetComponent<Text>().text=((int)alturaRecorrida).ToString();
	}
}
