using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPoint : MonoBehaviour
{
    [TextArea]
    public string text;

    public Text textInfo;
    public GameObject panelInfo;

    private void Awake()
    {
        panelInfo.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelInfo.SetActive(true);
            textInfo.text = text;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelInfo.SetActive(false);
            textInfo.text = "";
        }
    }
}
