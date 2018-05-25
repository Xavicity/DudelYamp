using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour {

	public GameObject nubeVerde;
	public GameObject nubeBlanca;
	public GameObject nubeMarron;
	public GameObject nubeAzul;

	public GameObject generador;
	// Use this for initialization

	private float probNubeVerde=0.7f;
	private float probNubeBlanca=0.85f;
	private float probNubeMarron=0.95f;
	private float probNubeAzul=1;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D e){
		if(e.gameObject.tag=="Detector"){
			
			GameObject aux=new GameObject();
			aux=Instantiate(generador, this.transform.parent);
			aux.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+2f,this.transform.position.z);
			createPlatforms();
			Destroy(this.gameObject);
		}
	}

	void createPlatforms(){
		float limit=Random.Range(1,3);
		BoxCollider2D collider=this.gameObject.GetComponent<BoxCollider2D>();
		Vector2 size=collider.bounds.size;
		float left=this.transform.position.x-Mathf.Abs(size.x/2);
		float right=this.transform.position.x+Mathf.Abs(size.x/2);
		float btm=this.transform.position.y-Mathf.Abs(size.y/2);
		float top=this.transform.position.y+Mathf.Abs(size.y/2);
		float x,y;
		
		Vector3 area;
		area=nubeBlanca.GetComponent<Renderer>().bounds.size;
		
		GameObject container=GameObject.FindWithTag("Obstaculos");

		for(int i=0;i<limit;i++){	
			float spawnProbability=Random.value;		
			x=Random.Range(-14,14);
			y=Random.Range(btm,top);
			float angle=360f;
			/*if(Physics2D.OverlapBox(new Vector2(x,y),new Vector2(area.x,area.y),angle).gameObject.tag=="Nube"){
				Debug.Log("Colisiona");
			}else{*/
				if(spawnProbability<probNubeVerde){
					GameObject aux=Instantiate(nubeVerde,container.transform);
					aux.transform.position=new Vector3(x,y,8);
				}else if(spawnProbability>probNubeVerde && spawnProbability<probNubeBlanca){
					GameObject aux=Instantiate(nubeBlanca,container.transform);
					aux.transform.position=new Vector3(x,y,8);
				}else if(spawnProbability>probNubeBlanca && spawnProbability<probNubeMarron){
					print("marron");
					GameObject aux=Instantiate(nubeMarron,container.transform);
					aux.transform.position=new Vector3(x,y,8);
				}else if(spawnProbability>probNubeMarron && spawnProbability<probNubeAzul){
					GameObject aux=Instantiate(nubeAzul,container.transform);
					aux.transform.position=new Vector3(x,y,8);
				}else{
					Debug.Log("osdenf");
				}
			
			//}
		}
	}
}
	