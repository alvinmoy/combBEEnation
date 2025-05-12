using UnityEngine;

public class beeBob : MonoBehaviour
{
    public LeanTweenType easeType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LeanTween.moveY(gameObject, 400, 2.5f).setLoopPingPong().setEase(easeType);
    }

}
