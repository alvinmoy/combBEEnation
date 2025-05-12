using UnityEngine;
using System.Collections;

public class hoverScript : MonoBehaviour
{
    public Vector3 originalSize;
    public Vector3 newSize;
    private bool isReady = false;
    public Logic logic;

    void Start()
    {
        StartCoroutine(delay());
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    void OnMouseEnter()
    {
        if (isReady)
        {
            LeanTween.cancel(gameObject);
            transform.LeanScale(newSize, 0.25f).setEaseOutBack();
        }
    }

    void OnMouseExit()
    {
        if (isReady)
        {
            if(gameObject.name == "refresh"){
                Debug.Log("SDA");
                if(!logic.refereshing){
                    LeanTween.cancel(gameObject);
                    LeanTween.scale(gameObject, originalSize, 0.1f);
                }
            }else{
                LeanTween.cancel(gameObject);
                LeanTween.scale(gameObject, originalSize, 0.1f);
            }
            
        }
    }

    private IEnumerator delay()
    {
        yield return new WaitForSeconds(2.5f);
       
        originalSize = transform.localScale;
        newSize = originalSize + new Vector3(0.1F, 0.1F, 0.1F);
        isReady = true;
    }
}
