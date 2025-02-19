using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    private Animator animator;

    private NavMeshAgent navAgent;

    public bool isDead;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }


    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            int randomValue = Random.Range(0, 2); 

            if (randomValue == 0)
            {
                animator.SetTrigger("Die 1");

            }
            else
            {
                animator.SetTrigger("Die 2");

            }

            isDead = true;

            SoundManager.Instance.zombieChannelSecond.PlayOneShot(SoundManager.Instance.zombieDeath);

        }
        else
        {
            animator.SetTrigger("Damage");

            SoundManager.Instance.zombieChannelSecond.PlayOneShot(SoundManager.Instance.zombieHurt);


        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2.5f);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 100f);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 101f);

    }


}
