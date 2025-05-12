using UnityEngine;

public class closeBook : MonoBehaviour
{
    public Canvas bookCanvas;

    public GameObject packet1;
    public GameObject packet2;
    public GameObject packet3;
    public GameObject book;

    public bookUI tweenTrigger;
    public Logic logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        packet1 = GameObject.Find("packet1");
        packet2 = GameObject.Find("packet2");
        packet3 = GameObject.Find("packet3");
        book = GameObject.Find("bookIcon");
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        BoxCollider2D packet1Collider = packet1.GetComponent<BoxCollider2D>();
        BoxCollider2D packet2Collider = packet2.GetComponent<BoxCollider2D>();
        BoxCollider2D packet3Collider = packet3.GetComponent<BoxCollider2D>();
        CircleCollider2D bookCollider = book.GetComponent<CircleCollider2D>();
        
        bookCanvas.gameObject.SetActive(false);
        packet1Collider.enabled = true;
        packet2Collider.enabled = true;
        packet3Collider.enabled = true;
        bookCollider.enabled = true;
        logic.playing = true;
    }
}
