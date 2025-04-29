using UnityEngine;

public class resizeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = 1920f / 1080f;  // Target resolution ratio

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = 5;  // Default size
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = 5 * differenceInSize;
        }
    }
}
