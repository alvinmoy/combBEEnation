using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class costScript : MonoBehaviour
{
    public GameObject thisPacket;
    public Logic logic;

    public SpriteRenderer thisSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();

        if(gameObject.name == "packet1text"){
            thisPacket = GameObject.Find("packet1");
        }

        if(gameObject.name == "packet2text"){
            thisPacket = GameObject.Find("packet2");
        }

        if(gameObject.name == "packet3text"){
            thisPacket = GameObject.Find("packet3");
        }

        if (thisPacket != null) {
            thisSprite = thisPacket.GetComponent<SpriteRenderer>();
        } else {
            Debug.LogError("thisPacket is null.");
        }

        TextMeshProUGUI thisText = gameObject.GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        thisSprite = thisPacket.GetComponent<SpriteRenderer>();
        TextMeshProUGUI thisText = gameObject.GetComponent<TextMeshProUGUI>();

        
        
        if(thisPacket.tag != "untagged"){
            if(thisPacket.tag == "bloomBoosterPacket"){
            thisText.text = logic.bloomBoosterCost.ToString();
            }

            if(thisPacket.tag == "perennialCharmPacket"){
                thisText.text = logic.perennialCharmCost.ToString();
            }

            if(thisPacket.tag == "nectarCollectorPacket"){
                thisText.text = logic.nectarCollectorCost.ToString();
            }

            if(thisPacket.tag == "nectarPouchPacket"){
                thisText.text = logic.nectarPouchCost.ToString();
            }

            if(thisPacket.tag == "honeycombAcceleratorPacket"){
                thisText.text = logic.honeycombAcceleratorCost.ToString();
            }

            //Debug.Log(logic.honeycombAcceleratorCost);
        }
    }
}
