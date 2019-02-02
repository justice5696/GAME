using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    // Reference to the player's health.
    private GameObject player;
    CharacterStatus playerStatus;
    private List<GameObject> chesty;
    private List<GameObject> enemys;
    float enemyHealth;        // Reference to this enemy's health.
    public UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
    private List<Transform> transArray;
    private List<Transform> enemyTrans;
    private CharacterStatusEnemy characterStatus;
    private Transform best;
    public EnemyState enemyState;
    public float damage = -3f;
    public float minDistance = 1f;

    //Attack
    public int AttackDamageMin;
    public int AttackDamageMax;
    public float nextHit = 0;
    public float CoolDownTime = .5f;
    public bool didAttackHit;
    public bool didAttack;

    void Start()
    {
        // Set up the references.
        player = GameObject.FindWithTag("Player");
        playerStatus = player.GetComponent<CharacterStatus>();
        //enemyStatus = GetComponent<CharacterStatus>();
        characterStatus = GetComponent<CharacterStatusEnemy>();
        GameObject[] chests = GameObject.FindGameObjectsWithTag("Chest");
        chesty = new List<GameObject>(chests);
        transArray = createTrans(chesty);
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemys = new List<GameObject>(Enemies);
        enemys.Remove(gameObject);
        enemys.Add(GameObject.FindWithTag("Player"));
        enemyTrans = createTrans(enemys);
        /*Debug.Log("getState.getType.Name = " + enemyState.getState().GetType().Name);
        if(enemyState.getState().GetType().Name == "LootState")
        {
        best = GetClosestEnemy(transArray);
        nav.SetDestination(best.position);
        Debug.Log("Enemy Movement: Enemy is initialized to loot state");
        }
        else
        {
        Debug.Log("Enemy Movement: Enemy isn't initialized to any state");
        } */

    }


    void Update()
    {

        int interval = 10;
        float distance = Vector3.Distance(GameObject.FindWithTag("Player").transform.position, this.transform.position);
        if (Time.frameCount % interval == 0)
        {
            if (enemyState.getState().GetType().Name == "AttackState")
            {
                Debug.Log("Enemy Movement: " + gameObject.name + " is in attack state, and we are setting destination to closest enemy.");
                //best = GetClosestEnemy(enemyTrans);
                best = player.transform;
                nav.SetDestination(best.position);
                //Debug.Log("Enemy Movement: Enemy dest is: " + best.position.ToString());



                if (Time.time > nextHit)
                {
                    didAttack = true;

                    if (didAttack)
                    {
                        if (distance < minDistance)
                        {
                            StartCoroutine(AttackTarget());
                        }
                        didAttack = false;
                    }

                    nextHit = Time.time + CoolDownTime;
                }

            }
            else if (enemyState.getState().GetType().Name == "LootState")
            {
                Debug.Log("Enemy Movement: " + gameObject.name + " is in loot state, and we are setting dest to best chest");
                best = GetClosestEnemy(transArray);
                //best = player.transform;
                nav.SetDestination(best.position);
                //Debug.Log("Enemy Movement: Enemy dest is: " + best.position.ToString());
            }
            else
            {
                Debug.Log("Enemy Movement: " + gameObject.name + " isn't in any state.");
                best = player.transform;
                nav.SetDestination(best.position);
                nav.enabled = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (enemyState.getState().GetType().Name == "LootState")
        {
            if (collision.gameObject.tag == "Chest")
            {
                Debug.Log("Enemy Movement: " + gameObject.name + " Entered Chest Collider: " + collision.gameObject.name);
                chesty.Remove(collision.gameObject);
                transArray.Remove(collision.gameObject.transform);
                best = GetClosestEnemy(transArray);
                nav.SetDestination(best.position);
                //Debug.Log("Enemy Movement: Enemy dest is: " + best.position.ToString());
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Chest")
        {
            Debug.Log("Enemy Movement: " + gameObject.name + " Stayed Chest Collider: " + collision.gameObject.name);
            chesty.Remove(collision.gameObject);
            transArray.Remove(collision.gameObject.transform);
            best = GetClosestEnemy(transArray);
            nav.SetDestination(best.position);
            //Debug.Log("Enemy Movement: Enemy dest is: " + best.position.ToString());
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Chest")
        {
            Debug.Log("Enemy Movement: " + gameObject.name + " exited Chest Collider: " + collision.gameObject.name);
            chesty.Remove(collision.gameObject);
            transArray.Remove(collision.gameObject.transform);
            best = GetClosestEnemy(transArray);
            nav.SetDestination(best.position);
            //Debug.Log("Enemy Movement: Enemy dest is: " + best.position.ToString());
            Destroy(collision.gameObject);
        }
    }


    IEnumerator AttackTarget()

    {


        //need to get the damage stat from the characterstatusenemy class
        //Also need to make sure to implement a cooldown becuase waiting in a coroutine doesnt work, do it with delta time
        //need to print out damage that the player recieves and does on screen 
        GameObject.FindWithTag("Player").transform.GetComponent<CharacterStatus>().setCharHealth(damage);


        yield return new WaitForSeconds(0.1f);

    }



    public void RecieveDamage(float dmg)

    {

        enemyHealth -= dmg;

        print("damage done: " + dmg);

        print("enemy hp: " + enemyHealth);

    }


    List<Transform> createTrans(List<GameObject> listy)
    {
        List<Transform> trans = new List<Transform>();
        for (int i = 0; i < listy.Count; i++)
        {
            trans.Add(listy[i].transform);
        }
        return trans;
    }

    Transform GetClosestEnemy(List<Transform> enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in enemies)
        {
            if (potentialTarget.position == null) { continue; }
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }
}