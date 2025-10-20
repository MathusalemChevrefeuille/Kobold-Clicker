using UnityEngine;

public class KoboldManager : MonoBehaviour
{
    public GameManager gameManager;

    public int totalKobolds = 0;
    public int idleKobolds = 0;
    public int koboldsMiner = 0;
    public int koboldsForager = 0;
    public int koboldsShaman = 0;
    public int koboldsScavenger = 0;
    public int koboldsHunter = 0;
    public int koboldsRaider = 0;


    public float productionInterval = 1f;

    public int foodPerForager = 1;
    public int GoldPerMiner = 1;
    public float shamanClickReducer = 0.03f;
    public int GoldperScavenger = 5;
    public int FoodperHunter = 5;
    public int FoodClickperHunter = 5;
    public int GoldperRaider = 5;


    public float koboldCheckInterval = 0.5f; 
    private float koboldCheckTimer = 0f;

    public int nextKoboldThreshold = 10; 
    public float koboldThresholdMultiplier = 1.8f; 

    public void UpdateTotalKobolds()
    {
        totalKobolds = idleKobolds + koboldsMiner + koboldsForager + koboldsShaman + koboldsScavenger + koboldsHunter + koboldsRaider;
        UpdateHunterBonus();
        UpdateShamanBonus();
        gameManager.uiManager.UpdateKoboldDisplay(this);
    }

    public void NewKobold()
    {
        idleKobolds += 1;
        UpdateTotalKobolds();
    }

    public void ProduceResources() 
    {
        int FoodByKobolds = (koboldsForager * foodPerForager) + (koboldsHunter * FoodperHunter);
        int GoldByKobolds = (koboldsMiner * GoldPerMiner) + (koboldsScavenger * GoldperScavenger) + (koboldsRaider * GoldperRaider);

        gameManager.AddFoodKobols(FoodByKobolds);
        gameManager.AddGold(GoldByKobolds);
    }

    public void UpdateHunterBonus()
    {
        gameManager.foodPerClick = gameManager.baseFoodPerClick + (koboldsHunter * FoodClickperHunter);
    }
    public void UpdateShamanBonus()
    {
        gameManager.CoolDownClick = gameManager.baseCoolDownClick - (koboldsShaman * shamanClickReducer);   
    }


    private void Awake()
    {
        UpdateTotalKobolds();
    }

    private void Start()
    {
        InvokeRepeating(nameof(ProduceResources), productionInterval, productionInterval);
        UpdateTotalKobolds();
    }


    public void AssignForager()
    {
        int foodCost = 0;
        int goldCost = 0;

        if (idleKobolds <= 0) return;
        if (gameManager.food < foodCost || gameManager.gold < goldCost) return;

        gameManager.food -= foodCost;
        gameManager.gold -= goldCost;

        koboldsForager++;
        idleKobolds--;

        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
    }

    public void UnassignForager()
    {
        if (koboldsForager <= 0) return;

        koboldsForager -= 1;
        idleKobolds += 1;
        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
    }

    public void AssignMiner()
    {
        int foodCost = 20;
        int goldCost = 0;

        if (idleKobolds <= 0) return;
        if (gameManager.food < foodCost || gameManager.gold < goldCost) return;

        gameManager.food -= foodCost;
        gameManager.gold -= goldCost;

        koboldsMiner++;
        idleKobolds--;

        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
    }

    public void UnassignMiner()
    {
        if (koboldsForager <= 0) return;

        koboldsMiner -= 1;
        idleKobolds += 1;
        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
    }

    public void AssignShaman()
    {
        int foodCost = 20;
        int goldCost = 20;

        if (idleKobolds <= 0) return;
        if (gameManager.food < foodCost || gameManager.gold < goldCost) return;

        gameManager.food -= foodCost;
        gameManager.gold -= goldCost;

        koboldsShaman++;
        idleKobolds--;

        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
    }

    public void UnassignShaman()
    {
        if (koboldsForager <= 0) return;

        koboldsShaman -= 1;
        idleKobolds += 1;
        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
    }

    public void AssignScavenger()
    {
        int foodCost = 20;
        int goldCost = 0;

        if (idleKobolds <= 0) return;
        if (gameManager.food < foodCost || gameManager.gold < goldCost) return;

        gameManager.food -= foodCost;
        gameManager.gold -= goldCost;

        koboldsScavenger++;
        idleKobolds--;

        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
    }

    public void UnassignScavenger()
    {
        if (koboldsForager <= 0) return;

        koboldsScavenger -= 1;
        idleKobolds += 1;
        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
    }

    public void AssignHunter()
    {
        int foodCost = 0;
        int goldCost = 30;

        if (idleKobolds <= 0) return;
        if (gameManager.food < foodCost || gameManager.gold < goldCost) return;

        gameManager.food -= foodCost;
        gameManager.gold -= goldCost;

        koboldsHunter++;
        idleKobolds--;

        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
    }

    public void UnassignHunter()
    {
        if (koboldsForager <= 0) return;

        koboldsHunter -= 1;
        idleKobolds += 1;
        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
    }


    public void AssignRaider()
    {
        int foodCost = 30;
        int goldCost = 0;

        if (idleKobolds <= 0) return;
        if (gameManager.food < foodCost || gameManager.gold < goldCost) return;

        gameManager.food -= foodCost;
        gameManager.gold -= goldCost;

        koboldsRaider++;
        idleKobolds--;

        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
    }

    public void UnassignRaider()
    {
        if (koboldsForager <= 0) return;

        koboldsRaider -= 1;
        idleKobolds += 1;
        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
    }

    private void Update()
    {
        koboldCheckTimer += Time.deltaTime;
        if (koboldCheckTimer >= koboldCheckInterval)
        {
            koboldCheckTimer = 0f;
            if (gameManager.food >= nextKoboldThreshold)
            {
                NewKobold();
                nextKoboldThreshold = Mathf.CeilToInt(nextKoboldThreshold * koboldThresholdMultiplier);
                gameManager.uiManager.UpdateFoodDisplay(gameManager.food);
                gameManager.uiManager.UpdateKoboldDisplay(this);
            }
        }
    }
}



