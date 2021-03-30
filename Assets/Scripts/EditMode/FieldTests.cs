using NUnit.Framework;
using Assets.Scripts.Base;
using UnityEngine;
using Assets.Scripts.Mechanics;

namespace Tests
{
    public class FieldTests
    {
        [Test]
        public void MakingNewField()
        {
            TurnSystem.InitializeData();

            Field field = new Field();
            Assert.IsNotNull(field.GameObject);

            GameMechanics.ResetGame();
        }

        [Test]
        public void MakingNewField2()
        {
            TurnSystem.InitializeData();

            Field field = new Field();
            Assert.AreEqual(field.State, 1);

            GameMechanics.ResetGame();
        }

        [Test]
        public void MakingNewFieldWithConstructor()
        {
            TurnSystem.InitializeData();

            GameObject gameObj = new GameObject();
            Field field = new Field(gameObj, 1);
            Assert.AreEqual(field.GameObject, gameObj);

            GameMechanics.ResetGame();
        }

        [Test]
        public void MakingNewFieldWithConstructor2()
        {
            TurnSystem.InitializeData();

            GameObject gameObj = new GameObject();
            Field field = new Field(gameObj, 2);
            Assert.AreEqual(field.State, 2);

            GameMechanics.ResetGame();
        }
    }
}
