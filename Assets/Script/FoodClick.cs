using UnityEngine;
using UnityEngine.EventSystems;

public class FoodClick : MonoBehaviour, IPointerClickHandler
{
    public GameManager gameManager;

    private RectTransform rectTransform;
    private Vector3 originalScale;// Stocke la taille d'origine de l'image
    public float scaleFactor = 0.8f;   
    public float resetDelay = 0.05f;   
    public float clickCooldown = 1.0f;   
    private float lastClickTime = Mathf.NegativeInfinity; 

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>(); 
        originalScale = rectTransform.localScale; 
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        lastClickTime = Time.time; 

       
        gameManager.AddFood(); 

        // Feedback visuel
        rectTransform.localScale = originalScale * scaleFactor; 
        CancelInvoke(); 
        Invoke(nameof(ResetScale), resetDelay); 
    }

    private void ResetScale()
    {
        rectTransform.localScale = originalScale; 
    }
}
