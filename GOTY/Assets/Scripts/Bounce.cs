using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

	// Use this for initialization

	public float bounceForce;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D e){
		if(e.gameObject.tag=="Player"){
			if(e.relativeVelocity.y<=0)
				e.gameObject.GetComponent<Rigidbody2D>().velocity=new Vector3(0,bounceForce,0);
		}
	}

	/*void OnBecameInvisible(){
		Debug.Log(this.gameObject.name);
		StartCoroutine(waitTime());
		
	}

	IEnumerator waitTime() {
         yield return new WaitForSeconds(5);
		 Destroy(this.gameObject);
     }*/

}
