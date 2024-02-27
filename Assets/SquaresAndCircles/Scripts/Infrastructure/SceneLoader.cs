using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SquaresAndCircles.Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        private string _lastLoadedAdditiveScene = "";
        private string _curAdditiveScene = "";
        private Coroutine _loadAdditiveSceneCoroutine = null;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string name, Action onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
        }

        public void LoadAdditive(string name, Action onLoaded = null, Action onLoadingScreenExit = null)
        {
            if (_loadAdditiveSceneCoroutine != null) return;
            _loadAdditiveSceneCoroutine =
                _coroutineRunner.StartCoroutine(LoadAdditiveScene(name, onLoaded, onLoadingScreenExit));
        }

        public void LoadAdditiveSavingLast(string name, Action onLoaded = null)
        {
            _lastLoadedAdditiveScene = _curAdditiveScene;
            LoadAdditive(name, onLoaded);
        }

        private IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while (!waitNextScene.isDone)
                yield return null;

            onLoaded?.Invoke();
        }

        private IEnumerator LoadAdditiveScene(string nextScene, Action onLoaded = null,
            Action onLoadingScreenExit = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);

            waitNextScene.completed += delegate { AdditiveSceneLoadingComplete(nextScene, onLoaded); };

            while (!waitNextScene.isDone)
            {
                float progress = Mathf.Clamp01(waitNextScene.progress / 0.9f);
                yield return null;
            }
        }

        private void AdditiveSceneLoadingComplete(string nextScene, Action onLoaded)
        {
            _loadAdditiveSceneCoroutine = null;
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextScene));
            Unloading(nextScene);
            onLoaded?.Invoke();
        }


        private void Unloading(string nextScene)
        {
            if (_curAdditiveScene != "")
            {
                SceneManager.UnloadSceneAsync(_curAdditiveScene);
            }

            _curAdditiveScene = nextScene;
        }
    }
}