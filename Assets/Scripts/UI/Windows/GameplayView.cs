using UI.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class GameplayView : MonoBehaviour
    {
        [SerializeField] private Button _goToSettingsButton;
        [SerializeField] private Button _goToMainScreenButton;

        public SimpleButton GoToSettingsSimpleButton { get; private set; }
        public SimpleButton GoToMainScreenSimpleButton { get; private set; }

        private WindowManager _windowManager;

        private void Awake()
        {
            GoToSettingsSimpleButton = new SimpleButton(_goToSettingsButton);
            GoToMainScreenSimpleButton = new SimpleButton(_goToMainScreenButton);

            GoToSettingsSimpleButton.Subscribe(GoToSettings);
            GoToMainScreenSimpleButton.Subscribe(GoToMainScreen);

            _windowManager = FindObjectOfType<WindowManager>();
        }

        private void GoToSettings()
        {
            _windowManager.SetState("Settings");
        }

        private void GoToMainScreen()
        {
            _windowManager.SetState("MainScreen");
        }
    }
}