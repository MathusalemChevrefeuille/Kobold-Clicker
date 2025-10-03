using UnityEngine;
using UnityEngine.EventSystems;

public class FoodClick : MonoBehaviour, IPointerClickHandler
{
    public GameManager gameManager;// R�f�rence au GameManager pour ajouter de la nourriture

    private RectTransform rectTransform;//  R�f�rence au RectTransform de l'image
    private Vector3 originalScale;// Stocke la taille d'origine de l'image
    public float scaleFactor = 0.8f;   // taille quand on clique
    public float resetDelay = 0.05f;   // d�lai avant retour
    public float clickCooldown = 1.0f;   // d�lai entre deux clics (1.5 secondes)
    private float lastClickTime = Mathf.NegativeInfinity; // temps du dernier clic

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // R�cup�re le RectTransform de l'image
        originalScale = rectTransform.localScale; // M�morise la taille d'origine
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // V�rifie si le cooldown est �coul�
        if (Time.time - lastClickTime < clickCooldown)
        {
            Debug.Log("Clic bloqu� (cooldown actif)");
            return;
        }

        lastClickTime = Time.time; // m�morise l�heure du clic

        // Ajoute la nourriture
        if (gameManager != null) // V�rifie que la r�f�rence n'est pas nulle
            gameManager.AddFood(); // Appelle la m�thode pour ajouter de la nourriture

        // Feedback visuel
        rectTransform.localScale = originalScale * scaleFactor; // R�tr�cit l'image
        CancelInvoke(); // Annule tout Invoke en cours
        Invoke(nameof(ResetScale), resetDelay); //  Restaure la taille apr�s un court d�lai
    }

    private void ResetScale()
    {
        rectTransform.localScale = originalScale; // Restaure la taille d'origine
    }
}
