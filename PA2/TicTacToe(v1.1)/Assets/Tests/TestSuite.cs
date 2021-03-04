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
        public IEnumerator WinVertical()
        {
            var game = new GameObject().AddComponent<GridManager>();

            game.line = MonoBehaviour.Instantiate(Resources.Load<GameObject>("line"));
            game.xButton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("x"));
            game.oButton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("o"));
            game.square = MonoBehaviour.Instantiate(Resources.Load<GameObject>("square"));

            game.Start();

            Vector3 pos1 = new Vector3((float)-2.8, (float)2.8, 0);
            Vector3 pos2 = new Vector3((float)-2.8, 0, 0);
            Vector3 pos3 = new Vector3((float)-2.8, (float)-2.8, 0);

            game.PlayerX(pos1, "0,0");
            game.PlayerX(pos2, "0,1");
            game.PlayerX(pos3, "0,2");

            Assert.IsTrue(game.CheckBoardState());

            yield return null;
        }

        [UnityTest]
        public IEnumerator WinHorizontal()
        {
            var game = new GameObject().AddComponent<GridManager>();

            game.line = MonoBehaviour.Instantiate(Resources.Load<GameObject>("line"));
            game.xButton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("x"));
            game.oButton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("o"));
            game.square = MonoBehaviour.Instantiate(Resources.Load<GameObject>("square"));

            game.Start();

            Vector3 pos1 = new Vector3((float)-2.8, (float)2.8, 0);
            Vector3 pos2 = new Vector3(0, (float)2.8, 0);
            Vector3 pos3 = new Vector3((float)2.8, (float)2.8, 0);

            game.PlayerX(pos1, "0,0");
            game.PlayerX(pos2, "1,0");
            game.PlayerX(pos3, "2,0");

            Assert.IsTrue(game.CheckBoardState());

            yield return null;
        }

        [UnityTest]
        public IEnumerator WinDiagonal()
        {
            var game = new GameObject().AddComponent<GridManager>();

            game.line = MonoBehaviour.Instantiate(Resources.Load<GameObject>("line"));
            game.xButton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("x"));
            game.oButton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("o"));
            game.square = MonoBehaviour.Instantiate(Resources.Load<GameObject>("square"));

            game.Start();

            Vector3 pos1 = new Vector3((float)-2.8, (float)2.8, 0);
            Vector3 pos2 = new Vector3(0, 0, 0);
            Vector3 pos3 = new Vector3((float)2.8, (float)-2.8, 0);

            game.PlayerX(pos1, "0,0");
            game.PlayerX(pos2, "1,1");
            game.PlayerX(pos3, "2,2");

            Assert.IsTrue(game.CheckBoardState());

            yield return null;
        }

        [UnityTest]
        public IEnumerator WinReverseDiagonal()
        {
            var game = new GameObject().AddComponent<GridManager>();

            game.line = MonoBehaviour.Instantiate(Resources.Load<GameObject>("line"));
            game.xButton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("x"));
            game.oButton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("o"));
            game.square = MonoBehaviour.Instantiate(Resources.Load<GameObject>("square"));

            game.Start();

            Vector3 pos1 = new Vector3((float)-2.8, (float)-2.8, 0);
            Vector3 pos2 = new Vector3(0, 0, 0);
            Vector3 pos3 = new Vector3((float)2.8, (float)2.8, 0);

            game.PlayerX(pos1, "0,2");
            game.PlayerX(pos2, "1,1");
            game.PlayerX(pos3, "2,0");

            Assert.IsTrue(game.CheckBoardState());

            yield return null;
        }
    }
}