using UnityEngine;

public class ShaderTimeController : MonoBehaviourSingleton<ShaderTimeController>
{
    public Material targetMaterial; // Assign the material using your shader
    private float unscaledTime;

    private void Awake()
    {
        if (!MarkInstanceAsDontDestroyOnLoad(this))
        {
            return;
        }
    }

    void Update()
    {
        // Accumulate unscaled time
        unscaledTime += Time.unscaledDeltaTime;

        // Pass the unscaled time to the shader
        targetMaterial.SetFloat("_UnscaledTime", unscaledTime);
    }
}
