using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOffset : MonoBehaviour
{
    [SerializeField] private string cycleOffset = "Cycle Offset";
    [SerializeField] [Range(0f, 1f)] private float maxOffset = 1f;

    [Space(20f)]
    [SerializeField] private string speedMultiplier = "Speed Multiplier";
    [SerializeField] private Vector2 speedMultiplierRange = new Vector2(0.8f, 1.2f);

    private void Awake()
    {
        if (!TryGetComponent(out Animator animator))
        {
            Debug.LogError($"{gameObject.name} doesn't has animator component so can't randomize the offset");
            return;
        }

        float randomCycleOffset = Random.Range(0f, maxOffset);
        //Debug.Log("random animation offset" + randomValue);

        animator.SetFloat(cycleOffset, randomCycleOffset);

        float randomSpeedMultiplierRange = Random.Range(speedMultiplierRange.x, speedMultiplierRange.y);
        animator.SetFloat(speedMultiplier, randomSpeedMultiplierRange);
    }
}
