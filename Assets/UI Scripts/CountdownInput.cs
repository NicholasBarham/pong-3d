using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownInput : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countdownText;

    private WaitForSeconds waitToHide = new WaitForSeconds(1f);

    private void Awake()
    {
        if (countdownText == null)
            countdownText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(int count)
    {
        if (count != 0)
            countdownText?.SetText(count.ToString());
        else
            countdownText?.SetText("GO!");
    }

    public void HideInput() => StartCoroutine(CountdownToHide());

    private IEnumerator CountdownToHide()
    {
        yield return waitToHide;
        gameObject.SetActive(false);
    }
}
