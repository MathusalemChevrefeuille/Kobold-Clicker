using UnityEngine;
using TMPro; // Assurez-vous d'avoir TextMeshPro dans votre projet

public class FloatingText : MonoBehaviour
{
    public float floatSpeed = 50f;   // vitesse de montée
    public float lifetime = 1f;      // durée avant destruction
    private TextMeshProUGUI textMesh;   // référence au composant TextMeshProUGUI
    public int baseFontSize = 30;     // taille minimale
    public int maxFontSize = 100;     // taille maximale

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>(); // Récupère le composant TextMeshProUGUI
    }

    public void SetText(int amount, Color color)
    {
        if (textMesh != null) // Vérifie que la référence n'est pas nulle
        {
            textMesh.text = "+" + amount; // Définit le texte
            textMesh.color = color; //  Définit la couleur

            // Fonction exponentielle douce : taille = base * 1.1^amount
            float size = baseFontSize * Mathf.Pow(1.1f, amount);    // Calcule la taille

            // On limite pour éviter un texte qui explose
            textMesh.fontSize = Mathf.Clamp(size, baseFontSize, maxFontSize);
        }

        Destroy(gameObject, lifetime);
    }


    void Update()
    {
        // Fait monter le texte
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);
    }
}
