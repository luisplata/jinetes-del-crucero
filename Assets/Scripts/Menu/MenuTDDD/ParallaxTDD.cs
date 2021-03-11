using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace Tests
{
    public class ParallaxTDD
    {
        // A Test behaves as an ordinary method
        [TestCase(1, 1, 2)]
        [TestCase(1, 2, 3)]
        [TestCase(2, 2, 4)]
        public void ParallaxTDDSimplePasses(float concurrentRect, float multipli, float result)
        {
            var view = Substitute.For<IControllerParallaxView>();
            view.GetDeltaTime().Returns(1f);
            ParalaxLogic logicParallax = new ParalaxLogic(view, 1);
            
            Assert.AreEqual(result, logicParallax.MoveParallax(concurrentRect, multipli), $"The calc to this parallax is moved");
        }
    }
}
