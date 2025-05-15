using UnityEngine;

public static class Extension
{
    public static void ToggleActive(this GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
