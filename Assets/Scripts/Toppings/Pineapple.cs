using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pineapple : Topping
{
    public override string GetName()
    {
        return "Pineapple";
    }
    
    public override GameObject GetSimplifiedMapping()
    {
        return Resources.Load<GameObject>("Prefabs/SimplifiedToppings/SimplifiedPineapple");
    }
}