using UnityEngine;
using TMPro;
public class SetScore : MonoBehaviour {

public TextMeshProUGUI HighScoreUI;
public TextMeshProUGUI PreviousScoreUI;


GameObject Player;
	// Use this for initialization
	void Start () {
		HighScoreUI.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
		PreviousScoreUI.text = "PreviousScore: " + PlayerPrefs.GetInt("PreviousScore").ToString();
	}
}
