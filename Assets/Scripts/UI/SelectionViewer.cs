using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionViewer : MonoBehaviour
{
    public Image yes;
    public Image no;
    public bool isAgreed;
    private void OnEnable() => SetSelection(true);
    private void Update()
    {
        if (isAgreed && Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetSelection(false);
        }
        if (!isAgreed && Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetSelection(true);
        }
    }
    private void SetSelection(bool _agree)
    {
        isAgreed = _agree;
        yes.color = isAgreed ? Color.green : Color.white;
        no.color = !isAgreed ? Color.green : Color.white;
    }
    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
}
