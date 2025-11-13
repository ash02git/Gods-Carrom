using GodsCarrom.Abilites;
using GodsCarrom.Board;
using GodsCarrom.CarromMan;
using GodsCarrom.Events;
using GodsCarrom.GameCamera;
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
        [SerializeField] private GameObject viewObstructor;

        //ScriptableObjects
        [SerializeField] private GameplayScriptableObject gameplayScriptableObject;
        [SerializeField] private BoardScriptableObject boardSO;

        public BoardService BoardService { get; private set; }
        public PlayerService PlayerService { get; private set; }
        public EventService EventService { get; private set; }
        public AbilityService AbilityService { get; private set; }

        [SerializeField] private UIService uiService;
        public UIService UIService => uiService;

        //Services
        [SerializeField] private GameplayServiceNew gameplayService;
        public GameplayServiceNew GameplayService => gameplayService;

        [SerializeField] private CameraService cameraService;
        public CameraService CameraService => cameraService;
 
        protected override void Awake()
        {
            base.Awake();

            EventService = new EventService(); 
            BoardService = new BoardService(board, holePrefab, gameplayScriptableObject.holeData, viewObstructor);
            PlayerService = new PlayerService(carromManPrefab);
            AbilityService = new AbilityService();
        }

        private void Start()
        {
            UIService.ShowGodSelectionUI();
        }

        //public void TurnOnManager()
        //{
        //    //gameManager.gameObject.SetActive(true);
        //}
    }
}