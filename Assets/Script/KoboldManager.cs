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
    public int FoodperHunter = 10;
    public int FoodClickperHunter = 5;
    public int GoldperRaider = 10;


    public int costForagerFood = 0;
    public int costForagerGold = 0;

    public int costMinerFood = 20;
    public int costMinerGold = 0;
    
    public int costShamanFood = 20;
    public int costShamanGold = 20;

    public int costScavengerFood = 20;
    public int costScavengerGold = 0;

    public int costHunterFood = 0;
    public int costHunterGold = 30;

    public int costRaiderFood = 30;
    public int costRaiderGold = 0;



    public float koboldCheckInterval = 0.5f; 
    private float koboldCheckTimer = 0f;

    public int nextKoboldThreshold = 5; 
    public float koboldThresholdMultiplier = 1.3f;

    public AudioClip koboldSpawnSound;
    public AudioSource sfxSource;

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
        if (koboldSpawnSound != null)
            sfxSource.PlayOneShot(koboldSpawnSound);
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
        int foodCost = costForagerFood;
        int goldCost = costForagerGold;

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
        int foodCost = costMinerFood;
        int goldCost = costMinerGold;

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
        int foodCost = costShamanFood;
        int goldCost = costShamanGold;

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
        int foodCost = costScavengerFood;
        int goldCost = costScavengerGold;

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
        int foodCost = costHunterFood;
        int goldCost = costHunterGold;

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
        int foodCost = costRaiderFood;
        int goldCost = costRaiderGold;

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



