using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : GenericSingletonClass<GlobalVariables>
{
    public Vector3 worldCenter = Vector3.zero;
    
    public float gravityForce = -10f;
    public MissileController currentBeacon;
}
