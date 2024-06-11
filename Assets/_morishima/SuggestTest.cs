using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SuggestTest : MonoBehaviour
{
    string currentText = "";
    public TMP_InputField inputField;

    public string[] hikaku={"あにめ","まんが","あっぷる"};
    //サジェスト候補のパネルのprefab
    public GameObject suggestPanel;

    //ボタンを追加する親オブジェクト
    public GameObject parentObject;
    //サジェスト候補管理クラス的なの作る

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if(Input.GetKeyDown(KeyCode.Return))
    {
    //    GameObject buf = Instantiate(suggestPanel);
    //      buf.transform.SetParent(parentObject.transform,false);
       // GameObject gameObject = new GameObject();
       // gameObject.AddComponent<TMP_Text>();
    }
        //if()
        int i = 0;
        int[] j = {-1,-1,-1};
        if(currentText != inputField.text)
        {
            foreach (Transform n in parentObject.transform)
            {
                Destroy(n.gameObject);
            }
        
            if(inputField.text != "")
            {
                foreach (string s in hikaku)
                {
                    //サジェスト候補として検索する数だけ繰り返す
                    if (s.StartsWith(inputField.text))
                    {
                    // Debug.Log(s);
                        j[i] = i;
                    }
                        i++;
                }
                foreach (int index in j)
                {
                    if(index != -1)
                    {
                        GameObject buf = Instantiate(suggestPanel);
                        buf.transform.SetParent(parentObject.transform,false);
                        GameObject child = buf.transform.Find("Button").gameObject;
                        child.GetComponent<TMP_Text>().text = hikaku[index];
                        child.name = "Button_ " +hikaku[index];
                    Debug.Log(index);
                    }

                }
            }
        }
      // Debug.Log(i);
      currentText = inputField.text;
    }
}
