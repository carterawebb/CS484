using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ham : Topping
{
    public override string GetName()
    {
        return "Ham";
    }
    
    public override GameObject GetSimplifiedMapping()
    {
        return Resources.Load<GameObject>("Prefabs/SimplifiedToppings/SimplifiedHam");
    }
}