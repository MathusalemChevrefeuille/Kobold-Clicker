using UnityEngine;
using System.Collections;

public class SpriteManager : MonoBehaviour
{
    [Header("Sprites nourriture")]
    public GameObject[] smallFood;
    public GameObject middleFood;
    public GameObject bigFood;

    [Header("Sprites or")]
    public GameObject[] smallGold;
    public GameObject middleGold;
    public GameObject bigGold;

    [Header("Références")]
    public GameManager gameManager;

  
    bool smallFoodUnlocked, middleFoodUnlocked, bigFoodUnlocked;
    bool smallGoldUnlocked, middleGoldUnlocked, bigGoldUnlocked;

 

    void Update()
    {
        CheckFood();
        CheckGold();
    }

 
    void CheckFood()
    {
        int f = gameManager.food;

        if (!smallFoodUnlocked && f >= 100)
        {
            smallFoodUnlocked = true;
            StartCoroutine(FadeInArray(smallFood));
        }
        if (!middleFoodUnlocked && f >= 300)
        {
            middleFoodUnlocked = true;
            StartCoroutine(FadeInOne(middleFood));
        }
        if (!bigFoodUnlocked && f >= 500)
        {
            bigFoodUnlocked = true;
            StartCoroutine(FadeInOne(bigFood));
        }
    }

 
    void CheckGold()
    {
        int g = gameManager.gold;

        if (!smallGoldUnlocked && g >= 100)
        {
            smallGoldUnlocked = true;
            StartCoroutine(FadeInArray(smallGold));
        }
        if (!middleGoldUnlocked && g >= 300)
        {
            middleGoldUnlocked = true;
            StartCoroutine(FadeInOne(middleGold));
        }
        if (!bigGoldUnlocked && g >= 500)
        {
            bigGoldUnlocked = true;
            StartCoroutine(FadeInOne(bigGold));
        }
    }


    void SetActiveArray(GameObject[] arr, bool state)
    {
        if (arr == null) return; 
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null) 
                arr[i].SetActive(state); 
        }
    }

    
    void SafeSetActive(GameObject go, bool state)
    {
        if (go != null) go.SetActive(state);
    }

    
    IEnumerator FadeInArray(GameObject[] arr)
    {
        if (arr == null) yield break;
        foreach (var go in arr)
        {
            if (go != null)
                yield return StartCoroutine(FadeInOne(go)); 
        }
    }

    
    IEnumerator FadeInOne(GameObject obj)
    {
        if (obj == null) yield break;

       
        CanvasGroup group = obj.GetComponent<CanvasGroup>();
        if (group == null)
            group = obj.AddComponent<CanvasGroup>();

        obj.SetActive(true); 
        group.alpha = 0;     

        float duration = 1f;
        float timer = 0f;

      
        while (timer < duration)
        {
            timer += Time.deltaTime; 
            group.alpha = Mathf.Lerp(0f, 1f, timer / duration); 
            yield return null;
        }

        group.alpha = 1f; 
    }
}
