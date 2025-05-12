using UnityEngine;

public class openBook : MonoBehaviour
{
    public Canvas bookCanvas;

    public GameObject packet1;
    public GameObject packet2;
    public GameObject packet3;
    public GameObject book;
    public GameObject refresh;
    public Logic logic;

    float cooldownTime = 1f; // Time in seconds before the Escape key can be pressed again
    float nextActionTime = 0f; // Time when the Escape key can be pressed again
    public GameObject Book;
    private Vector3 objectSize;

    public AudioClip bookSound;

    void Start()
    {
        packet1 = GameObject.Find("packet1");
        packet2 = GameObject.Find("packet2");
        packet3 = GameObject.Find("packet3");
        refresh = GameObject.Find("refresh");
        book = gameObject;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        objectSize = Book.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextActionTime)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (!bookCanvas.gameObject.activeSelf)
                {
                    BoxCollider2D packet1Collider = packet1.GetComponent<BoxCollider2D>();
                    BoxCollider2D packet2Collider = packet2.GetComponent<BoxCollider2D>();
                    BoxCollider2D packet3Collider = packet3.GetComponent<BoxCollider2D>();
                    CircleCollider2D bookCollider = book.GetComponent<CircleCollider2D>();
                    CircleCollider2D refreshCollider = refresh.GetComponent<CircleCollider2D>();

                    bookCanvas.gameObject.SetActive(true);
                    packet1Collider.enabled = false;
                    packet2Collider.enabled = false;
                    packet3Collider.enabled = false;
                    bookCollider.enabled = false;
                    refreshCollider.enabled = false;
                    logic.playing = false;
                }
                else
                {
                    closeBook();
                }

                nextActionTime = Time.time + cooldownTime; // Set the next time the Escape key can be pressed
            }
        }
    }

    public void closeBook(){
        BoxCollider2D packet1Collider = packet1.GetComponent<BoxCollider2D>();
        BoxCollider2D packet2Collider = packet2.GetComponent<BoxCollider2D>();
        BoxCollider2D packet3Collider = packet3.GetComponent<BoxCollider2D>();
        CircleCollider2D bookCollider = book.GetComponent<CircleCollider2D>();
        CircleCollider2D refreshCollider = refresh.GetComponent<CircleCollider2D>();
        

        LeanTween.scale(Book, new Vector3(0,0,0),0.5f).setOnComplete(disableBook);
        
    }

    void disableBook(){
        BoxCollider2D packet1Collider = packet1.GetComponent<BoxCollider2D>();
        BoxCollider2D packet2Collider = packet2.GetComponent<BoxCollider2D>();
        BoxCollider2D packet3Collider = packet3.GetComponent<BoxCollider2D>();
        CircleCollider2D bookCollider = book.GetComponent<CircleCollider2D>();
        CircleCollider2D refreshCollider = refresh.GetComponent<CircleCollider2D>();

        bookCanvas.gameObject.SetActive(false);
        Book.transform.localScale = objectSize;

        packet1Collider.enabled = true;
        packet2Collider.enabled = true;
        packet3Collider.enabled = true;
        bookCollider.enabled = true;
        refreshCollider.enabled = true;

        logic.playing = true;
    }

    void OnMouseDown(){
        BoxCollider2D packet1Collider = packet1.GetComponent<BoxCollider2D>();
        BoxCollider2D packet2Collider = packet2.GetComponent<BoxCollider2D>();
        BoxCollider2D packet3Collider = packet3.GetComponent<BoxCollider2D>();
        CircleCollider2D bookCollider = book.GetComponent<CircleCollider2D>();
        CircleCollider2D refreshCollider = refresh.GetComponent<CircleCollider2D>();

        bookCanvas.gameObject.SetActive(true);
        packet1Collider.enabled = false;
        packet2Collider.enabled = false;
        packet3Collider.enabled = false;
        bookCollider.enabled = false;
        refreshCollider.enabled = false;
        logic.playing = false;
    }

    void OnMouseEnter(){
        soundManager.instance.playSoundFXClip(bookSound, transform, 0.5f);
    }
}
