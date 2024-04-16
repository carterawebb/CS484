using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dough : Topping
{
    public override string GetName()
    {
        return "Dough";
    }
    
    public override GameObject GetSimplifiedMapping()
    {
        return Resources.Load<GameObject>("Prefabs/SimplifiedToppings/SimplifiedDough");
    }
}