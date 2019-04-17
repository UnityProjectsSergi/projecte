using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ItemPot : Item
{
    public int numIng=3;
    public List<Item> listItem;

    public Image ProgressBar;
    public GameObject ListIng;
    private float fillAmount = 0;
    public float timerToAction;
    private float progresSpeed;
    public GameObject ItemPotUIPrefab;
    public List<GameObject> listuI;
    public float totalduration = 0;
    public bool IsStartCooking;
    public void Start()
    {
        listItem = new List<Item>();
        listuI = new List<GameObject>();
        for (int i = 0; i < numIng; i++)
        {
            GameObject ingPot = Instantiate(ItemPotUIPrefab);
            listuI.Add(ingPot);
            ingPot.transform.SetParent(ListIng.transform);
        }
        itemType = ItemType.Pot;
    }
  public int num=0;
    public void LeaveObjIn(Item item)
    {
        StartCoroutine(Cooking(totalduration));
        listItem.Add(item);
        totalduration += item.duration;
        listuI[num].GetComponent<Image>().material = item.GetComponent<Renderer>().material;
        num++;
    }
    public void ResetPot()
    {
        num = 0;
        IsStartCooking = false;
        listItem.Clear();
    }
    public bool CheckIsCookedIng()
    {
        return true;
    }
    public void Update()
    {
        if (listItem.Count == 1)
        {
            
        }
    }
    IEnumerator Cooking(float duration)
    {
        float startTime = Time.realtimeSinceStartup;
        float journey = 0f;
        while (journey <= duration)
        {
            journey += Time.deltaTime;
            float percent = Mathf.Clamp01(journey / duration);

            ProgressBar.fillAmount = Mathf.Lerp(0, 1.0f, percent);

            yield return null;

        }
    }
}

