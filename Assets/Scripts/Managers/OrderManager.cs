using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderManager : MonoBehaviour{
    private Topping[] yourToppings;
    private Topping[] targetToppings;

    [SerializeField] public PizzaManager pizzaManager;

    [SerializeField] public GameObject finishPizzaMenu;
    [SerializeField] public GameObject endGameMenu;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public TextMeshProUGUI messageText;

    public int score = 100;

    public void Awake() {
        finishPizzaMenu.SetActive(true);
        endGameMenu.SetActive(false);
    }

    public void EvaluatePizza() {
        if (pizzaManager.pizza.toppings.Count <= 2) {
            StartCoroutine(ShowMessage("You need to add toppings to the pizza!"));
            return;
        }

        if (pizzaManager.targetPizza.ready && pizzaManager.pizza.toppings.Count > 2) {
            // Convert the list of toppings to an array
            yourToppings = pizzaManager.pizza.toppings.ToArray();
            targetToppings = pizzaManager.targetPizza.toppings.ToArray();

            // Check if the toppings are correct
            for (int i = 0; i < targetToppings.Length; i++) {
                if (yourToppings[i].GetName() != targetToppings[i].GetName()) {
                    score -= 10;
                }

                if (score <= 0) {
                    score = 0;
                    break;
                }
            }

            // Check if the number of toppings is correct
            if (yourToppings.Length != targetToppings.Length) {
                score -= 10;
            }

            // For each extra topping, subtract 5 points
            if (yourToppings.Length > targetToppings.Length) {
                score -= 5 * (yourToppings.Length - targetToppings.Length);
            }

            if (score <= 0) {
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
        score = 100;
        pizzaManager.NewPizza();
    }
}
