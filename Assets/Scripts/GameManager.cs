using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ProgressBar PbVie, PbEnergy, PbFaim;

    bool death = false;

    //Faim
    public float decreaseValueFaim, countDownFaim;

    //Energy
    public float walkValue, runValue;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DecreaseVal());
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical") != 0 && !death)
        {
            PbEnergy.val -= walkValue;

            if( PbEnergy.val < 0 ) 
            {
                death = true;
                GameObject.Find("claire").GetComponent<ControlerClaire>().ClaireDeath();
            }
        }

        if (Input.GetAxis("Vertical") != 0 && Input.GetKey(KeyCode.LeftControl) && !death)
        {
            PbEnergy.val -= runValue;

            if (PbEnergy.val < 0)
            {
                death= true;
                GameObject.Find("claire").GetComponent<ControlerClaire>().ClaireDeath();
            }
        }
    }



    IEnumerator DecreaseVal()
    {
        while (PbFaim.val > 0)
        {
            PbFaim.val -= decreaseValueFaim;
            yield return new WaitForSeconds(countDownFaim);
        }

        GameObject.Find("claire").GetComponent<ControlerClaire>().ClaireDeath();
    }
}
