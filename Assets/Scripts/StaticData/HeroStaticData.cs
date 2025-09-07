using UnityEngine;

namespace Scripts.StaticData
{
    [CreateAssetMenu(fileName = "HeroData", menuName = "StaticData/Hero")]
    public class HeroStaticData : ScriptableObject
    {
        [Range(1, 100)]
        public int Hp;
        [Range(1, 100)]
        public float Damage;
        [Range(0,100)]
        public float Armor;
        [Range(0.5f, 100)]
        public float PreparingAttack;
    }
}
