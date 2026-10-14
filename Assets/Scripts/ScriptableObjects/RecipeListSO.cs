using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu()]
public class RecipeListSO : ScriptableObject
{
    public List<RecipeSO> recipeSOList;

    public static implicit operator RecipeListSO(RecipeSO v)
    {
        throw new NotImplementedException();
    }
}
