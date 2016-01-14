using UnityEngine;
using System.Collections;

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

	public bool SearchFlag { get; set; }
	public bool AttackFlag { get; set; }

	public const int ACTION_STATE_STAY   = 0;
	public const int ACTION_STATE_SEARCH = 1;
	public const int ACTION_STATE_LOOK   = 2;
	public const int ACTION_STATE_ATTACK = 3;
	public const int ACTION_STATE_BORN   = 4;
	public const int ACTION_STATE_DEATH  = 5;

	protected GameObject _searchArea;
	protected GameObject _attackArea;
	protected GameObject _target;
	protected int _actionState;
	protected float[] _baseStatusArray;
	protected float[] _statusArray;


	public virtual void InitStatus () {/*read status = {expRate, hpMax, attack, moveSpeed, attackRange, searchRange, energyRate, level*/}


	public void CreateCharacter(float[] seed) {
		_searchArea = transform.FindChild ("SearchArea").gameObject;
		_attackArea = transform.FindChild ("AttackArea").gameObject;
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

		_searchArea.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f) * _statusArray [(int)StatusIndex.SEARCH_RANGE];
		_attackArea.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f) * _statusArray [(int)StatusIndex.ATTACK_RANGE];
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
	/// Raises the damage event.
	/// </summary>
	/// <param name="damage">Damage.</param>
	public void OnDamage (float damage) {
		float hp = _statusArray [(int)StatusIndex.HP];

		if (damage <= 0) {
			damage = 0;
		}

		hp -= damage;

		if (hp < 0) {
			hp = 0;
		}

		_statusArray [(int)StatusIndex.HP] = hp;
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
