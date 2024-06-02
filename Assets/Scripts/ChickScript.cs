using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickScript : MonoBehaviour
{
    bool isHen, isFirstEgg;
    public GameObject hen, rooster, UIManager;
    // Start is called before the first frame update
    void Awake()
    {
        UIManager = FindAnyObjectByType<UIManager>().gameObject;
        StartCoroutine(DelayIt());
    }

    //DELAY IT
    IEnumerator DelayIt()
    {
        yield return new WaitForSeconds(1);
        CheckIfEggIsFirstEgg();
    }
    //Makes first egg hen
    IEnumerator LetThereBeHen()
    {
        yield return new WaitForSeconds(9);
        isHen = true;
        SpawnHenOrRooster();
        Destroy(gameObject);
        UIManager.GetComponent<UIManager>().chickCount--;
    }

    //Timer to make chick old
    IEnumerator Adulthood()
    {
        yield return new WaitForSeconds(10);
        RandomizeAdultHood();
        SpawnHenOrRooster();
        Destroy(gameObject);
        UIManager.GetComponent<UIManager>().chickCount--;
    }
    //randomizes if it is a rooster or a hen
    void RandomizeAdultHood()
    {
        float rand = Random.Range(0, 2) == 0 ? 1 : 2;
        if (rand == 1)
        {
            isHen = true;
        }
        else
        {
            isHen= false;
        }
    }
    //Checks if it is hen or rooster
    void SpawnHenOrRooster()
    {
        if (isHen)
        {
            SpawnHen();
            UIManager.GetComponent<UIManager>().henCount++;
        }
        else
        {
            SpawnRooster();
            UIManager.GetComponent<UIManager>().roosterCount++;
        }
    }

    //Spawns Hen
    void SpawnHen()
    {
        Instantiate(hen, transform.position, Quaternion.identity);
    }

    //Spawns Rooster
    void SpawnRooster()
    {
        Instantiate(rooster, transform.position, Quaternion.identity);
    }

    //checks if the chick is first egg or not
    void CheckIfEggIsFirstEgg()
    {
        if (!isFirstEgg)
        {
            StartCoroutine(Adulthood());
        } else if (isFirstEgg)
        {
            StartCoroutine(LetThereBeHen());
        }
    }

    //makes the egg first egg
    public void FirstEgg()
    {
        isFirstEgg = true;
    }
}
