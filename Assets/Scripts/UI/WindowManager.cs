using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Configs;
using CommonLogic;

namespace UI
{
    public class WindowManager : MonoBehaviour
    {
        [SerializeField] private Pair<State, State[]> _defaultState;
        [SerializeField] private Pair<State, State[]>[] _states;

        private Dictionary<string, GameObject> _windowPrefabs = new Dictionary<string, GameObject>();
        private Dictionary<string, GameObject> _createdWindows = new Dictionary<string, GameObject>();
        private Dictionary<string, List<string>> _stateTransitions = new Dictionary<string, List<string>>();
        private Stack<string> _stateHistory = new Stack<string>();

        public string CurrentStateName { get; private set; } = string.Empty;

        private void Awake()
        {
            _windowPrefabs = _states.ToDictionary(x => x.Key.StateName, x => x.Key.WindowPrefab);

            CurrentStateName = _defaultState.Key.StateName;
            _stateHistory.Push(CurrentStateName);
            _createdWindows.Add(CurrentStateName, Instantiate(_defaultState.Key.WindowPrefab));

            _windowPrefabs.Add(_defaultState.Key.StateName, _defaultState.Key.WindowPrefab);

            _stateTransitions = _states.ToDictionary(x => x.Key.StateName, x => x.Value.Select(y => y.StateName).ToList());
            _stateTransitions.Add(_defaultState.Key.StateName, _defaultState.Value.Select(y => y.StateName).ToList());
        }

        public void SetState(string stateName)
        {
            if(_windowPrefabs.ContainsKey(stateName) && _stateTransitions[CurrentStateName].Contains(stateName))
            {
                _createdWindows[CurrentStateName].SetActive(false);

                if (_createdWindows.ContainsKey(stateName))
                {
                    _stateHistory.Push(stateName);
                    _createdWindows[stateName].SetActive(true);
                }
                else
                {
                     _createdWindows.Add(stateName, Instantiate(_windowPrefabs[stateName]));
                    _stateHistory.Push(stateName);
                }

                CurrentStateName = stateName;
            }
        }

        public void ReturnToPreviousState()
        {
            if(_stateHistory.Count > 1)
            {
                _createdWindows[CurrentStateName].SetActive(false);
                _stateHistory.Pop();
                CurrentStateName = _stateHistory.Peek();
                _createdWindows[CurrentStateName].SetActive(true);
            }
        }
    }
}