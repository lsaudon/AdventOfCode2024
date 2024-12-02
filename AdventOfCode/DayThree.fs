namespace AdventOfCode
open System
open Microsoft.VisualStudio.TestTools.UnitTesting

module DayThree =
    let partOne (input: string) = 0
    let partTwo (input: string) = 0

[<TestClass>]
type DayThreeTest () =

    let exampleInput = """
0
"""
    let puzzleInput = """
0
"""

    [<TestMethod>]
    member this.PartOneExample () =
        Assert.AreEqual<int>(0, DayTwo.partOne exampleInput)
    [<TestMethod>]
    member this.PartOnePuzzle () =
        Assert.AreEqual<int>(0,  DayTwo.partOne puzzleInput)
    [<TestMethod>]
    member this.PartTwoExample () =
        Assert.AreEqual<int>(0, DayTwo.partTwo exampleInput)
    [<TestMethod>]
    member this.PartTwoPuzzle () =
        Assert.AreEqual<int>(0, DayTwo.partTwo puzzleInput)