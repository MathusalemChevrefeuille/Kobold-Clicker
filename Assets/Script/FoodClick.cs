using UnityEngine;
using UnityEngine.EventSystems;

public class FoodClick : MonoBehaviour, IPointerClickHandler
{
    public GameManager gameManager;// Référence au GameManager pour ajouter de la nourriture

    private RectTransform rectTransform;//  Référence au RectTransform de l'image
    private Vector3 originalScale;// Stocke la taille d'origine de l'image
    public float scaleFactor = 0.8f;   // taille quand on clique
    public float resetDelay = 0.05f;   // délai avant retour
    public float clickCooldown = 1.0f;   // délai entre deux clics (1.5 secondes)
    private float lastClickTime = Mathf.NegativeInfinity; // temps du dernier clic

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // Récupère le RectTransform de l'image
        originalScale = rectTransform.localScale; // Mémorise la taille d'origine
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Vérifie si le cooldown est écoulé
        if (Time.time - lastClickTime < clickCooldown)
        {
            Debug.Log("Clic bloqué (cooldown actif)");
            return;
        }

        lastClickTime = Time.time; // mémorise l’heure du clic

        // Ajoute la nourriture
        if (gameManager != null) // Vérifie que la référence n'est pas nulle
            gameManager.AddFood(); // Appelle la méthode pour ajouter de la nourriture

        // Feedback visuel
        rectTransform.localScale = originalScale * scaleFactor; // Rétrécit l'image
        CancelInvoke(); // Annule tout Invoke en cours
        Invoke(nameof(ResetScale), resetDelay); //  Restaure la taille après un court délai
    }

    private void ResetScale()
    {
        rectTransform.localScale = originalScale; // Restaure la taille d'origine
    }
}
