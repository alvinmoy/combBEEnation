using UnityEngine;

public class refreshScript : MonoBehaviour
{
    public Logic logic;
    public GameObject packet1;
    public GameObject packet2;
    public GameObject packet3;

    public GameObject UI;

    public gameworldDragAndDrop packet1Script;
    public gameworldDragAndDrop packet2Script;
    public gameworldDragAndDrop packet3Script;

    public Vector3 objectSize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        packet1 = GameObject.Find("packet1");
        packet2 = GameObject.Find("packet2");
        packet3 = GameObject.Find("packet3");

        packet1Script = packet1.GetComponent<gameworldDragAndDrop>();
        packet2Script = packet2.GetComponent<gameworldDragAndDrop>();
        packet3Script = packet3.GetComponent<gameworldDragAndDrop>();

        objectSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        CircleCollider2D collider = gameObject.GetComponent<CircleCollider2D>();
        if(!logic.playing){
            collider.enabled=false;
        }else{
            collider.enabled=true;
        }
    }

    void OnMouseDown(){
        if(logic.honey >= logic.refreshCost){
            logic.honey-= logic.refreshCost;
            packet1Script.selfRng = true;
            packet2Script.selfRng = true;
            packet3Script.selfRng = true;
            logic.refereshing = true;
            LeanTween.scale(gameObject, new Vector3(0,0,0),0.5f).setOnComplete(disableRefresh);
            LeanTween.scale(UI, new Vector3(0,0,0),0.5f).setOnComplete(disableRefresh);
        }
    }

    public void disableRefresh(){
        gameObject.SetActive(false);
        UI.SetActive(false);
        logic.refereshing = false;
        transform.localScale = objectSize;
    }

    public void enable(){
        if(!gameObject.activeSelf){
            gameObject.SetActive(true);
            UI.SetActive(true);
            transform.localScale = Vector2.zero;
            UI.transform.localScale = Vector2.zero;

            transform.LeanScale(new Vector3(0.5f, 0.5f, 0.5f), 1f).setEaseOutBack();
            UI.transform.LeanScale(new Vector3(1, 1, 1), 1f).setEaseOutBack();
        }
    }
}
