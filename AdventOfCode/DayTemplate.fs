namespace AdventOfCode

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

module DayTemplate =
    let partOne (input: string) : int =
        0
    
    let partTwo (input: string) : int =
        0

[<TestClass>]
type DayTemplateTest() =
  let exampleInput =
    """
"""

  let puzzleInput =
    """
"""

  [<TestMethod>]
  member this.PartOneExample() =
    Assert.AreEqual<int>(0, DayTemplate.partOne exampleInput)

  [<TestMethod>]
  member this.PartOnePuzzle() =
    Assert.AreEqual<int>(0, DayTemplate.partOne puzzleInput)

  [<TestMethod>]
  member this.PartTwoExample() =
    Assert.AreEqual<int>(0, DayTemplate.partTwo exampleInput)

  [<TestMethod>]
  member this.PartTwoPuzzle() =
    Assert.AreEqual<int>(0, DayTemplate.partTwo puzzleInput)
