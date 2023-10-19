using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemies : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    Animator animator;
    AudioSource audioSource;
    
    public ProgressBar ProgressBarVie;
    public float idleDistance = 10f, walkDistance = 7f, attackDistance = 1, damageAttack = 10f;
    public AudioClip sndClaireDamage, sndPop;

    GameObject Particle;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Particle = transform.Find("Explode").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if(agent.remainingDistance > idleDistance)
        {
            agent.speed = 0f;
            animator.SetBool("idle", false);
            animator.SetBool("walk", false);
            animator.SetBool("attack", false);

        }
        else
        {
            agent.speed = 0f;
            animator.SetBool("idle", true);
            animator.SetBool("walk", false);
            animator.SetBool("attack", false);

            if(agent.remainingDistance < walkDistance)
            {
                agent.speed = 1f;
                animator.SetBool("walk", true);
                animator.SetBool("attack", false);

                if(agent.remainingDistance < attackDistance)
                {
                    animator.SetBool("attack", true);
                }
            }
        }

        agent.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Particle.SetActive(true);
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            audioSource.PlayOneShot(sndPop);
            Destroy(gameObject, sndPop.length);
        }
    }

    public void attackDammage()
    {
        ProgressBarVie.val -= damageAttack;
        audioSource.PlayOneShot(sndClaireDamage);

        if(ProgressBarVie.val == 0)
        {
            GameObject.Find("claire").GetComponent<ControlerClaire>().ClaireDeath();

            GameObject[] kaya = GameObject.FindGameObjectsWithTag("kaya");

            foreach (GameObject k in kaya)
            {
                k.GetComponent<Ennemies>().enabled = false;
                agent.speed = 0f;
                animator.SetBool("idle", false);
                animator.SetBool("walk", false);
                animator.SetBool("attack", false);
            }
        }

    }
}
