using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Topping : MonoBehaviour
{
    public abstract string GetName();
    public abstract GameObject GetSimplifiedMapping();
}
