using UnityEngine;
using UnitInterface;
using AbilityInterface;

public class CharacterSkills :  MonoBehaviour, AbilitySystem.IAbilityHandler {
	public Transform DefaultAttackPosition;
    [HideInInspector]
    public float AttackRange, Damage;
    public LayerMask EnemyMask;
    [HideInInspector]
    public Animator animator, MainCameraAnimator;
    [HideInInspector]
    public AnimationClip[] _animationClips;
    [HideInInspector]
    public bool isChanneling = false;

	public virtual void DefaultAttack()
	{
		Debug.Log("DefaultAttack");
	}
	public virtual void Ability_1()
	{
		Debug.Log("Ability_1");
	}
    public virtual void Ability_2()
	{
		Debug.Log("Ability_2");
	}
    public virtual void Ability_3()
	{
		Debug.Log("Ability_3");
	}
}
