using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public AudioClip sndPauseOn, sndPauseOff;
    public bool onPause = false;
    Image Image;
    // Start is called before the first frame update
    void Awake()
    {
        Image = transform.Find("ImgPause").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            onPause = !onPause;

            if(onPause)
            {
                GetComponent<AudioSource>().PlayOneShot(sndPauseOn);
                Image.enabled = true;
                Time.timeScale = 0f;
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(sndPauseOff);
                Image.enabled = false;
                Time.timeScale = 1f;
            }
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
           SceneManager.LoadScene("EndScene");
        }
    }
}
