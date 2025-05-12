using UnityEngine;
using System.Collections;

public class hexagonUIanimation : MonoBehaviour
{
    public float num;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake(){
        transform.localScale = Vector2.zero;
    }
    void Start()
    {
        StartCoroutine(delay(num));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator delay(float sec){
        yield return new WaitForSeconds(sec);
        Vector3 targetScale = new Vector3(1f, 1f, 1f);;
        float duration = 1f;

        switch (gameObject.name)
        {
            case "bookIcon":
                targetScale = new Vector3(0.5f, 0.5f, 0.5f);
                duration = 1f;
                break;

            case "flower(Clone)":
            case "item flower(Clone)":
            case "tier2Flower(Clone)":
            case "pollenConverter":
                targetScale = new Vector3(0.5f, 0.5f, 0.5f);
                duration = 1f;
                break;

            case "packet1":
            case "packet2":
            case "packet3":
                targetScale = new Vector3(0.5f, 0.5f, 0.5f);
                duration = 1f;
                break;
            case "bee(Clone)":
                targetScale = new Vector3(0.5f, 0.5f, 0.5f);
                duration = 0.5f;
                break;
            case "refresh":
                targetScale = new Vector3(0.5F, 0.5F, 0.5F);
                duration = 1f;
                break;
            case "ItemDescription(Clone)":
                targetScale = new Vector3(1F, 1F, 1F);
                duration = 0.75f;
                break;
            case "icons":
                targetScale = new Vector3(1.5F, 1.5F, 1.5F);
                duration = 1f;
                break;
            case "cell":
                targetScale = new Vector3(1.25F, 1.25F, 1.25F);
                duration = 0.8f;
                break;
        }

        transform.LeanScale(targetScale, duration).setEaseOutBack();
    }
}
