using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacon : Topping
{
    public override string GetName()
    {
        return "Bacon";
    }
    
    public override GameObject GetSimplifiedMapping()
    {
        return Resources.Load<GameObject>("Prefabs/SimplifiedToppings/SimplifiedBacon");
    }
}