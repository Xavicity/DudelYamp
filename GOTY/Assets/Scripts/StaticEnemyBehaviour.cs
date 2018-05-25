using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemyBehaviour : MonoBehaviour {

	Animator anim;
	void Start(){
		anim=this.GetComponent<Animator>();
	}
	void OnTriggerEnter2D(Collider2D e){
		if(e.tag=="Player"){
				GameObject.FindWithTag("Player").GetComponent<Movement>().die();
		}
	}

	public void die(){
		anim.SetTrigger("die");
		StartCoroutine(FadeImage(true));
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
