using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
	public GameObject[] DamageTextUI;
	GameObject[] Enemy;
	GameObject Player;
	
	
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		InvokeRepeating("TimeCountDownDisplay", 1f, 1.0f);
	}
	void Update()
	{
		CurrentWaveUIDisplay();
		CurrentHealthDisplay();
		CurrentScoreDisplay();
	}




	#region of CurrentWave
	//CurrentWaveUI Functions
	public TextMeshProUGUI WaveUI;
	int currentWave = 0;
	void CurrentWaveUIDisplay()
	{
		Enemy = GameObject.FindGameObjectsWithTag("Enemy");
		if(Enemy.Length < 1)
		{
			currentWave++;
			WaveUI.text = "Wave: " + currentWave.ToString();
		}
	}
	#endregion
	
	#region of Timer
	public TextMeshProUGUI TimeUI;
	int Seconds = 0;
	void TimeCountDownDisplay()
	{
		Seconds++;

		TimeUI.text = "Time: " + Seconds.ToString();
	}
	#endregion

	#region of PlayerHealthUI / PlayerScore
	public TextMeshProUGUI HealthUI;
	float CurrentHealth;

	void CurrentHealthDisplay()
	{
		if(CurrentHealth != Player.GetComponent<CharacterStats>().Health)
		{
			CurrentHealth = Player.GetComponent<CharacterStats>().Health;
			HealthUI.text = "Health: " + CurrentHealth.ToString();
			if(CurrentHealth < 1)
			{
				PlayerPrefs.SetInt("PreviousScore", CurrentScore);
				if(CurrentScore > PlayerPrefs.GetInt("HighScore"))
				{
					PlayerPrefs.SetInt("HighScore", CurrentScore);
				}
			}
		}
		
	}
	#endregion

	#region of CurrentScoreUI
	public TextMeshProUGUI CurrentScoreUI;
	[HideInInspector]
	public int CurrentScore;

	void CurrentScoreDisplay()
	{
		CurrentScoreUI.text = "Score: " + CurrentScore.ToString();
	}
	#endregion


	public void DisplayDamageTaken(float DamageTaken, float TargetMaxHealth, Transform Target)
	{
			
		// if(DamageTaken >= TargetMaxHealth * 0.30f)
		// {
			if(!Target.GetComponent<EnemyFollowScript>().isFlippedSprite)
			{
				DamageTextUI[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = DamageTaken.ToString();
				Instantiate(DamageTextUI[0],Target.position,Quaternion.identity);
			}
			else{
				
				DamageTextUI[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = DamageTaken.ToString();
				Instantiate(DamageTextUI[1],Target.position,Quaternion.identity);
			}
			
			
		//}
		/*
		else if (DamageTaken < TargetMaxHealth * 0.30f){
			DamageTextUI[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = DamageTaken.ToString();
			Instantiate(DamageTextUI[1],Target.position,Quaternion.identity,Target);
		}

		else if(DamageTaken >= TargetMaxHealth/2 && DamageTaken < TargetMaxHealth)
		{
			DamageTextUI[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = DamageTaken.ToString();
			Instantiate(DamageTextUI[2],Target.position,Quaternion.identity);
		}*/
			
	}
}
