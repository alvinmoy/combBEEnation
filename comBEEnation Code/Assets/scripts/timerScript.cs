
using UnityEngine;

public class timerScript : MonoBehaviour
{
    public float timer;
    public float second;

    public float min;
    public float sec;

    public Logic logic;
    public Item item;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        item = GameObject.FindGameObjectWithTag("Item").GetComponent<Item>();
        min = Mathf.FloorToInt(logic.currentTime / 60);
        sec = Mathf.FloorToInt(logic.currentTime % 60);

        logic.currentTimeText.text = string.Format("{0:00}:{1:00}", min, sec);

    }

    // Update is called once per frame
    void Update()
    {
        min = Mathf.FloorToInt(logic.currentTime / 60);
        sec = Mathf.FloorToInt(logic.currentTime % 60);
        logic.currentTimeText.text = string.Format("{0:00}:{1:00}", min, sec);
        if(logic.playing){
            if(timer < second){
                timer += Time.deltaTime;
            }else{
                if(logic.currentTime >= 0){
                    updateTimer();
                    timer = 0;
                }
            }
        }
    }    

    void updateTimer(){
        logic.currentTime-=1;
        if(logic.currentTime <= 10 && logic.currentTime > 0){
            LeanTween.scale(logic.currentTimeText.gameObject, new Vector3(1.25f, 1.25f, 1.25f), 0.2f).setOnComplete(turnTextSmall);
        }
        min = Mathf.FloorToInt(logic.currentTime / 60);
        sec = Mathf.FloorToInt(logic.currentTime % 60);
        logic.currentTimeText.text = string.Format("{0:00}:{1:00}", min, sec);        
    }
    
    void turnTextSmall(){
        LeanTween.scale(logic.currentTimeText.gameObject, new Vector3(1f, 1f, 1f), 0.2f);
    }
}
