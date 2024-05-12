using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum StageBit
{
    None,
    Day1_1 = 0b_0001,
    Day2_1 = 0b_0010,
    Day3_1 = 0b_0100,
    Day3_2 = 0b_1000,
}

public enum ActionBit
{
    None,
    FailedDay2_1 = 0b_0001,
}

public class StageSelector : MonoBehaviour
{
    public static StageBit AppearFlagTable = StageBit.None;
    public static StageBit ClearFlagTable = StageBit.None;
    public static ActionBit ActionFlagTable = ActionBit.None;

    public static RequestParam[] RequestList;

    private void Start()
    {

    }
}
