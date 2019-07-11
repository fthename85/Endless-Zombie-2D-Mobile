using UnityEngine;
using UnitInterface;
public class CharacterStats :  MonoBehaviour, UnitType.IUnit, UnitType.IMovingUnit, 
UnitType.IAttacker, UnitType.IVulnerable, UnitType.IHealable, UnitType.IKnockBackAble{
	//CharacterStats Variables
	#region of Unit Interface Variables
		#region of name Variables
		public string characterName;
		public string UnitName{
			get
			{
				return characterName;
			} 
		}
		#endregion
		#region of Health Variables
	public float _health;
	public float Health
	{
		get
		{
			return _health;
		}
		set{
			if (_health > 0)
			{
				_health = value;
			}
		}
	}
	#endregion
	#endregion
	#region of Attacker Interface  Variables
		#region of Damage Variables
		public float _unitDamage;
		public float UnitDamage{
			get{
				if(_unitDamage >= 0)
				return _unitDamage;
				else return 0;
			}
			}
		#endregion
		#region of AttackRange Variables
		public float _attackRange;
		public float AttackRange{
			get{
				if(_attackRange >= 0){return _attackRange;}
				else{return 0;}
				
			}
		}
	#endregion
	#endregion
	#region of MovingUnit Interface Variables
	public float _movementSpeed;
	public float MovementSpeed 
	{
		get{
			if(_movementSpeed >= 0)
			{return _movementSpeed;}
			else {return 0;}
		}
	}
	#endregion
	#region of Vulnerability Interface  Variables
	public bool _isVulnerable;
	public bool isVulnerable{
		get{ return _isVulnerable;}
	}
	#endregion	
	#region of Healable Interface variables
	public bool _isHealable;
	public bool isHealable{
		get{
			return _isHealable;
		}
	}

	#endregion
	#region of Knockbackable Interface variables
	public bool _isKnockBackAble;
	public bool isKnockBackAble{get{ return _isKnockBackAble;}}
	#endregion
	
	
	//Charater Methods
#region of Health Methods
	public virtual void TakeDamage(float DamageTaken)
	{
		Debug.Log("TakeDamageCall: " + DamageTaken);
		if(isVulnerable)
		{Health -= DamageTaken;}
	}
	public virtual void HealHealth(float HealAmount)
	{
		if(isHealable)
		{Health += HealAmount;}
	}
#endregion

#region of KnockBack method

	public void KnockBack(float KnockBackPower, Vector3 EnemyPosition)
	{
		if(isKnockBackAble == true)
		{
			float Distance = Vector3.Distance(EnemyPosition, transform.position);
			KnockBackPower = KnockBackPower / Distance;
			Vector3 pushDirection =  transform.position - EnemyPosition;
			pushDirection = pushDirection.normalized;

			gameObject.GetComponent<PlayerMovement>().delayTime = 0.1f;
			gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * KnockBackPower * 10000 * Time.deltaTime);
		}
	}
	#endregion
}

