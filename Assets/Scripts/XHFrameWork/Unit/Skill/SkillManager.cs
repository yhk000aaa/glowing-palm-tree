using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SkillManager
{
    public Unit unit;
    
    // 当前技能列表
    ExtendList<Skill> _skills;
    ExtendList<Skill> _toAdds;

    public SkillManager()
    {
        this._skills = new ExtendList<Skill>();
        this._toAdds = new ExtendList<Skill>();
    }

    public void start()
    {
        
    }

    public void stop()
    {
        this.removeAllSkills();
    }

    ///<remarks>- Update Skill -</remarks>
    public void update(float dt)
    {
        var skills = _skills.ToArray;

        bool exist = false;
        foreach (Skill skill in skills) {
            skill.update(dt);
            if (skill.isOver) {
                exist = true;
            }
        }
        
        if (exist) {
            foreach (var skill in this.getAllSkills()) {
                if (skill.isOver) {
                    this.removeSkill(skill);
                }
            }
        }
    }

    
    // 对目标释放一个新的技能
    public void addSkill(Skill skill)
    {
        if (this._skills.Contains(skill)) {
            return;
        }
        
        skill.startWithUnit(unit);
        this._skills.Add(skill);
    }
    
    /// <remarks>- Remove Skill -</remarks>
    // 移除指定技能
    void removeSkill(Skill skill)
    {
        skill.stop();
        this._skills.Remove(skill);
    }

    public void removeAllSkills()
    {
        foreach (Skill skill in this.getAllSkills()) {
            skill.stop();
        }
        _toAdds.Clear();
        _skills.Clear();
    }

    
    public void removeSkillByTag(string tag)
    {
        var ss = this.getAllSkillsByTag(tag);
        foreach (var skill in ss) {
            this.removeSkill(skill);
        }
    }
    
    public IEnumerable<Skill> getAllSkills()
    {
        if (_skills == null) {
            yield break;
        }

        Skill[] ss = _skills.ToArray;
        foreach (Skill skill in ss) {
            yield return skill;
        }
    }
    
    public IEnumerable<Skill> getAllSkillsByTag(string tag)
    {
        if (_skills == null) {
            yield break;
        }

        Skill[] ss = _skills.ToArray;
        foreach (Skill skill in ss) {
            if (skill.tag != tag) {
                continue;
            }
            yield return skill;
        }
    }
}
