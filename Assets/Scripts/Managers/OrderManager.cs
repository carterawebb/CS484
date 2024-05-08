using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class OrderManager : MonoBehaviour{
    private Topping[] yourToppings;
    private Topping[] targetToppings;

    [SerializeField] public PizzaManager pizzaManager;

    [SerializeField] public GameObject finishPizzaMenu;
    [SerializeField] public GameObject endGameMenu;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public TextMeshProUGUI messageText;

    public int score;

    public void Awake() {
        finishPizzaMenu.SetActive(true);
        endGameMenu.SetActive(false);
    }

    public void EvaluatePizza() {
        if (pizzaManager.pizza.toppings.Count <= 1) {
            StartCoroutine(ShowMessage("You need to add toppings to the pizza!"));
            return;
        }

        if (pizzaManager.targetPizza.ready)
        {
            // Convert the list of toppings to an array
            yourToppings = pizzaManager.pizza.toppings.ToArray();
            targetToppings = pizzaManager.targetPizza.toppings.ToArray();

            score = 100;
            int numWrong = yourToppings.Length;
            if (yourToppings.Length == targetToppings.Length)
            {
                // given 50 points for getting the correct number of ingredients
                score += 50;
            }

            for (int i = 0; i < targetToppings.Length; i++)
            {
                bool found = false;
                for (int j = 0; j < yourToppings.Length; j++)
                {
                    if (targetToppings[i].GetName() == yourToppings[j].GetName())
                    {
                        found = true;
                    }
                }
                if (!found)
                {
                    // you lose 10 for each ingredient you added that wasn't in the pizza
                    score -= 10;
                }
            }

            List<int> skipIndecies = new List<int>();
            for (int i = 0; i < yourToppings.Length; i++)
            {
                bool found = false;
                for (int j = 0; j < targetToppings.Length; j++)
                {
                    if (skipIndecies.Contains(j))
                    {
                        continue;
                    }

                    if (yourToppings[i].GetName() == targetToppings[j].GetName())
                    {
                        found = true;
                        skipIndecies.Add(j);
                    }
                }
                if (!found)
                {
                    // you lose 10 for each ingredient in the pizza you didn't add
                    score -= 10;
                }
            }

            // you get 10 points for every ingredient in the correct position
            for (int i = 0; i < Math.Min(targetToppings.Length, yourToppings.Length); i++)
            {
                if (yourToppings[i].GetName() == targetToppings[i].GetName())
                {
                    score += 10;
                }
            }

            if (score < 0)
            {
                score = 0;
            }

            finishPizzaMenu.SetActive(false);
            endGameMenu.SetActive(true);

            scoreText.text = "Score: " + score;
        }
    }

    public IEnumerator ShowMessage(string message) {
        messageText.text = message;
        yield return new WaitForSeconds(2);
        messageText.text = "";
    }

    public void ResetPizza() {
        finishPizzaMenu.SetActive(true);
        endGameMenu.SetActive(false);
        pizzaManager.NewPizza();
    }
}
