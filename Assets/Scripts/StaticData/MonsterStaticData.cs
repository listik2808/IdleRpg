using UnityEngine;

namespace Scripts.StaticData
{
    [CreateAssetMenu(fileName ="MonsterData",menuName = "StaticData/Monster")]
    public class MonsterStaticData : ScriptableObject
    {
        public MonsterTypeId monsterTypeId;

        [Range(1,100)]
        public int Hp;
        [Range(1, 100)]
        public float Damage;
        [Range(1, 100)]
        public float RewardXp;
        [Range(1, 100)]
        public float PreparingAttack;
        [Range(1, 100)]
        public float ChanceAppear;

        public GameObject Prefab;
    }
}
