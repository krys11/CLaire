using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerClaire : MonoBehaviour
{
    float speedFlash, rotateValue = 100f;
    float axisV, axisH;
    bool switchFoot = false, isJumping = false;
    public float speed, forceValue;
    public bool useMoose = false;
    Animator claireAnimator;
    Rigidbody rb;
    AudioSource claireAudioSource;
    CapsuleCollider claireCapsuleCollider;
    public AudioClip sndJump, sndImpact, sndFootLeft, sndFootRight, sndDeath;

    const float timeOut = 30f;

    public float countDown;

    private void Awake()
    {
        countDown = timeOut;
        claireAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        claireAudioSource = GetComponent<AudioSource>();
        claireCapsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        axisV = Input.GetAxis("Vertical");
        axisH = Input.GetAxis("Horizontal");

        if (axisV > 0)
        {

            if (Input.GetKey(KeyCode.LeftControl))
            {
                speedFlash = speed * 2;
                claireAnimator.SetFloat("run", axisV);
                transform.Translate(Vector3.forward * speedFlash * Time.deltaTime * axisV);
            }
            else
            {
                claireAnimator.SetFloat("run", 0f);
                speedFlash = speed;
                claireAnimator.SetBool("walk", true);
                transform.Translate(Vector3.forward * speedFlash * Time.deltaTime * axisV);
            }
        }
        else
        {
            claireAnimator.SetBool("walk", false);
        }

        //bouger claire avec une rotation surplace
        if(axisH != 0)
        {
            claireAnimator.SetFloat("horizontal", axisH);
        }
        else
        {
            claireAnimator.SetFloat("horizontal", 0f);
        }

        //rotation camera avec la souris ou le clavier
        if (useMoose)
        {
            transform.Rotate(Vector3.up * rotateValue * Time.fixedDeltaTime * Input.GetAxis("Mouse X"));
        }
        else
        {
            transform.Rotate(Vector3.up * rotateValue * Time.deltaTime * axisH);
        }

        if (axisV < 0)
        {
            claireAnimator.SetBool("walkBack", true);
            claireAnimator.SetBool("walk", false);
            claireAnimator.SetFloat("run", 0f);
            transform.Translate(Vector3.forward * speed * Time.deltaTime * axisV);
        }
        else
        {
            claireAnimator.SetBool("walkBack", false);
        }

        if(axisH == 0 & axisV == 0)
        {
            countDown -= Time.deltaTime;
            if(countDown < 0)
            {
                GameObject.Find("AudioDanceTwerk").GetComponent<AudioSource>().enabled = true;
                claireAnimator.SetBool("dance", true);
            }
        }
        else
        {
            GameObject.Find("AudioDanceTwerk").GetComponent<AudioSource>().enabled = false;
            countDown = timeOut;
            claireAnimator.SetBool("dance", false);
        }

        if (Input.GetKeyDown(KeyCode.AltGr))
        {
            claireAudioSource.pitch = 1f;
            claireAudioSource.PlayOneShot(sndDeath);
            ClaireDeath();
        }

        if (isJumping)
        {
            claireCapsuleCollider.height = claireAnimator.GetFloat("colheight");
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector3.up * forceValue);
            claireAnimator.SetTrigger("jump");
            claireAudioSource.pitch = 1f;
            claireAudioSource.PlayOneShot(sndJump);
        }
    }

    public void ClaireDeath()
    {
        claireAudioSource.pitch = 1f;
        claireAnimator.SetTrigger("death");
        claireAudioSource.PlayOneShot(sndDeath);
        GameObject.Find("claire").GetComponent<ControlerClaire>().enabled = false;
    }

    public void PlaySoundImpact()
    {
        claireAudioSource.pitch = 1f;
        claireAudioSource.PlayOneShot(sndImpact);
    }

    public void PLayFootSound()
    {
        if (!claireAudioSource.isPlaying)
        {
            switchFoot = !switchFoot;
            if (switchFoot)
            {
                claireAudioSource.pitch = 2f;
                claireAudioSource.PlayOneShot(sndFootLeft);
            }
            else
            {
                claireAudioSource.pitch = 2f;
                claireAudioSource.PlayOneShot(sndFootRight);
            }
        }
    }

    public void IsJumpingFalse()
    {
        isJumping = false;
    }
}
