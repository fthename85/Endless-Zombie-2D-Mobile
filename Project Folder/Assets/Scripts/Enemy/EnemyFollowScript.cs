using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowScript : MonoBehaviour
{
    [HideInInspector]
    public bool isFlippedSprite = false;
    float ThisUnitSpeed, stopDistance;
    Transform Target;
    Rigidbody2D _Rigidbody;
    public float delayTime;

    void Start()
    {
        _Rigidbody = gameObject.GetComponent<Rigidbody2D>();
        ThisUnitSpeed = gameObject.GetComponent<EnemyStats>().MovementSpeed;

        Target = GameObject.FindGameObjectWithTag("Player").transform;
        stopDistance = gameObject.GetComponent<EnemyStats>().StopDistance;
    }
    // Update is called once per frame
    void Update()
    {
        if ( delayTime >= 0)
        {
            delayTime -= Time.deltaTime;
        }else{
            followPlayer();
        }
        
        if (delayTime <= 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        }
    }
    void followPlayer()
    {

            if (Target.position.x - transform.position.x > 0 && !isFlippedSprite)
            {
                _Rigidbody.freezeRotation = false;
                isFlippedSprite = true;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (Target.position.x - transform.position.x < 0 && isFlippedSprite)
            {
                _Rigidbody.freezeRotation = false;
                isFlippedSprite = false;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (Vector2.Distance(transform.position, Target.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Target.position, ThisUnitSpeed * Time.deltaTime);
            }
            if (!_Rigidbody.freezeRotation)
            {
                _Rigidbody.freezeRotation = true;
            }
    }
}
