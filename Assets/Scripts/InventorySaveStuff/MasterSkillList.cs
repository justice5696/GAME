using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSkillList : MonoBehaviour
{

  public Dictionary<string, Skill> MasterSkillList;

    // Start is called before the first frame update
    void Start()
    {
      MasterSkillList = new Dictionary<string, Skill>()
          {
            {"Default",  new Skill("Default")},
            {"Skilly", new Skill("Default"))}
          };
    }

    public Skill getSkill(string name)
    {
      return MasterSkillList[name];
    }
}