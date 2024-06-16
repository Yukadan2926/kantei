using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SuggestItem : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI text;

    public void Search()
    {
        inputField.text = text.text;
    }
}
