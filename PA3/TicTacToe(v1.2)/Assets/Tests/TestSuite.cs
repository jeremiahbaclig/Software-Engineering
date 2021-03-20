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

            yield return null;
        }
    }
}