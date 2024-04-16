using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basil : Topping
{
    public override string GetName()
    {
        return "Basil";
    }
    
    public override GameObject GetSimplifiedMapping()
    {
        return Resources.Load<GameObject>("Prefabs/SimplifiedToppings/SimplifiedBasil");
    }
}