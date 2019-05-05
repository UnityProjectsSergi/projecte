using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public  class Hability : MonoBehaviour
{
    public bool habilityHabailable=true, usingHability;

    public string hability;
    public float _duration;
    public float _coolDown;
    public delegate void performHability();
    public delegate void CancelHability();
    CancelHability cancel;
    public Image imageCooldown;
    
    performHability f;
    public void set(float duration,float cooldown,performHability n,CancelHability _cancel)
    {
        _duration = duration;
        _coolDown = cooldown;
        f += n;
        cancel += _cancel;
    }
    // Use this for initialization
    public  void SetHabilityAvalableFalse()
    {
        habilityHabailable = false;
    }
    public void Update()
    {
       // imageCooldown.fillAmount=
    }
    Coroutine stop;
    public  void UseHability()
    {
        if (!habilityHabailable)
        {
            usingHability = true;
            f.Invoke();
          stop=  StartCoroutine(Cooldown());
          
        }

    }
    public void StopHability()
    {
        if(!habilityHabailable && usingHability)
        {
            usingHability = false;
            cancel.Invoke();
            StopCoroutine(stop);
            
        }
    }
    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_duration);
        Debug.Log("2sss");
        StopHability();
        yield return new WaitForSeconds(_coolDown);
        habilityHabailable = true;
    }



  

}
