using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePlayer : MonoBehaviour {

	private Animator anim;
	// Use this for initialization
	void Start () {
		anim=this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(this.GetComponent<Rigidbody2D>().velocity.y<=0){
				anim.SetBool("Falling",true);
			}else{
				anim.SetBool("Falling",false);
			}
	}
}
