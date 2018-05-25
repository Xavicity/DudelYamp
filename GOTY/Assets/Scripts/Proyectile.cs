using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour {

	public float bulletForce;
	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody2D>().velocity=new Vector3(0,bulletForce,0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameInvisible(){
		Destroy(this.gameObject);
	}

	void OnTriggerEnter2D (Collider2D e){
		if(e.tag=="Enemy"){
			e.gameObject.BroadcastMessage("die");
		}
	}
}
