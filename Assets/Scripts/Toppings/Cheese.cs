using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : Topping
{
    public override string GetName()
    {
        return "Cheese";
    }
    
    public override GameObject GetSimplifiedMapping()
    {
        return Resources.Load<GameObject>("Prefabs/SimplifiedToppings/SimplifiedCheese");
    }
}