using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour {

	private GameObject player;
	private Transform camera;
	
	// Use this for initialization
	void Start () {
		player=GameObject.FindWithTag("Player").gameObject;
		camera=GameObject.FindWithTag("MainCamera").gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(camera.position.y<player.transform.position.y){
			camera.position=new Vector3(camera.position.x,player.GetComponent<Transform>().position.y,camera.position.z);
			Debug.Log("Reposicionando");
		}
	}
}
