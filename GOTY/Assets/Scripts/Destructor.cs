using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Destructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D e){
		if(e.gameObject.tag=="Nube" || e.gameObject.tag=="Enemy"){
		Destroy(e.gameObject);
		}
		if(e.gameObject.tag=="Player"){
			Debug.Log(GameObject.FindWithTag("GameManager").name);
			int aux=int.Parse(GameObject.FindWithTag("Score").GetComponent<Text>().text);
			GameObject.FindWithTag("GameManager").GetComponent<GameManager>().setScore(aux);
			GameObject.FindWithTag("GameManager").GetComponent<GameManager>().LoadGameOver();
		}
	}
	
}
