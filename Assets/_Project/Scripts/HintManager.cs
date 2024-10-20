using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    GameObject hint;
    [SerializeField] private GameObject hintPrefab;
    [SerializeField] private Transform hintTransform;

    public void OpenHint(string message)
    {
        if (hint == false)
        {
            hint = Instantiate(hintPrefab, hintTransform.position, Quaternion.identity);
            hint.transform.SetParent(hintTransform.parent);
            hint.GetComponent<TextMeshProUGUI>().text = message;
        }
    }

    public void CloseHint()
    {
        if (hint != null)
        {
            Destroy(hint);
            hint = null; 
        }
    }
}
