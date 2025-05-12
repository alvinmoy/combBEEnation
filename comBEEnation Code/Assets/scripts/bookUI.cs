using UnityEngine;

public class bookUI : MonoBehaviour
{
    private Vector3 objectSize;

    public Canvas bookCanvas;

    public GameObject packet1;
    public GameObject packet2;
    public GameObject packet3;
    public GameObject refresh;
    public GameObject book;

    public Logic logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        objectSize = transform.localScale;
        transform.localScale = Vector2.zero;
        LeanTween.scale(gameObject, objectSize, 0.8f).setEaseSpring();
    }

    public void closeBook(){
        BoxCollider2D packet1Collider = packet1.GetComponent<BoxCollider2D>();
        BoxCollider2D packet2Collider = packet2.GetComponent<BoxCollider2D>();
        BoxCollider2D packet3Collider = packet3.GetComponent<BoxCollider2D>();
        CircleCollider2D bookCollider = book.GetComponent<CircleCollider2D>();
        CircleCollider2D refreshCollider = refresh.GetComponent<CircleCollider2D>();
        

        LeanTween.scale(gameObject, new Vector3(0,0,0),0.5f).setOnComplete(disableBook);
        
    }

    void disableBook(){
        BoxCollider2D packet1Collider = packet1.GetComponent<BoxCollider2D>();
        BoxCollider2D packet2Collider = packet2.GetComponent<BoxCollider2D>();
        BoxCollider2D packet3Collider = packet3.GetComponent<BoxCollider2D>();
        CircleCollider2D bookCollider = book.GetComponent<CircleCollider2D>();
        CircleCollider2D refreshCollider = refresh.GetComponent<CircleCollider2D>();

        bookCanvas.gameObject.SetActive(false);
        transform.localScale = objectSize;

        packet1Collider.enabled = true;
        packet2Collider.enabled = true;
        packet3Collider.enabled = true;
        bookCollider.enabled = true;
        refreshCollider.enabled = true;

        logic.playing = true;
    }

    // Update is called once per frame
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        packet1 = GameObject.Find("packet1");
        packet2 = GameObject.Find("packet2");
        packet3 = GameObject.Find("packet3");
        book = GameObject.Find("bookIcon");
        refresh = GameObject.Find("refresh");
    }
}
