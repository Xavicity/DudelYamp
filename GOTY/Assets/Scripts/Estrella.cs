using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estrella : MonoBehaviour {

    public float duration = 0.1f;
    bool isShowing;
	bool isInTransition;
    public float alphaFade;
    public float transition=20f;
	SpriteRenderer thisMaterial;
	// Use this for initialization
    void Start()
    {
		thisMaterial=this.GetComponent<SpriteRenderer>();
        InvokeRepeating("Fade", duration, duration);
		
	}
    void Dafe(){
        InvokeRepeating("Fade", duration, duration);
    }
    void Fade()
    {
        thisMaterial.color = Color.Lerp(thisMaterial.color, new Color(1, 1, 1, alphaFade), transition);
        if (thisMaterial.color.a==0)
        {
            
            alphaFade=1;
            Debug.Log(thisMaterial.color.a.ToString());
             Dafe();
            CancelInvoke();
           
        }else if(thisMaterial.color.a==1){
            
            alphaFade=0;
            Debug.Log(thisMaterial.color.a.ToString());
             Dafe();
            CancelInvoke();
           
        }
        
    }
}