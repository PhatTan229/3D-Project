using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ProgessUI : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private float targetAmount;

    private float currentAmount;
    private UnityEvent onDone;
    // Start is called before the first frame update
    void Start()
    {
        fillImage.fillAmount = 0;
        gameObject.SetActive(false);
    }

   public void IncreaseProgess()
    {
        currentAmount += Time.deltaTime;
        fillImage.fillAmount = currentAmount / targetAmount;
        if(currentAmount >= targetAmount)
        {
            onDone.Invoke();
        }
    }
}
