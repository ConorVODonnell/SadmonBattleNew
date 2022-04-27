using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CC_Steps_Tests
{
    [Test] public void Step3() {
        var c = CubeCoordinate.right + CubeCoordinate.right + CubeCoordinate.upRight;
        Assert.AreEqual(3, c.Steps());
    }
    [Test] public void Step2Away_1Rotating() {
        var c = CubeCoordinate.left + CubeCoordinate.left + CubeCoordinate.upRight;
        Assert.AreEqual(2, c.Steps());
    }
    [Test] public void Step3_Backtrack() {
        var c = CubeCoordinate.upRight + CubeCoordinate.downLeft + CubeCoordinate.downRight;
        Assert.AreEqual(1, c.Steps());
    }
    [Test] public void Steps2_DiagonallyAway() {
        Assert.AreEqual(2, CubeCoordinate.downRight.StepsTo(CubeCoordinate.left));
    }
}
