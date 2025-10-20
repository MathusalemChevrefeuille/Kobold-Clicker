using UnityEngine;

public class FoodClick : MonoBehaviour
{
    public GameManager gameManager;
    public RectTransform rectTransform;
    private Vector3 originalScale;
    public float scaleFactor = 0.8f;
    public float resetDelay = 0.05f;
    private float lastClickTime = Mathf.NegativeInfinity;

    private void Start()
    {
        originalScale = rectTransform.localScale;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition) &&
            Time.time - lastClickTime >= gameManager.CoolDownClick)
        {
            lastClickTime = Time.time;
            gameManager.AddFoodClick();

            rectTransform.localScale = originalScale * scaleFactor;
            CancelInvoke();
            Invoke(nameof(ResetScale), resetDelay);
        }
    }

    private void ResetScale()
    {
        rectTransform.localScale = originalScale;
    }
}
