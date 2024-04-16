using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sauce : Topping
{
    public override string GetName()
    {
        return "Sauce";
    }
    
    public override GameObject GetSimplifiedMapping()
    {
        return Resources.Load<GameObject>("Prefabs/SimplifiedToppings/SimplifiedSauce");
    }
}