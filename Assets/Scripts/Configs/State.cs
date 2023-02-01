using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "State", menuName = "Configs/State", order = 1)]
    public class State : ScriptableObject
    {
        [SerializeField] private string _stateName;
        [SerializeField] private GameObject _windowPrefab;

        public string StateName => _stateName;
        public GameObject WindowPrefab => _windowPrefab;
    }
}