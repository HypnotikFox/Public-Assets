using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public static class CustomExtensions
{
    // Convert Color to Hexadecimal
    public static string ColorToHex(Color color)
    {
        // Convert each color component to a 0-255 integer and format to 2 hexadecimal characters
        int r = Mathf.RoundToInt(color.r * 255);
        int g = Mathf.RoundToInt(color.g * 255);
        int b = Mathf.RoundToInt(color.b * 255);
        int a = Mathf.RoundToInt(color.a * 255);

        // Format as a hexadecimal string
        if (a < 255) // Include alpha if it's not fully opaque
        {
            return $"#{r:X2}{g:X2}{b:X2}{a:X2}";
        }
        else // Exclude alpha if it's fully opaque
        {
            return $"#{r:X2}{g:X2}{b:X2}";
        }
    }

    public static string RandomizeCapitalization(string input)
    {
        System.Text.StringBuilder result = new System.Text.StringBuilder();
        System.Random random = new System.Random();

        foreach (char c in input)
        {
            // Check if the character is a letter
            if (char.IsLetter(c))
            {
                // Randomly decide to uppercase or lowercase
                if (random.Next(0, 2) == 0) // 50% chance
                {
                    result.Append(char.ToUpper(c));
                }
                else
                {
                    result.Append(char.ToLower(c));
                }
            }
            else
            {
                // Non-letters remain unchanged
                result.Append(c);
            }
        }

        return result.ToString();
    }

    // Helper method to check if a GameObject is in a specific LayerMask.
    public static bool IsInLayerMask(GameObject obj, LayerMask layerMask)
    {
        return (layerMask.value & (1 << obj.layer)) > 0;
    }

    public static bool ShowImageInCaseOfNull(Image image, Sprite sprite)
    {
        if (sprite != null)
        {
            image.sprite = sprite;
            return true;
        }
        else
        {
            image.enabled = false;
            return false;
        }
    }
    public static void RandomizeList<T>(List<T> list)
    {
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            (list[i], list[randomIndex]) = (list[randomIndex], list[i]); // Swap elements
        }
    }
}
