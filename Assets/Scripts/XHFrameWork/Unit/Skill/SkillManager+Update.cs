using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SkillManager
{
    public void hurt(UnitHurtParameters parameters, Unit sourceUnit = null) 
    {
        foreach (var skill in this.getAllSkills()) {
            skill.hurt(parameters, sourceUnit);
        }
    }

    public void cure(float count) 
    {
        foreach (var skill in this.getAllSkills()) {
            skill.cure(count);
        }
    }
}