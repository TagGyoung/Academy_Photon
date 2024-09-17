using Photon.Pun;
using UnityEngine;

public enum State
{ 
    RUN,
    ATTACK,
    DIE
}

public class Unit : MonoBehaviour
{
    [SerializeField] State state;
    [SerializeField] float health;
    [SerializeField] GameObject tower;
    [SerializeField] float speed = 5.0f;
    [SerializeField] Animator animator;

    private void Start()
    {
        health = 100;

        state = State.RUN;

        tower = GameObject.Find("Tower");

        transform.LookAt(tower.transform.position);
        
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        switch (state)
        {
            case State.RUN:
                {
                    Run();
                }
                break;
            case State.ATTACK:
                {
                    Attack();
                }
                break;
            case State.DIE:
                {
                    Die();
                }
                break;
        }
    }

    public void Run()
    {
        transform.position = Vector3.MoveTowards(transform.position, tower.transform.position, speed * Time.deltaTime);
    }

    public void Attack()
    {   
        animator.SetTrigger("Attack");
    }


    public void Die()
    {
        PhotonNetwork.Destroy(gameObject);
    }

    public void Damage(float damage)
    {
        health -= damage;

        if (health <= 0) state = State.DIE;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tower"))
        {
            state = State.ATTACK;
        }
    }
}
