using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class radialIndicatorClickScript : MonoBehaviour
{
    public float time;
    public Image fill;
    public float max;
    public Logic logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update(){
        if(logic.playing){
            time -= Time.deltaTime;
        fill.fillAmount = time / max;

        if (time < 0){
            time = 0;
            }
        }
    }
}
