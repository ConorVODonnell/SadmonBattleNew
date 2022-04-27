using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CC_Constructor_Tests
{
    [Test] public void CreateCC_FromInt_CatchesError() {
        Assert.That(() => new CubeCoordinate(-5, 6, 1), Throws.TypeOf<ArgumentException>());
    }

    [Test] public void CreateCC_FromInt_Correct() {
        Assert.That(() => new CubeCoordinate(5, -3, -2), Throws.Nothing);
    }

    [Test] public void CreateCC0_FromInt_Correct() {
        Assert.That(() => new CubeCoordinate(0, 0, 0), Throws.Nothing);
    }
}
