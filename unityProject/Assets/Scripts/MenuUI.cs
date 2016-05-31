using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class MenuUI : MonoBehaviour {

	public Canvas quitMenu;
	public Canvas startMenu;
	public Button noSpidersButton;
	public Button spidersNormalButton;
	public Button spidersBigAmountButton;
	public Button btnExit;
	public Button startButton;

	public GameObject spiders1;
	public GameObject spiders2; 

	/** Obiekt menu.*/
	private Canvas mainMenu;
	
	void Start (){
		mainMenu = (Canvas)GetComponent<Canvas>();
		mainMenu.enabled = false;
		quitMenu = quitMenu.GetComponent<Canvas>(); 

		noSpidersButton = btnExit.GetComponent<Button> ();
		spidersNormalButton = btnExit.GetComponent<Button> ();
		spidersBigAmountButton = btnExit.GetComponent<Button> ();

		quitMenu.enabled = false; 

		spiders1.SetActive(false);
		spiders2.SetActive(false);

		Time.timeScale = 0;//Zatrzymanie czasu.

	}


	void Update () {
		if(quitMenu.enabled || startMenu.enabled || mainMenu.enabled){
			Screen.lockCursor = false;
			Screen.showCursor = true;
		} 
		if (Input.GetKeyUp (KeyCode.M)) { 
			mainMenu.enabled = !mainMenu.enabled;

			
			if(mainMenu.enabled) {;
				Time.timeScale = 0;
				quitMenu.enabled = false; 
				spidersNormalButton.enabled = true; 
				btnExit.enabled = true; 
			}else {

				Time.timeScale = 1;
				quitMenu.enabled = false;
			}
			
		}
	}


	public void PrzyciskWyjscie() {
		quitMenu.enabled = true;
		mainMenu.enabled = false;
		Screen.showCursor = false;
	}


	public void PrzyciskNieWychodz(){
		quitMenu.enabled = false;
		mainMenu.enabled = true;
	}


	public void NormalSpidersAmount(){
		mainMenu.enabled = false; 
		spiders1.SetActive (true);
		spiders2.SetActive (false);
		Screen.showCursor = false;
		Time.timeScale = 1;
	}

	public void SpidersBigAmount(){
		mainMenu.enabled = false;
		spiders1.SetActive (true);
		spiders2.SetActive (true);
		Screen.showCursor = false;
		Time.timeScale = 1;
	}

	public void NoSpiders(){
		mainMenu.enabled = false;
		spiders1.SetActive(false);
		spiders2.SetActive (false);
		Screen.showCursor = false;
		Time.timeScale = 1;
	}

	public void StartButton(){
		startMenu.enabled = false;
		mainMenu.enabled = true;
		Time.timeScale = 1;
	}
	
	public void QuitYes () {
		Application.Quit();
		
	}

	public void QuitNo(){
		quitMenu.enabled = false;
		Screen.showCursor = false;
		Time.timeScale = 1;
	}
}
