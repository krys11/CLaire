using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public Sprite Sprite;
    public Image[] slot;
    public bool slotComplete = false;

    int x = 0;
    GameObject Particle;

    private void Awake()
    {
        Particle = GameObject.Find("Fireball_big_blue");
        Particle.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addSlotImage()
    {
        slot[x].GetComponent<Image>().sprite = Sprite;
        x++;
        x = Mathf.Clamp(x, 0, slot.Length);

        if(x == slot.Length)
        {
            slotComplete = true;
            Particle.SetActive(true);
        }
    }
}
