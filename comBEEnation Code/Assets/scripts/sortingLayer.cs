using UnityEngine;

public class sortingLayer : MonoBehaviour
{
    public GameObject reference;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer thisSprite = gameObject.GetComponent<SpriteRenderer>();
        SpriteRenderer referenceSprite = reference.GetComponent<SpriteRenderer>();


        thisSprite.sortingLayerID = referenceSprite.sortingLayerID;
        thisSprite.sortingOrder = referenceSprite.sortingOrder;

    }
}
