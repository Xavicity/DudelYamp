using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muelle : MonoBehaviour {

	public float bounceForce;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D (Collision2D e){
		if(e.gameObject.tag=="Player"){
			if(e.relativeVelocity.y<=0)
				e.gameObject.GetComponent<Rigidbody2D>().velocity=new Vector2(0,bounceForce);
		}
	}
}
