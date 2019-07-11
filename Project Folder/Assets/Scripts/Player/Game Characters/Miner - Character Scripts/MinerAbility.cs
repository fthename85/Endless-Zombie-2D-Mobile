using UnityEngine;
using AbilityInterface;
using UnitInterface;

public class MinerAbility : CharacterSkills, AbilitySystem.IAbilityHandler
{
    public Transform ChargedAttackPosition;
    public Transform SpinAttackPosition;
    float KnockBackPower;
    void Start()
    {
        #region GetComponent From this Object
            animator = gameObject.GetComponent<Animator>();
            Damage = gameObject.GetComponent<CharacterStats>().UnitDamage;
            AttackRange = gameObject.GetComponent<CharacterStats>().AttackRange;
            KnockBackPower = gameObject.GetComponent<MinerStats>().KnockBackPower;
            _animationClips = animator.runtimeAnimatorController.animationClips;
        #endregion
        MainCameraAnimator  = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        GetClipLength();
    }
    public override void DefaultAttack()
        {
            if(!isChanneling)
            {
                float DefaultKnockBack = KnockBackPower * 0.1f;
                animator.SetTrigger("_DefaultAttack");
                MainCameraAnimator.SetTrigger("_Shake");
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(DefaultAttackPosition.position,
                new Vector2(AttackRange,AttackRange + (AttackRange/2)), 0, EnemyMask);
                
            
                foreach (var enemyCollider in enemiesToDamage) 
                {
                    foreach (var vulnerable in enemyCollider.GetComponents<UnitType.IVulnerable>()) 
                    {
                        vulnerable.TakeDamage(Damage);
                    }
                    foreach(var knockbackable in enemyCollider.GetComponents<UnitType.IKnockBackAble>())
                    {
                        knockbackable.KnockBack(DefaultKnockBack, transform.position);
                    }
                }
            }
        }
    #region of Ability_1
    public override void Ability_1()
        {   //ChargedAttack
            if(!isChanneling)
            {
                isChanneling = true;
                animator.SetTrigger("_Ability_1");
                Invoke("ChargedAttack", ChargingTime);

            }
        }
    void ChargedAttack()
    {
        float ChargedAttackDamage = 3 * Damage;
        MainCameraAnimator.SetTrigger("_Shake2");
        isChanneling = false;
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(DefaultAttackPosition.position, 
        AttackRange*1.5f, EnemyMask);
        foreach (var enemyCollider in enemiesToDamage) 
            {
                    
                foreach (var vulnerable in enemyCollider.GetComponents<UnitType.IVulnerable>()) 
                {
                    vulnerable.TakeDamage(ChargedAttackDamage);
                }
                foreach(var knockbackable in enemyCollider.GetComponents<UnitType.IKnockBackAble>())
                {
                    knockbackable.KnockBack(KnockBackPower,transform.position);
                }
            }
    }
    #endregion
    
    #region of Ability_2
    bool isSpinning = false;
    float time;
    public override void Ability_2()
        {
            if(!isSpinning)
            {
                time = 0.183f;
                isSpinning = true;
            }
            float SpinDamage = 1.2f * Damage;
            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(SpinAttackPosition.position,
            new Vector2(AttackRange,AttackRange + (AttackRange/2)), 0, EnemyMask);
            foreach (var enemyCollider in enemiesToDamage) 
            {
                   
                foreach (var vulnerable in enemyCollider.GetComponents<UnitType.IVulnerable>()) 
                {
                    Debug.Log("EnemyHits");
                    // vulnerable.TakeDamage(SpinDamage);
                }
            //     foreach(var knockbackable in enemyCollider.GetComponents<UnitType.IKnockBackAble>())
            //     {
            //         knockbackable.KnockBack(KnockBackPower * 0.2f, transform.position);
            //     }
            }
            if(isSpinning && time <= 0)
            {
                isSpinning = false;
            }
        }
    void SpinCharacter()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        Ability_2();
    }
    #endregion Ability_2
    public override void Ability_3()
        {
            Debug.Log("Ability_3 has been activated");
        }

    

//------------------------------------------------//
    //get Length of a Clip;
    float ChargingTime;
    void GetClipLength()
    {
        
        foreach(AnimationClip Clip in _animationClips){
        switch(Clip.name)
            {
                case "ChargedAttack":
                ChargingTime = Clip.length;
                break;
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ChargedAttackPosition.position, AttackRange * 1.5f);
    }
}