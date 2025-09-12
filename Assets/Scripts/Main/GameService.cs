using GodsCarrom.Abilites;
using GodsCarrom.Board;
using GodsCarrom.CarromMan;
using GodsCarrom.Events;
using GodsCarrom.Gameplay;
using GodsCarrom.Hole;
using GodsCarrom.Player;
using GodsCarrom.UI;
using GodsCarrom.Utilities;
using UnityEngine;

namespace GodsCarrom.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        //prefabs
        [SerializeField] private BoardController board;
        [SerializeField] private CarromManView carromManPrefab;
        [SerializeField] private HoleView holePrefab;

        //ScriptableObjects
        [SerializeField] private GameplayScriptableObject gameplayScriptableObject;
        [SerializeField] private BoardScriptableObject boardSO;
        [SerializeField] private PlayerScriptableObject player1SO;
        [SerializeField] private PlayerScriptableObject player2SO;

        //Services
        public GameplayService GameplayService { get; private set; }
        public BoardService BoardService { get; private set; }
        public PlayerService PlayerService { get; private set; }
        public EventService EventService { get; private set; }
        public AbilityService AbilityService { get; private set; }

        [SerializeField] private UIService uiService;
        public UIService UIService => uiService;

        public Manager gameManager;

        protected override void Awake()
        {
            base.Awake();

            EventService = new EventService();
            GameplayService = new GameplayService(gameplayScriptableObject);
            BoardService = new BoardService(board, holePrefab, gameplayScriptableObject.holeData);
            PlayerService = new PlayerService(player1SO, player2SO, carromManPrefab);
            AbilityService = new AbilityService();
        }

        private void Start()
        {
            UIService.ShowGodSelectionUI();
        }

        public void TurnOnManager()
        {
            gameManager.gameObject.SetActive(true);
        }
    }
}