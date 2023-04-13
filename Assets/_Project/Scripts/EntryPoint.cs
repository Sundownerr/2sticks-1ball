using SDW.Input;
using SDW.SaveLoad;
using UnityEngine;

namespace Game
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private Camera _camera;
        [SerializeField] private CoroutineRunner _coroutineRunner;
        [SerializeField] private SaveTrigger _saveTrigger;
        [SerializeField] private PlayerMobileInput _playerMobileInput;
        [SerializeField] private MainMenuUI _mainMenuUI;
        [SerializeField] private PauseMenuUI _pauseMenuUI;
        [SerializeField] private GameplayUI _gameplayUI;
        [SerializeField] private BallSkinShopUI _ballSkinShopUI;
        [SerializeField] private Level _levelPrefab;
        [SerializeField] private GameObject _borderPrefab;
        [SerializeField] private BallSkin[] _ballSkins;

        private void Start()
        {
            var score = new Score();
            var highscore = new Highscore(score);
            var ballSkinChanger = new BallSkinChanger(_ballSkins);
            var ballRespawner = new BallRespawner(_coroutineRunner, _gameConfig.BallRespawnDelay);
            var playerMovementLimits = new PlayerMovementLimits(_camera, _gameConfig.PlayerMovementEdgeLimit);
            var ballMovementLimits = new BallMovementLimits(_camera, ballRespawner, _gameConfig.BallRespawnEdgeLimit);
            var levelInstance = new LevelInstance();
            var levelFactory = new LevelFactory(_levelPrefab);
            var borderFactory = new BorderFactory(_borderPrefab, _camera, _gameConfig.BorderEdgeOffset);

            var serializer = new JsonSerializer();
            var serializationContainer = new JsonSerializationContainer(serializer);

            var playerData = new PlayerData(_ballSkins[0].ID);
            var playerSave = new JsonSaveWrapper<PlayerData>("PlayerData", playerData);

            var saves = new IJsonSaveWrapper[] { playerSave, };
            var saver = new JsonPrefsSaver(serializationContainer, saves);
            var loader = new JsonPrefsLoader(serializationContainer, saves);

            _saveTrigger.Construct(saver);

            var gameStateMachine = new StateMachine();

            gameStateMachine.AddState(new LoadSavedData(gameStateMachine, loader, playerData, ballSkinChanger,
                highscore));
            gameStateMachine.AddState(new Start(gameStateMachine, _pauseMenuUI, _gameplayUI, _mainMenuUI,
                _ballSkinShopUI, _ballSkins));
            gameStateMachine.AddState(new MainMenu(gameStateMachine, _mainMenuUI, highscore, score, playerData));
            gameStateMachine.AddState(new BallSkinShop(gameStateMachine, _ballSkinShopUI, ballSkinChanger, playerData));
            gameStateMachine.AddState(new LoadLevel(gameStateMachine, levelFactory, levelInstance));
            gameStateMachine.AddState(new ConstructLevel(gameStateMachine, levelInstance, _playerMobileInput,
                playerMovementLimits, ballMovementLimits, ballRespawner, borderFactory, ballSkinChanger));
            gameStateMachine.AddState(new Gameplay(gameStateMachine, _gameplayUI, levelInstance, score, highscore,
                ballRespawner, playerData));
            gameStateMachine.AddState(new PauseMenu(gameStateMachine, _pauseMenuUI, highscore, score, playerData));
            gameStateMachine.AddState(new RestartLevel(gameStateMachine, levelInstance));
            gameStateMachine.AddState(new UnloadLevel(gameStateMachine, levelInstance));

            gameStateMachine.SetState<LoadSavedData>();
        }
    }
}