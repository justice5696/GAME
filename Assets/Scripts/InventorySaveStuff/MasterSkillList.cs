using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSkillList : MonoBehaviour
{

  public Dictionary<string, Skill> SkillList;

    // Start is called before the first frame update
    void Start()
    {
      SkillList = new Dictionary<string, Skill>()
          {
            {"Default",  new Skill("Default")},
            {"Skilly", new Skill("Default")}
          };
    }

    public Skill getSkill(string name)
    {
      return SkillList[name];
    }
}
