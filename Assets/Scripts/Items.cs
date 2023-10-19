using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public ProgressBar progressBarChoise;

    public float ItemBonus;

    public MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            AudioSource audioSource =  GetComponent<AudioSource>();
            audioSource.Play();
            progressBarChoise.val += ItemBonus;
            GetComponent<BoxCollider>().enabled = false;
            meshRenderer.enabled = false;


            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
