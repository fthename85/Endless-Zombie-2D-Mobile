using System.Collections;
using UnityEngine;


namespace AbilityInterface
{
	public struct AbilitySystem 
	{
		public interface IAbilityHandler
		{
			void  DefaultAttack();
			void Ability_1();
			void Ability_2();
			void Ability_3();
		}
	}
}

namespace UnitInterface
{
	public struct UnitType
	{
		public interface IUnit{
			string UnitName{get;}
			float Health{get;}

		}
		public interface IVulnerable{

			bool isVulnerable{get;}
			void TakeDamage(float Damage);
			
		}
		public interface IHealable{
			bool isHealable{get;}
			void HealHealth(float Amount);
			
		}
		public interface IAttacker{
			float UnitDamage{get;}
			float AttackRange{get;}
		}
		public interface IMovingUnit
		{
			float MovementSpeed{get;}
		}
		public interface IKnockBackAble
		{
			bool isKnockBackAble{get;}
			void KnockBack(float KnockbackPower, Vector3 EnemyPosition);
		}
	}
	public struct EnemyInterface{
		public interface IFollowHandler{
			float StopDistance{get;}
		}
		public interface IEnemyAttackSpeedHandler
		{
			float AttackSpeed{get;}
			float InitialAttackSpeed{get;}
		}
		public interface IEnemyPointsHandler
		{
			int EnemyWorthPoints {get;}
			void AddScore();
		}
	}
}
