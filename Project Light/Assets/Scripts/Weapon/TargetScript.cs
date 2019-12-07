
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public bool DeadMonster = false;
    private EnemyManager em;

    public float health = 100f;

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
        em.RemoveCurrentAmount();
        Destroy(gameObject);
        FindObjectOfType<AudioManager>().Play("BoneDying");
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
