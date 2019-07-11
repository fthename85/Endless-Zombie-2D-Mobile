using UnityEngine;
using UnitInterface;
//
public class EnemyStats :  MonoBehaviour, UnitType.IUnit, UnitType.IMovingUnit, 
UnitType.IAttacker, UnitType.IVulnerable, UnitType.IKnockBackAble, EnemyInterface.IFollowHandler,
EnemyInterface.IEnemyAttackSpeedHandler, EnemyInterface.IEnemyPointsHandler
{
	//CharacterStats Variables
	#region of Unit Interface Variables
		#region of name Variables
		public string EnemyName;
		public string UnitName{
			get
			{
				return EnemyName;
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
	#region of Knockbackable Interface variables
	public bool _isKnockBackAble;
	public bool isKnockBackAble{get{ return _isKnockBackAble;}}
	#endregion
	#region of FollowHandler Interface Variables
    public float _StopDistance;
    public float StopDistance{get{return _StopDistance;}}
    #endregion
	#region of AttackSpeed Interface variable
	public float _attackSpeed, _initialAttackSpeed;
	public float AttackSpeed{get {return _attackSpeed;}}
	public float InitialAttackSpeed{get{return _initialAttackSpeed;}}
	#endregion
	#region of EnemyPoints Interface variable
	public int _EnemyWorthPoints;
	public int EnemyWorthPoints {get {return _EnemyWorthPoints;}}
	#endregion
	//Charater Methods
	void Start(){
		_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		MaxHealth = _health;

	}
#region of Health Methods
	float MaxHealth;
	GameManager _gameManager;
	public virtual void TakeDamage(float DamageTaken)
	{
		
		
		if(isVulnerable)
		{Health -= DamageTaken; _gameManager.DisplayDamageTaken(DamageTaken, MaxHealth, transform);}
        if(Health < 1)
        {
			AddScore();
           	Destroy(gameObject);
        }
	}
	
#endregion

#region of KnockBack method
	// float _KnockBackPowerY, _KnockBackPowerX,SideOfCharacter;
	// Vector3 KnockBackPosition, EnemyTransformRight,EnemyTransformUp;
	public void KnockBack(float KnockBackPower, Vector3 PlayerPosition)
	{
		
		if(isKnockBackAble == true)
		{
			float Distance = Vector3.Distance(PlayerPosition, transform.position);
			KnockBackPower = KnockBackPower / Distance;
			Vector3 pushDirection =  transform.position - PlayerPosition;
			pushDirection = pushDirection.normalized;

			gameObject.GetComponent<EnemyFollowScript>().delayTime = 0.1f;
			gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * KnockBackPower * 10000 * Time.deltaTime);
		}
	}
	#endregion
#region  of EnemyPoints Method

	GameManager Score;
	public void AddScore(){
		Score = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		Score.CurrentScore += EnemyWorthPoints;
	}
#endregion
}