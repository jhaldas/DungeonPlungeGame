using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallWeapon : MonoBehaviour {


	public EdgeCollider2D playerCollider;
	public Collider2D weaponCollider;



	private bool isOver;
	public string name;
	private string message;
	private bool displayMessage;
	public int price;
	private bool bought;
	private bool win;

	public Canvas winxd;

	public GameObject txt;


	// Use this for initialization
	void Start () {
		message = "Buy " + name + " for $" + price + "? 'E'";
		txt.GetComponent<UnityEngine.UI.Text>().text = message;
		txt.SetActive (false);
		bought = false;

	}
	
	// Update is called once per frame
	void Update () {
		DisplayMessage ();
	}

	private void DisplayMessage(){
		if (playerCollider.IsTouching (weaponCollider)) {
			displayMessage = true;
			txt.SetActive (true);
		} else {
			displayMessage = false;
			txt.SetActive (false);
		}

		if (displayMessage == true) {

			if (bought == true) {
				win = true;
				message = "Press 'E' to equip " + name;
				txt.GetComponent<UnityEngine.UI.Text>().text = message;

				winxd.gameObject.SetActive (true);

			} else {
				/*if (Global.GetMoney () >= price) {

					txt.GetComponent<UnityEngine.UI.Text>().color = new Color(0.0f, 0.0f, 0.0f, 0.5f);

					if (Input.GetKey (KeyCode.E)) {
						bought = true;
						displayMessage = false;
						Global.SubtractMoney (price);
					}
				} else {
					txt.GetComponent<UnityEngine.UI.Text>().color = new Color(255.0f, 0.0f, 0.0f, 0.5f);
				}
			}
			*/
			
}
			
		}

	}
}
