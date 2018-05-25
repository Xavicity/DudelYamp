using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeEnemigos : MonoBehaviour {

	public GameObject generador;

	public GameObject staticEnemy;
	public GameObject fastMovingEnemy;
	public GameObject slowMovingEnemy;
	private float probStaticEnemy=0.03f;
	private float probFastMovingEnemy=0.02f;
	private float probSlowMovingEnemy=0.01f;
	// Use this for initialization
	void Start () {
		probFastMovingEnemy+=probStaticEnemy;
		probSlowMovingEnemy+=probFastMovingEnemy;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D e){
		if(e.gameObject.tag=="Detector"){
			
			GameObject aux=new GameObject();
			aux=Instantiate(generador, this.transform.parent);
			aux.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+2f,this.transform.position.z);
			createEnemies();
			Destroy(this.gameObject);
		}
	}

	void createEnemies(){
		if(GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity.y<15){
			BoxCollider2D collider=this.gameObject.GetComponent<BoxCollider2D>();
			Vector2 size=collider.bounds.size;
			float left=this.transform.position.x-Mathf.Abs(size.x/2);
			float right=this.transform.position.x+Mathf.Abs(size.x/2);
			float btm=this.transform.position.y-Mathf.Abs(size.y/2);
			float top=this.transform.position.y+Mathf.Abs(size.y/2);
			float x,y;
			float spawnProbability=Random.value;
			Vector3 area;
			area=staticEnemy.GetComponent<Renderer>().bounds.size;
			
			GameObject container=GameObject.FindWithTag("Obstaculos");

					
				x=Random.Range(-14,14);
				y=Random.Range(btm,top);
				float angle=360f;
				/*if(Physics2D.OverlapBox(new Vector2(x,y),new Vector2(area.x,area.y),angle).gameObject.tag=="Nube"){
					Debug.Log("Colisiona");
				}else{*/
					if(spawnProbability<probStaticEnemy){
						GameObject aux=Instantiate(staticEnemy,container.transform);
						aux.transform.position=new Vector3(x,y,8);
					}else if(spawnProbability>probStaticEnemy && spawnProbability<probFastMovingEnemy){
						GameObject aux=Instantiate(fastMovingEnemy,container.transform);
						aux.transform.position=new Vector3(x,y,8);
					}else if(spawnProbability>probFastMovingEnemy && spawnProbability<probSlowMovingEnemy){
						GameObject aux=Instantiate(slowMovingEnemy,container.transform);
						aux.transform.position=new Vector3(x,y,8);
					}else{
						Debug.Log("osdenf");
					}
				
				//}
			}
			
	}
}
