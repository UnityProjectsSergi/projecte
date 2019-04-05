using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;
public class ProvesScrpt : MonoBehaviour
{
    InputAction inputAction;
    public float movimentSpeed;
    private bool isMoving;

    //private float VerticalOldInput
    //{
    // //   get { return Input.GetAxis("P1VerticalPS"); }
    //}
    //private float HorizontalOldInput
    //{
    // //   get { return Input.GetAxis("P1HorizontalPS"); }
    //}
    //private float Vertical
    //{
    //    get
    //    {
    //        var keyborad = Keyboard.current;
    //        var vertical = 0;
    //        if (keyborad.wKey.isPressed)
    //            vertical = 1;
    //        else if (keyborad.sKey.isPressed)

    //            vertical = -1;

    //        return vertical;
    //    }
    //}
    //public float Horizontal
    //{
    //     get
    //    {
    //        var keyborad = Keyboard.current;
    //        float horintal = 0;
    //        if (keyborad.dKey.isPressed)
    //            horintal = 1;
    //        else if (keyborad.aKey.isPressed)

    //            horintal = -1;

    //        return horintal;
    //    }
    //    //get { return Input.GetAxis("Horizontal"); }
    //}

    public Quaternion Rotation { get; private set; }

   // public Vector3 Direcction = new Vector3(Horizontal,,);

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        foreach (string  item in Input.GetJoystickNames())
        {
            Debug.Log(item);
        }
       // Debug.Log(VerticalOldInput);
        if(
        Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("sss");
        }
    }
    private void FixedUpdate()
    {
        //if (!isMoving) return;
        //{
        //   // transform.position += Direcction * movimentSpeed * Time.deltaTime;
        //    transform.rotation = Rotation;
        //}
    }
  //  private bool isMobing = (Direcction != Vector3.zero);
 

}
