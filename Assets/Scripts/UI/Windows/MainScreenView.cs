using UnityEngine;
using UnityEngine.UI;
using UI.Buttons;

namespace UI.Windows {
    public class MainScreenView : MonoBehaviour
    {
        [SerializeField] private Button _goToGameplayButton;
        [SerializeField] private Button _goToPlayerProfileButton;
        [SerializeField] private Button _goToSettingsButton;

        public SimpleButton GoToGameplaySimpleButton { get; private set; }
        public SimpleButton GoToPlayerProfileSimpleButton { get; private set; }
        public SimpleButton GoToSettingsSimpleButton { get; private set; }

        private WindowManager _windowManager;

        private void Awake()
        {
            GoToGameplaySimpleButton = new SimpleButton(_goToGameplayButton);
            GoToPlayerProfileSimpleButton = new SimpleButton(_goToPlayerProfileButton);
            GoToSettingsSimpleButton = new SimpleButton(_goToSettingsButton);

            GoToGameplaySimpleButton.Subscribe(GoToGameplay);
            GoToPlayerProfileSimpleButton.Subscribe(GoToPlayerProfile);
            GoToSettingsSimpleButton.Subscribe(GoToSettings);

            _windowManager = FindObjectOfType<WindowManager>();
        }

        private void GoToGameplay()
        {
            _windowManager.SetState("Gameplay");
        }

        private void GoToPlayerProfile()
        {
            _windowManager.SetState("PlayerProfile");
        }

        private void GoToSettings()
        {
            _windowManager.SetState("Settings");
        }
    }
}