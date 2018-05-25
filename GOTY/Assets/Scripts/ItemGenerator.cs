using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

	
	public float probCamaElastica=0.01f;
	public float probMuelle=0.03f;
	// Use this for initialization
	void Start () {
		probMuelle+=probCamaElastica;
		float r=Random.value;
		if(r<probCamaElastica){
			this.transform.GetChild(0).gameObject.active=true;
		}else if(r>probCamaElastica && r<probMuelle){
			this.transform.GetChild(1).gameObject.active=true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
