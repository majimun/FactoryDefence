using UnityEngine;
using System.Collections;

public struct CharaProfile {
	public string name;
	public string tag;
}

public class BaseCharacter : MonoBehaviour {

	public const int BASE_STATUS_ARRAY_MAX = 7;
	public const int STATUS_ARRAY_MAX = 9;

	public enum BaseStatusIndex {
		EXP_RATE = 0,
		HP_MAX,
		ATTACK,
		MOVE_SPEED,
		ATTACK_RANGE,
		SEARCH_RANGE,
		ENERGY_RATE
	};
	
	public enum StatusIndex {
		LEVEL = 0,
		EXP,
		HP_MAX,
		HP,
		ATTACK,
		MOVE_SPEED,
		ATTACK_RANGE,
		SEARCH_RANGE,
		ENERGY_RATE
	};

	public StateProfile StateProf { get; set; }
	public GameObject Target {get; set; }
	public bool SearchFlag { get; set; }
	public bool AttackFlag { get; set; }

	public CharaProfile CharaProf { 
		get{ return _prof; }
	}

	public CharacterStatusData Status {
		get { return _status; }
	}

	public const int ACTION_STATE_STAY   = 0;
	public const int ACTION_STATE_SEARCH = 1;
	public const int ACTION_STATE_LOOK   = 2;
	public const int ACTION_STATE_ATTACK = 3;
	public const int ACTION_STATE_BORN   = 4;
	public const int ACTION_STATE_DEATH  = 5;

	protected CharaProfile _prof;
	protected CharacterStatusData _status;
	protected GameObject _searchArea;
	protected GameObject _attackArea;
	protected GameObject _target;
	protected int _actionState;
	protected float[] _baseStatusArray;
	protected float[] _statusArray;

	public virtual void Setup () {}
	public virtual void EditStatus () {}


	public void CreateCharacter(float[] seed) {
		
		_statusArray = new float[STATUS_ARRAY_MAX];
		_baseStatusArray = seed;

		_statusArray = new float[STATUS_ARRAY_MAX];
		_statusArray [(int)StatusIndex.LEVEL] = 1;
		_statusArray [(int)StatusIndex.EXP] = 0;
		_statusArray [(int)StatusIndex.HP_MAX] = _baseStatusArray [(int)BaseStatusIndex.HP_MAX];
		_statusArray [(int)StatusIndex.HP] = _statusArray [(int)StatusIndex.HP_MAX];
		_statusArray [(int)StatusIndex.ATTACK] = _baseStatusArray [(int)BaseStatusIndex.ATTACK];
		_statusArray [(int)StatusIndex.MOVE_SPEED] = _baseStatusArray [(int)BaseStatusIndex.MOVE_SPEED];
		_statusArray [(int)StatusIndex.ATTACK_RANGE] = _baseStatusArray [(int)BaseStatusIndex.ATTACK_RANGE];
		_statusArray [(int)StatusIndex.SEARCH_RANGE] = _baseStatusArray [(int)BaseStatusIndex.SEARCH_RANGE];
		_statusArray [(int)StatusIndex.ENERGY_RATE] = _baseStatusArray [(int)BaseStatusIndex.ENERGY_RATE];


	}


	public void SetStatus(int index, float value) {
		_baseStatusArray [index] = value;
	}


	public float GetStatus(int index) {
		return _baseStatusArray[index];
	}
		

	public float[] GetStatusArray() {
		return _statusArray;
	}


	/// <summary>
	/// ダメージ計算を行います。
	/// </summary>
	/// <param name="damage">与ダメージ</param>
	public void OnDamage (int damage) {
		int hp = _status.Hp;

		// ダメージ量チェック
		if (damage <= 0) {
			damage = 0;
		}

		hp -= damage;	// ダメージ計算

		// HP残量チェック
		if (hp < 0) {
			hp = 0;
		}

		_status.Hp = hp;
	}


	/// <summary>
	/// 自オブジェクトの子を'タグ検索'。
	/// 検索結果のオブジェクトを返します。
	/// </summary>
	/// <returns>子オブジェクト</returns>
	/// <param name="tag">検索対象のタグ名</param>
	public Transform FindChildWithTag (string tag) {
		Transform child = null;

		for(int i = 0; i < transform.childCount; i++) {
			if(transform.GetChild(i).tag.Equals(tag)) {
				child = transform.GetChild(i);

				break;
			}
		}

		return child;
	}


	public void Attack (GameObject target) {
		if(target != null) {
			target.GetComponent<BaseCharacter>().OnDamage(_status.Attack);
		}
	}


	// 子ブジェクトのサーチ範囲Colliderイベント
	public virtual void SearchOnTriggerEnter (Collider other) {}
	public virtual void SearchOnTriggerStay (Collider other) {}
	public virtual void SearchOnTriggerExit (Collider other) {}

	// 子オブジェクトの攻撃開始範囲Colliderイベント
	public virtual void AttackOnTriggerEnter (Collider other) {}
	public virtual void AttackOnTriggerStay (Collider other) {}
	public virtual void AttackOnTriggerExit (Collider other) {}
}
