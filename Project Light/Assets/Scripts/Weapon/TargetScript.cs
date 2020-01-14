using Panda;
using UnityEngine;
using UnityEngine.AI;

public class TargetScript : MonoBehaviour
{
    public bool DeadMonster = false;
    private EnemyManager em;
    private PandaBehaviour panda;
    private NavMeshAgent agent;
    private Animator m_Animator;
    private Vector3 deathPosition;
    private Minion minion;
    private AudioSource[] sources;

    public float health = 100f;

    bool play = true;

    float dTimer = 0;
    float dTimeInterval = 2;
    public bool isDead;

    void Start()
    {
        em = GameObject.FindGameObjectWithTag("GM").GetComponent<EnemyManager>();
        panda = GetComponent<PandaBehaviour>();
        agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
        if(GetComponent<Minion>() != null)
            minion = GetComponent<Minion>();
        sources = GetComponents<AudioSource>();
    }

    private void Update()
    {
        if (health <= 0f)
        {
            InevitableDeath();
            Die();
        }
    }

    public void InevitableDeath()
    {
        if (play)
        {
            FindObjectOfType<AudioManager>().Play("BoneDying");
            play = false;
        }

        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(minion != null){minion.IsShot = true; }
        Debug.Log("ENEMY SHOT" + health);
        FindObjectOfType<AudioManager>().Play("MonsterHit");
        //if(health <= 0f)
        //{
        //    Die();
        //}
    }

    void Die()
    {
        
        for (int i = 0; i < sources.Length; i++)
            sources[i].Stop();
        
        panda.enabled = false;
        agent.enabled = false;
        if (!isDead)
        {
            deathPosition = transform.position;
            deathPosition.y -= 0.5f;
        }
        isDead = true;
        m_Animator.SetTrigger("Death");
        
        transform.position = deathPosition;


        dTimer += Time.deltaTime;
        if (dTimer >= dTimeInterval)
        {
            em.RemoveCurrentAmount();
            Destroy(gameObject);
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bolt")
        {
            if (collision.gameObject.GetComponent<BoltScript>() != null)
            {
                health -= collision.gameObject.GetComponent<BoltScript>().damage;
                FindObjectOfType<AudioManager>().Play("MonsterHit");
                print(health);
            }
            
            if(collision.gameObject.GetComponent<Minion>() != null)
                collision.gameObject.GetComponent<Minion>().IsShot = true;
        }
    }
}
