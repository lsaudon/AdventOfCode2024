namespace AdventOfCode

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

module DaySix =
    let partOne (input: string) : int =
        0
    
    let partTwo (input: string) : int =
        0

[<TestClass>]
type DaySixTest() =
  let exampleInput =
    """
"""

  let puzzleInput =
    """
"""

  [<TestMethod>]
  member this.PartOneExample() =
    Assert.AreEqual<int>(0, DaySix.partOne exampleInput)

  [<TestMethod>]
  member this.PartOnePuzzle() =
    Assert.AreEqual<int>(0, DaySix.partOne puzzleInput)

  [<TestMethod>]
  member this.PartTwoExample() =
    Assert.AreEqual<int>(0, DaySix.partTwo exampleInput)

  [<TestMethod>]
  member this.PartTwoPuzzle() =
    Assert.AreEqual<int>(0, DaySix.partTwo puzzleInput)
