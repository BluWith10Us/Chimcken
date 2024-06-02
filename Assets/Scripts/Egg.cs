using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public bool isHen;
    public GameObject chickPrefab, UIManager;

    // Start is called before the first frame update
    void Start()
    {
        UIManager = FindAnyObjectByType<UIManager>().gameObject;
        StartCoroutine(spawnChickAtCertainTime());
    }

    //timer for chick spawning
    IEnumerator spawnChickAtCertainTime()
    {
        yield return new WaitForSeconds(10);
        GameObject chick = SpawnChick();
        CheckIfFirstEgg(chick);
        DestroyEgg();
        UIManager.GetComponent<UIManager>().chickCount++;
    }

    //spawns chick
    GameObject SpawnChick()
    {
        return Instantiate(chickPrefab, transform.position, transform.rotation);
    }

    //Destroys chicken
    void DestroyEgg()
    {
        Destroy(gameObject);
        UIManager.GetComponent<UIManager>().eggCount--;
    }

    //checked if it's the first egg
    void CheckIfFirstEgg(GameObject chick)
    {
        if(isHen)
        {
            chick.GetComponent<ChickScript>().FirstEgg();
        }
    }
}
