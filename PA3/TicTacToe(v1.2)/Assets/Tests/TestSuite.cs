using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestSuite
    {
        [UnityTest]
        public IEnumerator TestStartUp()
        {
            var game = new GameObject().AddComponent<GridManager>();

            game.line = MonoBehaviour.Instantiate(Resources.Load<GameObject>("line"));
            game.xButton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("x"));
            game.oButton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("o"));
            game.square = MonoBehaviour.Instantiate(Resources.Load<GameObject>("square"));
            game.border = MonoBehaviour.Instantiate(Resources.Load<GameObject>("border"));
            

            game.Start();

            Assert.Pass();

            GameObject.Destroy(game);

            yield return null;
        }

        [UnityTest]
        public IEnumerator TestIsX()
        {
            var game = new GameObject().AddComponent<GridManager>();
            var audioSrc = new GameObject().AddComponent<SoundManager>();

            game.line = MonoBehaviour.Instantiate(Resources.Load<GameObject>("line"));
            game.xButton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("x"));
            game.oButton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("o"));
            game.square = MonoBehaviour.Instantiate(Resources.Load<GameObject>("square"));
            game.border = MonoBehaviour.Instantiate(Resources.Load<GameObject>("border"));


            game.Start();

            Vector3 pos1 = new Vector3((float)-2.8, (float)2.8, 0);

            game.PlayerX(pos1, "0,2");

            int[,] testBoard = game.GetBoardState();

            Assert.AreEqual(1, testBoard[2, 0]);

            yield return null;
        }
    }
}
