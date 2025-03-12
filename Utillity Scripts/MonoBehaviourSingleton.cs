using System;
using UnityEngine;

public class MonoBehaviourSingleton<T> : MonoBehaviour where T : Component
{
    public static Action<T> OnInstanceSetted;
    public static Action OnInstanceRemoved;

    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                // Try to find an existing instance in the scene
                _instance = FindAnyObjectByType<T>();
                OnInstanceSetted?.Invoke(_instance);

                if (_instance == null)
                {
                    // Avoid creating a new instance; instead, log a clear error and fail gracefully
                    //Debug.LogWarning($"{typeof(T)} instance was not found! Ensure it exists in the scene.");
                }
            }

            return _instance;
        }
    }

    // Use the global 'Instance' instead of the local '_instance'
    // as if it's null the global will try to find a object, the local would just return null
    public static bool HasInstance => Instance != null;

    public static void SetThisInstanceToNull()
    {
        OnInstanceRemoved?.Invoke();
        _instance = null;
    }

    public static void ManuallySetInstance(T newInstance)
    {
        _instance = newInstance;
        OnInstanceSetted?.Invoke(_instance);
    }

    public static bool CheckIfObjectIsTheInstance(T component)
    {
        return Instance != null && Instance == component;
    }

    public static bool MarkInstanceAsDontDestroyOnLoad(T component, bool canHaveMultipleInstances = false)
    {
        // This code assures there's only one game manager
        // So, we could just create fake instances of the game manager in other scenes
        // So we can use the public methods!
        if (!CheckIfObjectIsTheInstance(component))
        {
            if (!canHaveMultipleInstances)
            {
                // If not the instance destroy this
                //Debug.LogWarning("Destroyed game manager instance");
                Destroy(component.gameObject);
            }

            return false;
        }

        // Make gthe unity event thingz use the new load level game controller things

        component.transform.SetParent(null, true);
        DontDestroyOnLoad(component.gameObject);
        return true;
    }
}
