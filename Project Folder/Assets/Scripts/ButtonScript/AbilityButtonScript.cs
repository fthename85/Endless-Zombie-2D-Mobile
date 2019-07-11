using UnityEngine;
using AbilityInterface;

public class AbilityButtonScript : MonoBehaviour {
	 AbilitySystem.IAbilityHandler AbilitiesOfPlayer;
	void Start(){
		AbilitiesOfPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<AbilitySystem.IAbilityHandler>();
	}

	public void DefaultAttack()
	{
		AbilitiesOfPlayer.DefaultAttack();
	}
	public void Ability_1()
	{
		AbilitiesOfPlayer.Ability_1();
	}
	public void Ability_2()
	{
		AbilitiesOfPlayer.Ability_2();
	}
	public void Ability_3()
	{
		AbilitiesOfPlayer.Ability_3();
	}

}
