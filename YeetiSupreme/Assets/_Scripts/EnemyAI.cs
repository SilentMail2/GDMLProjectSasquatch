using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform[] navPoints;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float healthPoints;
    [SerializeField] float lookRadius = 10f;
    [SerializeField] Transform target;
    [SerializeField] bool seesPlayer;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform barrelPoint;
    [SerializeField] float bulletTime;
    [SerializeField] float timeBullet;
    [SerializeField] float timeTaken;
    [SerializeField] int navLength;
    // Start is called before the first frame update
    void Start()
    {
        target = ObjectPool.instance.Player.transform;
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(target.position, transform.position);
        if (!target.GetComponent<Player_Control>().inDialogue)
        {
            if (distance <= lookRadius)
            {
                seesPlayer = true;
                if (distance <= agent.stoppingDistance)
                {
                    //Attack the target
                    AttackTarget();
                    //Face the target
                    FaceTarget();
                }
            }
        }
        if (seesPlayer)
        {
            agent.SetDestination(target.position);
            agent.stoppingDistance = 30;
        }
        if (!seesPlayer)
        {
            if (navPoints.Length != 0)
            {
                if (agent.velocity.magnitude == 0f)
                {
                    agent.SetDestination(navPoints[navLength].position);
                    if (this.transform.position == navPoints[navLength].position)
                    {
                        navLength++;
                    }

                    if (navLength >= navPoints.Length)
                    {
                        navLength = 0;
                    }
                }
            }
            if (navPoints.Length==0)
            {
                return;
            }
        }
    }
    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    void AttackTarget()
    {
        bulletTime -= timeTaken * Time.deltaTime;
        if (bulletTime <= 0) {
            Instantiate(bullet, barrelPoint.position, barrelPoint.rotation);
            bulletTime = timeBullet;
                }
    }
    public void FindPlayer()
    {
        seesPlayer = true;
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            TakeDamage(10);
        }
    }
    void TakeDamage(float dam)
    {
        healthPoints -= dam;
        if (healthPoints<=0)
        {
            Destroy(this.gameObject);
        }
    }*/
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
