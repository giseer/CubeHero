using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Player player;

    [Header("Life")] 
    [SerializeField] private GameObject heartsContainer;
    [SerializeField] private GameObject heartPrefab;

    [Header("Exp")] 
    [SerializeField] private Image expFillContainer;
    

    private void Update()
    {
        StartCoroutine(HudUpdate());
    }

    private IEnumerator HudUpdate()
    {
        LifeHudUpdate();
        StartCoroutine(ExpHudUpdate(1.0f));
        yield return null;
    }

    private void LifeHudUpdate()
    {
        var containerTransform = heartsContainer.transform;
        
        if (containerTransform.childCount > player.Hearts)
        {
            Destroy(containerTransform.GetChild(containerTransform.childCount -1).gameObject);
        }
        if (containerTransform.childCount < player.Hearts)
        {
            Instantiate(heartPrefab, containerTransform);
        }
    }

    private IEnumerator ExpHudUpdate(float expNormalized)
    {
        float currentScale = expFillContainer.transform.localScale.y;
        float updateQuantity = currentScale + expNormalized;
        while (expNormalized - currentScale > Mathf.Epsilon)
        {
            currentScale -= updateQuantity * Time.deltaTime;
            expFillContainer.transform.localScale = new Vector3(1, currentScale);
        }
        
        yield return null;
    }
}
