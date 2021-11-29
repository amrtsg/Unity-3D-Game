/*
EnemyController.cs
Author - Amr Ghoneim
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    public float health;
    public float maxHealth;
    public float epsilon = 2.0f;

    public PlayerManager playerScript;
    public GameObject healthBar;
    public GameObject player;
    public Slider slider;
    Transform target;
    NavMeshAgent agent;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerManager>();
        health = maxHealth;
        slider.value = CalculateHealth();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();
        if(health < maxHealth) {
            healthBar.SetActive(true);
        }
        if(health > maxHealth) {
            health = maxHealth;
        }
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius) {
            //anim.SetBool("isClose", false);
            anim.SetBool("isWalking", true);
            agent.SetDestination(target.position);
            if (distance >= agent.stoppingDistance)
            {
                faceTarget();
            }
            else if(distance <= agent.stoppingDistance + 1)
            {
               //anim.SetBool("isWalking", false);
                anim.SetBool("isClose", true);
                if(Input.GetKeyDown(KeyCode.Q)) {
                    health -= 40f;
                }
            }
        } else
        {
            anim.SetBool("isClose", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isDead", false);
        }

        if(health <= 0) {
            anim.SetBool("isClose", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isDead", true);
            StartCoroutine(enemyDeath());
        }
    }

    float CalculateHealth() {
        return health/maxHealth;
    }
    void faceTarget() {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.name == "Bullet_Prefab(Clone)") {
            health -= 20;
        }
        if(col.gameObject.name == "Player") {
            if(health > 0) {
                playerScript.health -= 10f;
            }
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    IEnumerator enemyDeath() {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
