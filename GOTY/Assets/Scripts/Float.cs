using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour {

	public float floatSpeed=0.02F;
	public float floatHeight=1;
	public float lowLimit;
	public float upperLimit;
	
	public bool goingUp=true;
	// Use this for initialization
	void Start () {
		float height;
		height=this.transform.position.y;
		lowLimit=height-floatHeight;
		upperLimit=height+floatHeight;
		floatSpeed=floatSpeed*0.0001f;
	}
	
	// Update is called once per frame
	void Update () {
		if(goingUp){
			if(this.transform.position.y>upperLimit){
				goingUp=false;
			}else{
				this.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+floatSpeed,this.transform.position.z);
			}
		}else{
			if(this.transform.position.y<lowLimit){
				goingUp=true;
			}else{
				this.transform.position=new Vector3(this.transform.position.x,this.transform.position.y-floatSpeed,this.transform.position.z);
			}
		}
	}
}
