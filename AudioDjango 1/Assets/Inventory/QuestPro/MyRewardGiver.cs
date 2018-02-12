using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Devdog.QuestSystemPro;
using Devdog.QuestSystemPro.UI;
using System;

public class MyRewardGiver : INamedRewardGiver
{
    [SerializeField]
    private string _name;
    public string name
    {
        get
        {
            return _name;
        }
    }

    public RewardRowUI rewardUIPrefab {
        get {
            return QuestManager.instance.settingsDatabase.defaultRewardRowUI;
        }
    }

    public ConditionInfo CanGiveRewards(Quest quest)
    {
        return ConditionInfo.success;
    }

    public void GiveRewards(Quest quest)
    {
        Debug.Log("Give Reward");
    }

    public override string ToString()
    {
        return "Debug Log message.";
    }
}
