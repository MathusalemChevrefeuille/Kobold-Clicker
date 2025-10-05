using UnityEngine;
using TMPro; 

public class FloatingText : MonoBehaviour
{
    public float floatSpeed = 50f;   
    public float lifetime = 1f;      
    private TextMeshProUGUI textMesh;   
    public int baseFontSize = 30;     
    public int maxFontSize = 100;     

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>(); 
    }

    public void SetText(int amount, Color color)
    {
        
         textMesh.text = "+" + amount; 
         textMesh.color = color; 

         // Fonction exponentielle douce 
         float size = baseFontSize * Mathf.Pow(2.0f, amount);    

         // On limite pour éviter un texte qui explose
         textMesh.fontSize = Mathf.Clamp(size, baseFontSize, maxFontSize);
        

        Destroy(gameObject, lifetime);
    }


    void Update()
    {
        
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);
    }
}
