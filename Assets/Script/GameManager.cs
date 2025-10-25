using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int food = 0;
    public int gold = 0;
    public int baseFoodPerClick = 1;
    public int foodPerClick = 1;
    public float baseCoolDownClick = 1f;
    public float CoolDownClick = 1f;




    public UIManager uiManager;
    public KoboldManager koboldManager;

    public GameObject floatingTextPrefab;
    public Canvas canvas;
    public GameObject endScreen;
    public int victoryThreshold = 1000; 
    private bool gameEnded = false;
    public AudioSource musicSource;
    public AudioClip backgroundMusic;

    public void AddFoodClick()
    {
        food += foodPerClick;
        uiManager.UpdateFoodDisplay(food);
        ShowFloatingText(foodPerClick);
    }

    public void AddFoodKobols(int amount)
    {
        food += amount;
        uiManager.UpdateFoodDisplay(food);
    }

    public void AddGold(int amount)
    {
        gold += amount;
        uiManager.UpdateGoldDisplay(gold);
    }

    private void ShowFloatingText(int amount)
    {
        GameObject obj = Instantiate(floatingTextPrefab, canvas.transform);
        obj.transform.position = Input.mousePosition;

        var ft = obj.GetComponent<FloatingText>();
        ft.SetText(amount, Color.green);
    }

    private void Start()
    {
        uiManager.UpdateAllDisplays(food, gold, koboldManager);
        if (musicSource != null && backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    private void CheckVictory()
    {
        if (!gameEnded && food >= victoryThreshold && gold >= victoryThreshold)
        {
            gameEnded = true;
            ShowEndScreen();
        }
    }

    private void ShowEndScreen()
    {
        if (endScreen != null)
        {
            endScreen.SetActive(true);
        }
    }
    public void Update()
    {
        CheckVictory();
    }
}
