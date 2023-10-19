using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Child : MonoBehaviour
{
    public AudioClip sndPop;
    public Transform target;
    public bool inCage = true;

    NavMeshAgent agent;
    Animator animator;
    GameObject Particle;
    AudioSource audioSource;
    GameObject Cage;
    BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        agent = transform.Find("ty").GetComponent<NavMeshAgent>();
        animator = transform.Find("ty").GetComponent<Animator>();
        Particle = transform.Find("Explode").gameObject;
        audioSource = GetComponent<AudioSource>();
        Cage = transform.Find("Cage").gameObject;
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            inCage = false;
            boxCollider.enabled = false;
            audioSource.PlayOneShot(sndPop);
            Particle.SetActive(true);
            Cage.SetActive(false);
            Destroy(Cage, sndPop.length);
            GameObject.Find("CanvasUISlot").GetComponent<UISlot>().addSlotImage();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inCage)
        {
            agent.speed = 0f;
            animator.SetBool("run", false);
        }
        else
        {
            animator.SetBool("run", true);
            agent.speed = 3.5f;
            agent.SetDestination(target.position);

            if(agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.speed = 0f;
                animator.SetBool("run", false);
                agent.transform.rotation = target.rotation;
            }
        }
    }
}
