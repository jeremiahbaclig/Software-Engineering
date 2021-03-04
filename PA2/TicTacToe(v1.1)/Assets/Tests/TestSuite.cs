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
        public IEnumerator Instantiations()
        {      
            var game = new GameObject().AddComponent<GridManager>();

            game.line = MonoBehaviour.Instantiate(Resources.Load<GameObject>("line"));
            game.xButton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("x"));
            game.oButton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("o"));
            game.square = MonoBehaviour.Instantiate(Resources.Load<GameObject>("square"));
            game.rend = game.square.GetComponent<SpriteRenderer>();

            Vector3 pos1 = new Vector3((float)-2.8, (float)2.8, 0);
            Vector3 pos2 = new Vector3((float)-2.8, 0, 0);
            Vector3 pos3 = new Vector3((float)-2.8, (float)-2.8, 0);


            game.PlayerX(pos1, "0,0");
            


            //bool answer = game.CheckBoardState();

            yield return null;
        }
    }
}
