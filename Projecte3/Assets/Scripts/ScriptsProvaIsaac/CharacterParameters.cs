﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.Serializable]
public class CharacterParameters
{
    public float initialVelocity = 0.0f;
    //this is our target velocity while accelerating
    public float finalVelocityForwards = 500.0f;

   
    //this is our current velocity
    public float currentVelocity = 0.0f;
   
    //this is the velocity we add each second while accelerating
    public float accelerationRate = 10.0f;
    //this is the velocity we subtract each second while decelerating
    public float decelerationRate = 50.0f;

    
    public float rotationSpeed = 50f;
    // Use this for initialization
}