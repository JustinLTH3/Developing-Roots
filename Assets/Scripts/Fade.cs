using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] CanvasGroup image;
    public bool fade = false;
    private void Update()
    {
        if (!fade) return;
        image.alpha = Mathf.Clamp(image.alpha - Time.deltaTime, 0, 1);
        if (image.alpha == 0) Destroy(gameObject);
    }
}
