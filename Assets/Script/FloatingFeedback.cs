using UnityEngine;
using TMPro;

public class FloatingFeedback : MonoBehaviour
{
    public float floatSpeed = 50f;     // Vitesse du mouvement vers le haut
    public float lifetime = 1.5f;      // Temps avant destruction
    private TextMeshProUGUI textMesh;

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void SetText(string message, Color color)
    {
        textMesh.text = message;
        textMesh.color = color;
        Destroy(gameObject, lifetime); // se détruit tout seul
    }

    void Update()
    {
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);
    }
}
