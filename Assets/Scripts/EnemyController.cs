using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyState
{
    wander,

    follow,

    attack,

    die
};

public class EnemyController : MonoBehaviour
{
    GameObject player;

    public enemyState curState = enemyState.wander;

    public float range;

    public float speed;

    public float attackRange;

    public float cooldown;

    private bool chooseDirection = false;

    private bool dead = false;

    private bool cooldownAttack = false;

    private Vector3 randomDirection;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (curState)
        {
            case (enemyState.wander):
                Wander();
                break;
            case (enemyState.follow):
                Follow();
                break;
            case (enemyState.attack):
                Attack();
                break;
            case (enemyState.die):
                break;

        }

        if(IsPlayerInRange(range) && curState != enemyState.die)
        {
            curState = enemyState.follow;
        }
        else if(!IsPlayerInRange(range) && curState != enemyState.die)
        {
            curState = enemyState.wander;
        }

        if(Vector3.Distance(transform.position, player.transform.position) <= attackRange)
        {
            curState = enemyState.attack;
        }
    }

    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    private IEnumerator ChooseDirection()
    {
        chooseDirection = true;
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        randomDirection = new Vector3(0, 0, Random.Range(0, 360));
        Quaternion nextRotation = Quaternion.Euler(randomDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        chooseDirection = false;
    }

    private void Wander()
    {

        if (!chooseDirection)
        {
            StartCoroutine(ChooseDirection());
        }

        transform.position += -transform.right * speed * Time.deltaTime;
        if (IsPlayerInRange(range))
        {
            curState = enemyState.follow;
        }
    }

    private void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void Attack()
    {
        if (!cooldownAttack)
        {
            GameController.DamagePlayer(1);
            StartCoroutine(Cooldown());
        }

    }

    private IEnumerator Cooldown()
    {
        cooldownAttack = true;
        yield return new WaitForSeconds(cooldown);
        cooldownAttack = false;
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
