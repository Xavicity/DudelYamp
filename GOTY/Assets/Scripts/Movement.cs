using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {


	public float hor,ver;

	public float horizontalSpeed=10;

	[SerializeField]

	private float verticalSpeed;
	Rigidbody2D rb;

	Animator anim;

	public bool isDead=false;

	public GameObject proyectile;
	public float timeBetweenShoots;
	private float timeCounter;
	Color c;
	// Use this for initialization
	void Start () {
		rb= this.GetComponent<Rigidbody2D>();
		anim=this.GetComponent<Animator>();
		rb.velocity=new Vector3(0f,30f,0);
		timeCounter=0;
		c=this.GetComponent<SpriteRenderer>().color;
	}
	
	// Update is called once per frame
	void Update () {
		timeCounter+=Time.deltaTime;
		if(!isDead){
			verticalSpeed=rb.velocity.y;
			hor=Input.GetAxis("Horizontal");
			rb.velocity= new Vector2(hor*horizontalSpeed,rb.velocity.y);
			if(rb.velocity.y<=0){
				anim.SetBool("Falling",true);
			}else{
				anim.SetBool("Falling",false);
			}
			if(Input.GetKeyDown(KeyCode.Space) && timeCounter>timeBetweenShoots){
				anim.SetTrigger("Shooting");
				StartCoroutine(Wait());
				
				timeCounter=0;

			}
		}
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds(0.25f);
		GameObject aux=Instantiate(proyectile,this.transform.position+new Vector3(0,2,0),this.transform.rotation);
	}
	void OnBecameInvisible(){
		if(this.transform.position.x<-15){
			this.transform.position=new Vector3(15f,this.transform.position.y,this.transform.position.z);
		}else{
			this.transform.position=new Vector3(-15f,this.transform.position.y,this.transform.position.z);
		}
	}
	public void die(){
		isDead=true;
		
		this.GetComponent<SpriteRenderer>().color=new Color(255,0,0,c.a);
		InvokeRepeating("FadeImage(true)",1,0.1f);

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
				//fadeImage.color=Color.Lerp(fadeImage.color,new Color(1,1,1,1),transition);
                this.gameObject.GetComponent<SpriteRenderer>().color=new Color(aux.r,aux.g,aux.b,i);
                yield return null;
            }
			Destroy(this.gameObject);
		}
	}
}
