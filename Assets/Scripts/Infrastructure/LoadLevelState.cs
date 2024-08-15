using Scripts.CameraLogic;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class  LoadLevelState : IPayLoadedState<string>
    {
        private const string InitialPoint = "InitialPoint";
        private readonly GameStateMashine _gameStateMashine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMashine gameStateMashine, SceneLoader sceneLoader)
        {
            _gameStateMashine = gameStateMashine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName,OnLoaded);
        }

        public void Exit()
        {
            
        }

        private void OnLoaded()
        {
            GameObject initialPoint = GameObject.FindWithTag(InitialPoint);
            GameObject hero = Instantiate("Hero/Hero",initialPoint.transform.position);
            Instantiate("Screen/CanvasJoystick");

            CameraFollow(hero);
        }
        
        private static void CameraFollow(GameObject hero)
        {
            Camera.main.GetComponent<CameraFollow>().Follow(hero);
        }

        private static GameObject Instantiate(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
        private static GameObject Instantiate(string path,Vector3 point)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab,point,Quaternion.identity);
        }
    }
}