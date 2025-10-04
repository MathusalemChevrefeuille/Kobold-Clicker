using TMPro;
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
    public int koboldsShaman = 0;
    public int koboldsScavenger = 0;             
    public int koboldsHunter = 0;
    public int koboldsRaider = 0;

    // Paramètres des clicks 
    public int foodPerClick = 1;           

    private float lastClickTime = 0f;     // dernier clic mémorisé
    //Floating text
    public GameObject floatingTextPrefab; // assigne dans l’inspecteur
    public Canvas canvas;                 // assigne ton Canvas ici

    // Références UI
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI koboldtotalText;
    public TextMeshProUGUI koboldIdleText;
    public TextMeshProUGUI koboldMinerText;
    public TextMeshProUGUI koboldForagerText;
    public TextMeshProUGUI koboldShamanText;
    public TextMeshProUGUI koboldScavengerText;
    public TextMeshProUGUI koboldHunterText;
    public TextMeshProUGUI koboldRaiderText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void AddFood() 
    {
        food += foodPerClick;

        ShowFloatingText(foodPerClick);
        UpdateUI();
    }

    public void AddGold(int amount)
    {
        gold += amount;
        UpdateUI();
    }
    private void ShowFloatingText(int amount)
    {
       
        GameObject obj = Instantiate(floatingTextPrefab, canvas.transform); // crée le texte flottant
        obj.transform.position = Input.mousePosition;   //  positionne à la souris

        var ft = obj.GetComponent<FloatingText>();  // récupère le script FloatingText
        
        ft.SetText(amount,Color.green ); 
        
    }

    private void UpdateUI()
    {
        foodText.text = "" + food;
        goldText.text = "" + gold;
        koboldtotalText.text = totalKobolds.ToString();
        koboldIdleText.text = idleKobolds.ToString();
        koboldMinerText.text = koboldsMiner.ToString();
        koboldForagerText.text = koboldsForager.ToString();
        koboldShamanText.text = koboldsShaman.ToString();
        koboldScavengerText.text = koboldsScavenger.ToString();
        koboldHunterText.text = koboldsHunter.ToString();
        koboldRaiderText.text = koboldsRaider.ToString();
    }

    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
