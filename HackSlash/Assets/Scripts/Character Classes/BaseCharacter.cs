using UnityEngine;
using System.Collections;
using System; //added to access the enum class

public class BaseCharacter : MonoBehaviour {
	private string _name;
	private int _level;
	private uint _freeExp;

	private Attribute[] _primareAttribute;
	private Skill[] _skill;
	private Vital[] _vital;

	public void Awake() {
		_name = string.Empty;
		_level = 0;
		_freeExp = 0;

		_primareAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
		_skill = new Skill[Enum.GetValues(typeof(Skill)).Length];
		_vital = new Vital[Enum.GetValues(typeof(Vital)).Length];
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string Name {
		get{ return _name;}
		set{ _name = value;}
	}
	public int Level {
		get{ return _level;}
		set{ _level = value;}
	}

	public uint FreeExp {
		get{ return _freeExp;}
		set{ _freeExp = value;}
	}

	public void AddExp(uint exp) {
		_freeExp += exp;
		CalculateLevel();
	}
	//take the average of all players skills and assign that as the player level
	public void CalculateLevel() {}

	private void SetupPrimaryAttributes() {
		for(int cnt = 0; cnt < _primareAttribute.Length; cnt++) {
			_primareAttribute[cnt] = new Attribute();
		}
	}

	private void SetupVitals() {
		for(int cnt = 0; cnt < _vital.Length; cnt++) {
			_vital[cnt] = new Vital();
		}
	}

	private void SetupSkills() {
		for(int cnt = 0; cnt < _skill.Length; cnt++) {
			_skill[cnt] = new Skill();
		}
	}

	public Attribute GetPrimaryAttribute(int index) {
		return _primareAttribute[index];
	}

	public Vital GetVital(int index) {
		return _vital[index];
	}

	public Skill GetSkill(int index) {
		return _skill[index];
	}

	private void SetupVitalModifiers() {
		//health
		GetVital((int)VitalName.Health).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), .5f));
		//energy
		GetVital((int)VitalName.Energy).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), 1.0f));
		//mana
		GetVital((int)VitalName.Mana).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), 1.0f));
	}

	private void SetupSkillModifiers() {
		//melee offence
		GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Might), .33f));
		GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Nimbleness), .33f));
		//melee defense
		GetSkill((int)SkillName.Melee_Melee_defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
		GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), .33f));
		//magic offense
		GetSkill((int)SkillName.Melee_Magic_offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
		GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), .33f));
		//magic defense
		GetSkill((int)SkillName.Melee_Magic_offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
		GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), .33f));
		//ranged offense
		GetSkill((int)SkillName.Melee_Magic_offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
		GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
		//ranged defense
		GetSkill((int)SkillName.Melee_Magic_offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
		GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Nimbleness), .33f));
	}

//	private void 

	
}





























