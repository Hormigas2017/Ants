using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Grasshopper : MonoBehaviour, IEnemies
{
    public float life = 100;
    Slider lifeSlider;
    Transform mTransform;
    Vector3 initialPosition;
    Rigidbody mBody;
    float minDist = 2.0f;
    bool attackCooldown = true;
    float t = 0.0f;
    float cooldownTime = 3f;
    float damage = 10.0f;
    string enemyTag = "Player";
    GameObject enemy;
    Transform enemyTransform;

    public delegate void DieGH();
    public static event DieGH OnDieGrasshopper;

    NavMeshAgent navAgent;
    public LayerMask layerMask;

    [SerializeField]
    bool attack;

    [SerializeField]
    Vector3 targetPos;

    float wanderRadius = 30f;
    float wanderTimer = 5f;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    int deadGH = 0;

    void Start()
    {
        mTransform = GetComponent<Transform>();
        lifeSlider = GetComponentInChildren<Slider>();
        lifeSlider.value = 100f;
        initialPosition = mTransform.position;
        mBody = GetComponent<Rigidbody>();
        navAgent = GetComponent<NavMeshAgent>();

        if(DifficultController.difficult == 0)
        {
            navAgent.speed = 4;
        }
        if (DifficultController.difficult == 1)
        {
            navAgent.speed = 6;
        }
        if (DifficultController.difficult == 2)
        {
            navAgent.speed = 10;
        }

        targetPos = RandomNavSphere(transform.position, 20f, 8);
    }

    void Update()
    {
        lifeSlider.value = life;

        if (life <= 0)
        {
            deadGH++;

            if (deadGH == 3)
            {
                OnDieGrasshopper();
            }

            gameObject.SetActive(false);
            mTransform.position = initialPosition;
            mBody.velocity = new Vector3(0, 0, 0);
        }

        if (attackCooldown == false)
        {
            t += Time.deltaTime;
        }
        if (t >= cooldownTime)
        {
            attackCooldown = true;
        }
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if(!attack)
        {
            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                navAgent.SetDestination(newPos);
                timer = 0;
            }
        }

        if(attack)
        {
            Attack();
        }
    }

    public void Destroy(float _damage)
    {
        life -= _damage;
    }

    void MeleeAttack()
    {
        if (enemy.GetComponent<IAnts>() != null)
        {
            IAnts iAnts = enemy.GetComponent<IAnts>();
            iAnts.Damage(damage);
        }
    }

    void Attack()
    {
        enemy = FindClosestEnemy();
        enemyTransform = enemy.transform;

        navAgent.SetDestination(enemyTransform.position);

        if (enemy.activeInHierarchy)
        {
            if (Vector3.Distance(mTransform.position,enemyTransform.position) <= minDist)
            {
                if (attackCooldown == true)
                {
                    attackCooldown = false;
                    t = 0f;
                    MeleeAttack();
                }
            }
        }
        if (Vector3.Distance(enemyTransform.position, transform.position) > 100)
        {
            attack = false;
            navAgent.isStopped = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            attack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            attack = false;
        }
    }

    private GameObject FindClosestEnemy()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = mTransform.position;
        foreach (GameObject enemy in enemies)
        {
            Vector3 difference = enemy.transform.position - mTransform.position;
            float currentDistance = difference.sqrMagnitude;
            if (currentDistance < distance)
            {
                closest = enemy;
                distance = currentDistance;
            }
        }
        return closest;
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }
}
    

