using UI.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class SettingsView : MonoBehaviour
    {
        [SerializeField] private Button _goToGameplayButton;
        [SerializeField] private Button _goToPlayerProfileButton;
        [SerializeField] private Button _goToMainScreenButton;

        public SimpleButton GoToGameplaySimpleButton { get; private set; }
        public SimpleButton GoToPlayerProfileSimpleButton { get; private set; }
        public SimpleButton GoToMainScreenSimpleButton { get; private set; }

        private WindowManager _windowManager;

        private void Awake()
        {
            GoToGameplaySimpleButton = new SimpleButton(_goToGameplayButton);
            GoToPlayerProfileSimpleButton = new SimpleButton(_goToPlayerProfileButton);
            GoToMainScreenSimpleButton = new SimpleButton(_goToMainScreenButton);

            GoToGameplaySimpleButton.Subscribe(GoToGameplay);
            GoToPlayerProfileSimpleButton.Subscribe(GoToPlayerProfile);
            GoToMainScreenSimpleButton.Subscribe(GoToMainScreen);

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

        private void GoToMainScreen()
        {
            _windowManager.SetState("MainScreen");
        }
    }
}