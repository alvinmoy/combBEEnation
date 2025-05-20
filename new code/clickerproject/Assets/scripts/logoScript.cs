using UnityEngine;

public class logoScript : MonoBehaviour
{
    
    void Start()
    {
        LeanTween.scale(gameObject, new Vector3(28f, 28f, 28f), 1.5f)
             .setEaseInOutSine()
             .setLoopPingPong();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
