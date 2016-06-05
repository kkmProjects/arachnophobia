using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class MenuUI : MonoBehaviour {

	public Canvas quitMenu; //menu wyjścia
	public Canvas startMenu; //menu główne
	public Button noSpidersButton; //przycisk brak pająków
	public Button spidersNormalButton; // przycisk normalna ilość pająków
	public Button spidersBigAmountButton; //przycisk dużo pająków
	public Button btnExit; //przycisk wyjście
	public Button startButton; //przycisk start

	public GameObject spiders1; //zawiera obiekty pająków
	public GameObject spiders2; //zawiera obiekty pająków

	public GameObject prefab; //zawiera model pająka
	private Transform gracz; //zaiwera obiekt gracza
	private Vector3 pozycjaNowegoPajaka; //pozycja na jakiej zostanie dodany nowy pająk
	private List<GameObject> recznePajaki = new List<GameObject>(); //lista ręcznie dodanych pająków

	
	private Canvas mainMenu; //obiekt menu
	
	void Start (){ 
		mainMenu = (Canvas)GetComponent<Canvas>(); //pobranie menu podpiętego do skryptu
		mainMenu.enabled = false; //ustawienie widoczności menu
		quitMenu = quitMenu.GetComponent<Canvas>(); //pobranie menu wyjścia

		noSpidersButton = btnExit.GetComponent<Button> (); //pobranie przycisków 
		spidersNormalButton = btnExit.GetComponent<Button> ();
		spidersBigAmountButton = btnExit.GetComponent<Button> ();

		quitMenu.enabled = false; //ustawienie widoczności menu

		spiders1.SetActive(false); //ustawienie aktywności obiektów 
		spiders2.SetActive(false);

		Time.timeScale = 0; //zatrzymanie czasu.

	}


	void Update () {
		if(quitMenu.enabled || startMenu.enabled || mainMenu.enabled){//sterowanie widocznością kursora
			Screen.lockCursor = false; 
			Screen.showCursor = true;
		} 
		if (Input.GetKeyUp (KeyCode.M)) { //wywołanie menu
			mainMenu.enabled = !mainMenu.enabled;

			
			if(mainMenu.enabled) { //menu aktywne
				Time.timeScale = 0;
				quitMenu.enabled = false; 
				//spidersNormalButton.enabled = true; 
				//btnExit.enabled = true; 
			}else {//menu nieaktywne

				Time.timeScale = 1;
				quitMenu.enabled = false;
			}
			
		}
		if (Input.GetKeyUp (KeyCode.F1)) { //dodanie pojedynczego pająka
			gracz = GameObject.FindWithTag("Player").transform; //pobranie obiektu gracza
			pozycjaNowegoPajaka = new Vector3(gracz.position.x+1f, gracz.position.y, gracz.position.z+1f); //pozycja pająka na podstawie pozycji gracza
			GameObject obj = (GameObject) Instantiate (prefab, pozycjaNowegoPajaka, Quaternion.identity); //nowa instancja pająka
			obj.SetActive(true); //aktywowanie pająka
			recznePajaki.Add(obj); //dodanie pająka do listy
		}
		if (Input.GetKeyUp (KeyCode.F2)) {//usunięcię ręcznie dodanych pająków
			foreach (var tmp in recznePajaki)
			{
				Destroy(tmp); //zniszczenie obiektu pająka
			}
		}
			

	}


	public void PrzyciskWyjscie() { //obsługa przycisku wyjścia
		quitMenu.enabled = true;
		mainMenu.enabled = false;
		Screen.showCursor = false;
	}


	//public void PrzyciskNieWychodz(){ //obsługa przycisku 
		//quitMenu.enabled = false;
		//mainMenu.enabled = true;
	//}


	public void NormalSpidersAmount(){ //obsługa przycisku normalnej ilości pająków
		mainMenu.enabled = false; 
		spiders1.SetActive (true);
		spiders2.SetActive (false);
		Screen.showCursor = false;
		Time.timeScale = 1;
	}

	public void SpidersBigAmount(){ //obsługa przycisku dużej ilości pająków
		mainMenu.enabled = false;
		spiders1.SetActive (true);
		spiders2.SetActive (true);
		Screen.showCursor = false;
		Time.timeScale = 1;
	}

	public void NoSpiders(){ //obsługa przycisku braku pająków
		mainMenu.enabled = false;
		spiders1.SetActive(false);
		spiders2.SetActive (false);
		Screen.showCursor = false;
		Time.timeScale = 1;
	}

	public void StartButton(){ //obsługa przycisku start
		startMenu.enabled = false;
		mainMenu.enabled = true;
		Time.timeScale = 1;
	}
	
	public void QuitYes () { //obsługa przycisku tak w menu wyjścia
		Application.Quit();
		
	}

	public void QuitNo(){ //obsługa przycisku nie w menu wyjścia
		quitMenu.enabled = false;
		Screen.showCursor = false;
		Time.timeScale = 1;
	}
}
