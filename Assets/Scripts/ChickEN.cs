using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickEN : MonoBehaviour
{
    public bool isHen;
    public GameObject egg, UIManager;
    // Start is called before the first frame update
    void Awake()
    {
        UIManager = FindAnyObjectByType<UIManager>().gameObject;

        if (isHen)
        {
            StartCoroutine(HenLayEggs());
        }
        else
        {
            StartCoroutine(RoostersLifespan());
        }
        
    }

    //makes hen lay eggs
    IEnumerator HenLayEggs()
    {
        yield return new WaitForSeconds(30);
        int eggAmount = Random.Range(2, 11);
        Debug.Log(eggAmount);
        for (int i = 0; i < eggAmount; i++)
        {
            Debug.Log(i);
            Instantiate(egg, transform.position, Quaternion.identity);
            UIManager.GetComponent<UIManager>().eggCount++;
        }
        yield return new WaitForSeconds(10);
        Death();
        UIManager.GetComponent<UIManager>().henCount--;
    }

    //makes rooster DIE
    IEnumerator RoostersLifespan()
    {
        yield return new WaitForSeconds(40);
        Death();
        UIManager.GetComponent<UIManager>().roosterCount--;
    }

    //Dies
    void Death()
    {
        Destroy(gameObject);
    }
}
