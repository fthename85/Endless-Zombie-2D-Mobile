using UnityEngine;
using UnitInterface;
public class EnemyDefaultAttack: MonoBehaviour{

    public Transform EnemyAttackPosition;
    Animator animator;
    Transform Target;
    EnemyStats _enemyStats;
    public LayerMask PlayerMask;
    bool isAttacking = false;
    public float AttackRange, Damage, AttackSpeed, InitialAttackSpeed;
    
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        _enemyStats = gameObject.GetComponent<EnemyStats>();
        Target = GameObject.FindGameObjectWithTag("Player").transform;


        Damage = _enemyStats.UnitDamage;
        AttackRange = _enemyStats.AttackRange;
        AttackSpeed = _enemyStats.AttackSpeed;
        InitialAttackSpeed = _enemyStats.InitialAttackSpeed;
    }
    void Update()
    {
        DoAttack();
    }



    void DoAttack()
    {
        if(Vector2.Distance(transform.position,Target.position) <= 1.5 && !isAttacking)
        {
            isAttacking = true;
            InvokeRepeating("DefaultAttack",InitialAttackSpeed,AttackSpeed);
        }
        if (gameObject == null || Vector2.Distance(transform.position,Target.position) > 1.5)
        {
            isAttacking = false;
            CancelInvoke("DefaultAttack");
        }
    }
    void DefaultAttack()
    {
        animator.SetTrigger("_DefaultAttack");
        Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(EnemyAttackPosition.position, AttackRange, PlayerMask);
        
        if(playerToDamage != null)
        {
            for (int i = 0; i < playerToDamage.Length; i++)
            {
                var Target = playerToDamage[i].GetComponents<UnitType.IVulnerable>();
                foreach(var target in Target)
                {
                    target.TakeDamage(Damage);
                }
            }
        }
    }
}