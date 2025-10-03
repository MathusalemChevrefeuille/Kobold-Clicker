using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Ressources 
    public int food = 0;       
    public int gold = 0;       

    // Kobolds 
    public int totalKobolds = 0;   
    public int idleKobolds = 0;    
    public int koboldsMiner = 0;        
    public int koboldsForager = 0;      
    public int koboldsScavenger = 0;   
    public int koboldsShaman = 0;       
    public int koboldsRaider = 0;       
    public int koboldsHunter = 0;       

    // Param�tres des clicks 
    public int foodPerClick = 1;         
    public float clickCooldown = 0.5f;    

    private float lastClickTime = 0f;     // dernier clic m�moris�
    //Floating text
    public GameObject floatingTextPrefab; // assigne dans l�inspecteur
    public Canvas canvas;                 // assigne ton Canvas ici
    //Particles
    public GameObject clickParticlesPrefab; // assigne dans l�inspecteur


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void AddFood() 
    {
        food += foodPerClick;
        Debug.Log("Nourriture : " + food);

        ShowFloatingText(foodPerClick);
    }
    private void ShowFloatingText(int amount)
    {
        if (floatingTextPrefab == null || canvas == null) // v�rifie les r�f�rences
        {
            Debug.LogError("Assigne le prefab et le canvas dans l�inspecteur !");
            return;
        }

        GameObject obj = Instantiate(floatingTextPrefab, canvas.transform); // cr�e le texte flottant
        obj.transform.position = Input.mousePosition;   //  positionne � la souris

        var ft = obj.GetComponent<FloatingText>();  // r�cup�re le script FloatingText
        if (ft != null)
        {
            ft.SetText(amount, new Color(0.36f, 0.25f, 0.20f)); // exemple marron "cahier grill�"
        }
    }
 
    void Start()
    {
        idleKobolds = totalKobolds; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
