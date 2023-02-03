using UnityEngine;
using UnityEditor;
using System.IO;

public class CSVToSO
{
    private static string CSVItems = "/Editor/CSV/ItemsTabelle.csv"; //Table
    private static string resourcePath = "Ingredients/";  //ResourcesForSprite

    [MenuItem("Utilities/GenerateItems")]
    public static void GenerateSO()
    {
        Debug.Log("Generate Items");
        string[] allLines = File.ReadAllLines(Application.dataPath + CSVItems);

        foreach (string s in allLines)
        {
            string[] splitData = s.Split(',');//Can occasionally be ; so pls check csv b4 parsing

            //SO_Item _createdItem = ScriptableObject.CreateInstance<SO_Item>();
            //_createdItem.itemName = splitData[0];
            //_createdItem.health = int.Parse(splitData[1]);
            //_createdItem.mana = int.Parse(splitData[2]);
            //_createdItem.power = int.Parse(splitData[3]);

            //_createdItem.BuyPrice = int.Parse(splitData[4]);
            //_createdItem.ingredientDescription = splitData[6];


            //var testerSprite = Resources.Load<Sprite>(resourcePath + _createdItem.ingredientName);
            //if (testerSprite != null)
            //{
            //    _createdItem.ingredientSprite = testerSprite;
            //}
            //else
            //{
            //    Debug.Log("no Sprite found at: " + resourcePath + _createdItem.ingredientName);
            //}

            ////Knowledge of unity of all data //Path has alrdy to be exist
            //AssetDatabase.CreateAsset(_createdItem, $"Assets/MyProject/Scriptables/Resources/CookingIngredients/{_createdItem.ingredientName}.asset");
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
