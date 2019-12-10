
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public bool DeadMonster = false;
    private EnemyManager em;

    public float health = 100f;

    float dTimer = 0;
    float dTimeInterval = 2;
    public bool isDead;

    void Start()
    {
        em = GameObject.FindGameObjectWithTag("GM").GetComponent<EnemyManager>();
    }

    private void Update()
    {
        if (health <= 0f)
        {
            Die();
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("ENEMY SHOT" + health);
        //if(health <= 0f)
        //{
        //    Die();
        //}
    }

    void Die()
    {
        FindObjectOfType<AudioManager>().Play("BoneDying");
        isDead = true;

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
                print(health);
            }
            
            if(collision.gameObject.GetComponent<Minion>() != null)
                collision.gameObject.GetComponent<Minion>().IsShot = true;
        }
    }
}
