using UnityEngine;
using System.Collections;
using System.Linq;

public class OrderDirector   : MonoBehaviour
{
    public float timeBewteenOrder;
    
    // Use this for initialization
    void Start()
    {
       // OrderManager.Instance.AddOrder(3,15);
    }

    private IEnumerator Timesr(float sec)
    {
        yield return new WaitForSeconds(timeBewteenOrder);
       // OrderManager.Instance.AddOrder(3, 15);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
