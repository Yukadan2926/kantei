using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public static class CreateRequestParamsFromCsv
{
    const string AssetPath = "Assets/Resources/";
    const string CsvPath = "Assets/Data/RequestData.csv";

    [MenuItem("ScriptableObjects/Create RequestParams")]
    static void ReadStageParam()
    {
        var reader = new StreamReader(CsvPath, Encoding.GetEncoding("UTF-8"));
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            string[] param = line.Split(',');

            //var asset = ScriptableObject.CreateInstance<RequestParam>();
            //string name = $"{AssetPath}Data.asset";
            //AssetDatabase.CreateAsset(asset, name);
            //AssetDatabase.Refresh();
        }
    }
}
#endif
