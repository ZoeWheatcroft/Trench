using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pop_Up_Box_Thigh : MonoBehaviour
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
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (Medicine.health >= 1)
			{
				//if the player hits e at any point helped becomes true
				helped = true;
			}
			else
			{
				//empty squirt
				Medicine.Squirt();
				StartCoroutine(PopUpText("You bastard, you haven't even got enough for a small bullet wound?? I'LL DIE HERE! IDIOT!"));
			}
		}

		if (helped)
		{
			Medicine.Squirt();
			Medicine.health -= 1;
			StartCoroutine(PopUpText("Thanks, I appreciate it. Man that stuff works fast…"));
			helped = false;
		}

	}

	private void OnTriggerEnter(Collider player)
	{
		//when player enters collider, call textbox
		Debug.Log("COLLIDED");

		textGO.SetActive(true);

		StartCoroutine(PopUpText("I can't go on, somethings in my thigh... Please, I only need a little medicine..."));
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
