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
    public float shamanClickReducer = 0.05f;
    public int GoldperScavenger = 5;
    public int FoodperHunter = 5;
    public int FoodClickperHunter = 5;
    public int GoldperRaider = 5;


    public float koboldCheckInterval = 0.5f; 
    private float koboldCheckTimer = 0f;

    public int nextKoboldThreshold = 10; 
    public float koboldThresholdMultiplier = 1.5f; 

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


    public int AssignForager()
    {
        int foodCost = 0;
        int goldCost = 0;

        if (idleKobolds <= 0) return 0;
        if (gameManager.food < foodCost || gameManager.gold < goldCost) return 1;

        gameManager.food -= foodCost;
        gameManager.gold -= goldCost;

        koboldsForager++;
        idleKobolds--;

        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
        return 2;
    }

    public int UnassignForager()
    {
        if (koboldsForager <= 0) return 0;

        koboldsForager -= 1;
        idleKobolds += 1;
        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
        return 1;
    }

    public int AssignMiner()
    {
        int foodCost = 20;
        int goldCost = 0;

        if (idleKobolds <= 0) return 0;
        if (gameManager.food < foodCost || gameManager.gold < goldCost) return 1;

        gameManager.food -= foodCost;
        gameManager.gold -= goldCost;

        koboldsMiner++;
        idleKobolds--;

        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
        return 2;
    }

    public int UnassignMiner()
    {
        if (koboldsMiner <= 0) return 0;

        koboldsMiner -= 1;
        idleKobolds += 1;
        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
        return 1;
    }

    public int AssignShaman()
    {
        int foodCost = 20;
        int goldCost = 20;

        if (idleKobolds <= 0) return 0;
        if (gameManager.food < foodCost || gameManager.gold < goldCost) return 1;

        gameManager.food -= foodCost;
        gameManager.gold -= goldCost;

        koboldsShaman++;
        idleKobolds--;

        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
        return 2;
    }

    public int UnassignShaman()
    {
        if (koboldsShaman <= 0) return 0;

        koboldsShaman -= 1;
        idleKobolds += 1;
        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
        return 1;
    }

    public int AssignScavenger()
    {
        int foodCost = 20;
        int goldCost = 0;

        if (idleKobolds <= 0) return 0;
        if (gameManager.food < foodCost || gameManager.gold < goldCost) return 1;

        gameManager.food -= foodCost;
        gameManager.gold -= goldCost;

        koboldsScavenger++;
        idleKobolds--;

        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
        return 2;
    }

    public int UnassignScavenger()
    {
        if (koboldsScavenger <= 0) return 0;

        koboldsScavenger -= 1;
        idleKobolds += 1;
        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
        return 1;
    }

    public int AssignHunter()
    {
        int foodCost = 0;
        int goldCost = 30;

        if (idleKobolds <= 0) return 0;
        if (gameManager.food < foodCost || gameManager.gold < goldCost) return 1;

        gameManager.food -= foodCost;
        gameManager.gold -= goldCost;

        koboldsHunter++;
        idleKobolds--;

        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
        return 2;
    }

    public int UnassignHunter()
    {
        if (koboldsHunter <= 0) return 0;

        koboldsHunter -= 1;
        idleKobolds += 1;
        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
        return 1;
    }


    public int AssignRaider()
    {
        int foodCost = 30;
        int goldCost = 0;

        if (idleKobolds <= 0) return 0;
        if (gameManager.food < foodCost || gameManager.gold < goldCost) return 1;

        gameManager.food -= foodCost;
        gameManager.gold -= goldCost;

        koboldsRaider++;
        idleKobolds--;

        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
        return 2;
    }

    public int UnassignRaider()
    {
        if (koboldsRaider <= 0) return 0;

        koboldsRaider -= 1;
        idleKobolds += 1;
        gameManager.uiManager.UpdateAllDisplays(gameManager.food, gameManager.gold, this);
        return 1;

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



