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
    GameObject player;
    Transform playerTransform;
    float minDist = 2.0f;
    bool attackCooldown = true;
    float t = 0.0f;
    float cooldownTime = 3f;
    float damage = 10.0f;
    float time = 0;

    public delegate void DieGH();
    public static event DieGH OnDieGrasshopper;

    NavMeshAgent navAgent;
    public LayerMask layerMask;

    bool attack;
    float speed;
    bool rotTime;
    float y;

    int deadGH = 0;

    void Start()
    {
        mTransform = GetComponent<Transform>();
        lifeSlider = GetComponentInChildren<Slider>();
        lifeSlider.value = 100f;
        initialPosition = mTransform.position;
        mBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerTransform = player.transform;
        navAgent = GetComponentInParent<NavMeshAgent>();
        speed = 10f;
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
        time++;

        if(!attack)
        {
            navAgent.enabled = false;
            Idle();
        }
        if(attack)
        {
            navAgent.enabled = true;
            Attack();
        }
    }

    public void Destroy(float _damage)
    {
        life -= _damage;
    }

    void MeleeAttack()
    {
        if (player.GetComponent<IAnts>() != null)
        {
            IAnts iAnts = player.GetComponent<IAnts>();
            iAnts.Damage(damage);
        }
    }

    void Idle()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        transform.Rotate(new Vector3(0, y, 0));
        if(time >= Random.Range(100, 2500))
        {
            Rotate();
            time = 0;
            rotTime = true;
        }

        if(rotTime)
        {
            if(time >= Random.Range(10, 30))
            {
                y = 0;
                rotTime = false;
            }
        }
    }

    void Rotate()
    {
        y = Random.Range(-5, 5);
    }

    void Attack()
    {
        navAgent.SetDestination(playerTransform.position);

        if (player.activeInHierarchy)
        {
            if (Vector3.Distance(mTransform.position, playerTransform.position) <= minDist)
            {
                if (attackCooldown == true)
                {
                    attackCooldown = false;
                    t = 0f;
                    MeleeAttack();
                }
            }
        }
        if (Vector3.Distance(playerTransform.position, transform.position) > 100)
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
            navAgent.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            attack = false;
            navAgent.enabled = false;
        }
    }
}
    

