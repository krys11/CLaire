using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public float val;
    Image imgProgress;
    Text txt;
    Color startColor;
    Color alertColor;

    // Start is called before the first frame update
    void Awake()
    {
        val = 100f;
        alertColor = Color.red;
        imgProgress = transform.Find("progressBar").GetComponent<Image>();
        txt = imgProgress.transform.Find("txt").GetComponent<Text>();
    }

    private void Start()
    {
        startColor = imgProgress.color;
        txt.text = val + "%";
    }

    // Update is called once per frame

    private void Update()
    {
        if (val >= 100)
        {
            val = 100;
        }

        if (val <= 0)
        {
            val = 0;
        }

        txt.text = (int)val + "%";
        imgProgress.fillAmount = val / 100;

        if (val <= 25)
        {
            imgProgress.color = alertColor;
        }
        else
        {
            imgProgress.color = startColor;
        }
    }
}
