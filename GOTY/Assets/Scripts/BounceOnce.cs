using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOnce : MonoBehaviour {


	public float bounceForce;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D e){
		if(e.gameObject.tag=="Player"){
			if(e.relativeVelocity.y<=0){
				e.gameObject.GetComponent<Rigidbody2D>().velocity=new Vector2(0,bounceForce);
				StartCoroutine(FadeImage(true));
			}

		}
	}

	
    IEnumerator FadeImage(bool fadeAway)
    {
		if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
				Color aux=this.gameObject.GetComponent<SpriteRenderer>().color;
                this.gameObject.GetComponent<SpriteRenderer>().color=new Color(aux.r,aux.g,aux.b,i);
                yield return null;
            }
			Destroy(this.gameObject);
		}
	}
}
