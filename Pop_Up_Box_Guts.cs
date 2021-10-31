using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pop_Up_Box_Guts : MonoBehaviour
{
	//if helped
	private bool helped;

	//stuff for text box ui
	public Text textBox;
	public GameObject textGO;
	public string fullText;
	private string currentText;
	public float delay;
	Medicine Medicine = Player.GetComponent<Medicine>();



	// Use this for initialization
	void Start()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && Medicine.health>3)
		{
			if (Medicine.health >= 3)
			{
				//if the player hits e at any point helped becomes true
				helped = true;
			}
			else
			{
				StartCoroutine(PopUpText("I guess I get it... Others need help"));
			}
		}

		if (helped)
		{
			Medicine.health -= 3
			StartCoroutine(PopUpText("Thank you kindly. They’ll get me outta here as soon as they come back!"));
			helped = false;
		}

	}

	private void OnTriggerEnter(Collider player)
	{
		//when player enters collider, call textbox
		Debug.Log("COLLIDED");

		textGO.SetActive(true);

		StartCoroutine(PopUpText("God it hurts... Oh sweet jesus fuck..."));

	}

	private void OnTriggerExit(Collider player)
	{
		//when player enters collider, call textbox
		textGO.SetActive(false);

	}

	IEnumerator PopUpText(string line)
	{
		Debug.Log("pop up text started");
		fullText = line;

		for (int i = 0; i < fullText.Length; i++)
		{

			Debug.Log(i);
			Debug.Log(fullText.Length);
			float delayTemp = delay;
			string check = fullText.Substring(i, 1);
			string check2 = " ";
			Debug.Log(check);
			if (check == check2)
			{
				delay = 0;
			}

			currentText = fullText.Substring(0, i + 1);
			textBox.text = currentText;
			yield return new WaitForSeconds(delay);
			delay = delayTemp;
		}

		yield return new WaitForSeconds(delay);

	}
}
