using System.Collections.Generic;
using UnityEngine;

public class Combiner : MonoBehaviour
{
    public List<Recipe> Recipes;

    private Inventory Inventory;

    void Awake() => Inventory = FindObjectOfType<Inventory>();

    public void Combine(GameObject componentA, GameObject componentB)
    {
        var recipe = FindRecipe(componentA, componentB);

        if (recipe != null)
        {
            if (recipe.Result != null)
            {
                if (recipe.ShouldMoveResultPostition)
                {
                    recipe.Result.transform.position = componentA.transform.position;
                }

                recipe.Result.SetActive(true);
            }

            recipe.OnCombination.Invoke();

            Inventory?.Remove(componentA);
            Inventory?.Remove(componentB);

            Destroy(componentA);
            Destroy(componentB);
        }
    }

    private Recipe FindRecipe(GameObject ingredientA, GameObject ingredientB) =>
        Recipes.Find(recipe => recipe.ComponentA == ingredientA && recipe.ComponentB == ingredientB || recipe.ComponentB == ingredientA && recipe.ComponentA == ingredientB);
}
