using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	public static GameManager control; 
	private int score=0;
	void Awake () {
		//Singleton( Con esto hago que solo exista un solo GameControl)
		if(control==null){
			control=this;
			//Esto hace que este objeto no se destruya nunca ni siquiera entre escenas
			DontDestroyOnLoad(gameObject);
		}else if(control!=this){

			Destroy(gameObject);
		}
		//Fin Singleton
	}
	void Update(){
		if(SceneManager.GetActiveScene().buildIndex==2){
			GameObject.FindWithTag("Score").GetComponent<Text>().text="Your     final     score     is    :    "+score.ToString();
		}
	}
	
	public void LoadGame(){		
		SceneManager.LoadScene(1);
	}
	public void LoadGameOver(){
		SceneManager.LoadScene(2);
		
	}

	public void setScore(int actualScore){
		this.score=actualScore;
	}
}
