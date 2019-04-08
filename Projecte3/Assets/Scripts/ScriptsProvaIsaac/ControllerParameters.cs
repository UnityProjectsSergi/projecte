using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.Serializable]
public class ControllerParameters
{

    public float dashVelocityMultiplier = 3f;
   
    //this is our current velocity
    public float currentVelocity = 0f;
    public float normalVelocity = 5.0f;
   

    
    public float rotationSpeed = 50f;
    // Use this for initialization
}