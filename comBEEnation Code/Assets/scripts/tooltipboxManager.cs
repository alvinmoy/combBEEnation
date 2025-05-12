using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class tooltipboxManager : MonoBehaviour
{
    public static tooltipboxManager _instance;

    public TextMeshProUGUI thisText;
    public TextMeshProUGUI thisName;
    public Image packet1;
    public Image packet2;
    public Image packet3;

    public Sprite bloomBoosterPacket;
    public Sprite perennialCharmPacket;
    public Sprite nectarCollectorPacket;
    public Sprite nectarPouchPacket;
    public Sprite honeycombAcceleratorPacket;

    private void Awake(){
        if(_instance !=null && _instance != this){
            Destroy(this.gameObject);
        }else{
            _instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        RectTransform panelRect = GetComponent<RectTransform>();

        // Normalize the mouse position relative to screen width
        float normalizedMouseX = mousePos.x / Screen.width;

        if (normalizedMouseX > 0.5f) {
            // For right half of the screen, adjust position
            panelRect.position = new Vector3(mousePos.x - 235, mousePos.y + 20, panelRect.position.z);
        } else {
            // For left half, no offset
            panelRect.position = new Vector3(mousePos.x, mousePos.y + 20, panelRect.position.z);
        }
    }

    public void setAndShowToolTip(string message, string name){
        gameObject.SetActive(true);
        thisText.text = message;
        thisName.text = name;
    }

    public void hideTooltip(){
        gameObject.SetActive(false);
        packet1.gameObject.SetActive(true);
        packet2.gameObject.SetActive(true);
        packet3.gameObject.SetActive(true);
        thisText.text = string.Empty;
    }

    public void setImage(Sprite image1){
        packet3.sprite = image1;
        packet1.gameObject.SetActive(false);
        packet2.gameObject.SetActive(false);
    }

    public void setImage(Sprite image1, Sprite image2){
        packet1.sprite = image1;
        packet2.sprite = image2;
        packet3.gameObject.SetActive(false);
    }
}
