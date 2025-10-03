using UnityEngine;
using TMPro; // Assurez-vous d'avoir TextMeshPro dans votre projet

public class FloatingText : MonoBehaviour
{
    public float floatSpeed = 50f;   // vitesse de mont�e
    public float lifetime = 1f;      // dur�e avant destruction
    private TextMeshProUGUI textMesh;   // r�f�rence au composant TextMeshProUGUI
    public int baseFontSize = 30;     // taille minimale
    public int maxFontSize = 100;     // taille maximale

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>(); // R�cup�re le composant TextMeshProUGUI
    }

    public void SetText(int amount, Color color)
    {
        if (textMesh != null) // V�rifie que la r�f�rence n'est pas nulle
        {
            textMesh.text = "+" + amount; // D�finit le texte
            textMesh.color = color; //  D�finit la couleur

            // Fonction exponentielle douce : taille = base * 1.1^amount
            float size = baseFontSize * Mathf.Pow(1.1f, amount);    // Calcule la taille

            // On limite pour �viter un texte qui explose
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
