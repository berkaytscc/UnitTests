using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class player_movement
    {
        [UnityTest]
        public IEnumerator with_positive_vertical_moves_forward()
        {
            GameObject playerGameObject = new GameObject("Player");
            Player player = playerGameObject.AddComponent<Player>();
            player.PlayerInput = Substitute.For<IPlayerInput>();
            player.PlayerInput.Vertical.Returns(1f);

            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.SetParent(playerGameObject.transform);
            cube.transform.localPosition = Vector3.zero;

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitForSeconds(.3f);

            Assert.IsTrue(player.transform.position.z > 0f);
            Assert.AreEqual(0, player.transform.position.y);
            Assert.AreEqual(0, player.transform.position.x);
        }
    }
}
