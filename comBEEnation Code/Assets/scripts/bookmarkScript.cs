using UnityEngine;

public class bookmarkScript : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject page5;

    public GameObject blueMark;
    public GameObject purpleMark;
    public GameObject greenMark;
    public GameObject redMark;
    public GameObject orangeMark;
    public GameObject paper;

    public AudioClip[] paperAudios;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        SpriteRenderer blueMarkSprite = blueMark.GetComponent<SpriteRenderer>();
        SpriteRenderer purpleMarkSprite = purpleMark.GetComponent<SpriteRenderer>();
        SpriteRenderer greenMarkSprite = greenMark.GetComponent<SpriteRenderer>();
        SpriteRenderer redMarkSprite = redMark.GetComponent<SpriteRenderer>();
        SpriteRenderer orangeMarkSprite = orangeMark.GetComponent<SpriteRenderer>();
        SpriteRenderer paperSprite = paper.GetComponent<SpriteRenderer>();

        blueMarkSprite.sortingLayerID = paperSprite.sortingLayerID;
        purpleMarkSprite.sortingLayerID = paperSprite.sortingLayerID;  
        greenMarkSprite.sortingLayerID = paperSprite.sortingLayerID;  
        redMarkSprite.sortingLayerID = paperSprite.sortingLayerID;  
        orangeMarkSprite.sortingLayerID = paperSprite.sortingLayerID; 

        blueMarkSprite.sortingOrder = paperSprite.sortingOrder - 1;
        purpleMarkSprite.sortingOrder = paperSprite.sortingOrder - 1;
        greenMarkSprite.sortingOrder = paperSprite.sortingOrder - 1;
        redMarkSprite.sortingOrder = paperSprite.sortingOrder - 1;
        orangeMarkSprite.sortingOrder = paperSprite.sortingOrder - 1;

        if(gameObject.name == "blueMark"){
            page1.gameObject.SetActive(true);
            page2.gameObject.SetActive(false);
            page3.gameObject.SetActive(false);
            page4.gameObject.SetActive(false);
            page5.gameObject.SetActive(false);

            blueMarkSprite.sortingOrder = paperSprite.sortingOrder + 1;
            soundManager.instance.playRandomSoundFXClip(paperAudios, transform, 0.5f);
        }

        if(gameObject.name == "purpleMark"){
            page1.gameObject.SetActive(false);
            page2.gameObject.SetActive(true);
            page3.gameObject.SetActive(false);
            page4.gameObject.SetActive(false);
            page5.gameObject.SetActive(false);

            purpleMarkSprite.sortingOrder = paperSprite.sortingOrder + 1;
            soundManager.instance.playRandomSoundFXClip(paperAudios, transform, 0.5f);
        }

        if(gameObject.name == "greenMark"){
            page1.gameObject.SetActive(false);
            page2.gameObject.SetActive(false);
            page3.gameObject.SetActive(true);
            page4.gameObject.SetActive(false);
            page5.gameObject.SetActive(false);

            greenMarkSprite.sortingOrder = paperSprite.sortingOrder + 1;
            soundManager.instance.playRandomSoundFXClip(paperAudios, transform, 0.5f);
        }

        if(gameObject.name == "redMark"){
            page1.gameObject.SetActive(false);
            page2.gameObject.SetActive(false);
            page3.gameObject.SetActive(false);
            page4.gameObject.SetActive(true);
            page5.gameObject.SetActive(false);

            redMarkSprite.sortingOrder = paperSprite.sortingOrder + 1;
            soundManager.instance.playRandomSoundFXClip(paperAudios, transform, 0.5f);
        }

        if(gameObject.name == "orangeMark"){
            page1.gameObject.SetActive(false);
            page2.gameObject.SetActive(false);
            page3.gameObject.SetActive(false);
            page4.gameObject.SetActive(false);
            page5.gameObject.SetActive(true);

            orangeMarkSprite.sortingOrder = paperSprite.sortingOrder + 1;
            soundManager.instance.playRandomSoundFXClip(paperAudios, transform, 0.5f);
        }
    }
}
