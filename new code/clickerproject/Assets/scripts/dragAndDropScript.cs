using UnityEngine;
using UnityEngine.EventSystems;

public class dragAndDropScript : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    

    [SerializeField] private Canvas canvas;

    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        
    }

    public void OnBeginDrag(PointerEventData eventData){
        canvasGroup.alpha = .6f;
        // Debug.Log("OnBeginDrag");
    }
    
    public void OnDrag(PointerEventData eventData){
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData){
        canvasGroup.alpha = 1f;
        // Debug.Log("OnEndDrag");
    }

    public void OnPointerDown(PointerEventData eventData){
        // Debug.Log("");
    }
}
