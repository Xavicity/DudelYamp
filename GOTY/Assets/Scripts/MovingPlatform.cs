using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public float velocity=0.1f;
	public int direccion=-1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.x<-19){
			direccion=1;
		}else if(this.transform.position.x>19){
			direccion=-1;
		}
		if(direccion<0){
			this.transform.position=new Vector3(this.transform.position.x-velocity,this.transform.position.y,this.transform.position.z);
		}else{
			this.transform.position=new Vector3(this.transform.position.x+velocity,this.transform.position.y,this.transform.position.z);
		}

		
	}
}
