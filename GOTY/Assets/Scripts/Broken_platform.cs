using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken_platform : MonoBehaviour {

	private GameObject nubeIzq;
	private GameObject nubeDch;

	private bool anim;
	private bool disappearing;
	// Use this for initialization
	void Start () {
		nubeIzq=this.transform.GetChild(0).gameObject;
		nubeDch=this.transform.GetChild(1).gameObject;
		disappearing=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(anim){
			doAnim();
			if(!disappearing)
				StartCoroutine(FadeImage(true));
		}

	}

	void OnTriggerEnter2D (Collider2D e){
		if(e.gameObject.tag=="Player"){
			if(e.attachedRigidbody.velocity.y<=0){
			anim=true;
			this.GetComponent<EdgeCollider2D>().enabled=false;
			this.GetComponent<BoxCollider2D>().enabled=false;
			}
		}
	}

	public void doAnim(){
		nubeIzq.transform.Rotate(0,0,1);
		nubeDch.transform.Rotate(0,0,-1);
		nubeIzq.transform.Translate(-0.1f,-0.1f,0);
		nubeDch.transform.Translate(0.1f,-0.1f,0);
	}

	IEnumerator FadeImage(bool fadeAway)
    {
		disappearing=true;
		if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
				Color aux1=this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color;
				Color aux2=this.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color;
                this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color=new Color(aux1.r,aux1.g,aux1.b,i);
				this.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color=new Color(aux2.r,aux2.g,aux2.b,i);
                yield return null;
            }
			Destroy(this.gameObject);
		}
	}
}
