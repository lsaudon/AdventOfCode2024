namespace AdventOfCode

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

module DaySeven =
  type Total = int
  type Numbers = int array
  type Equation = Total * Numbers
  type Equations = Equation array

  let parseInput (input: string) : Equations =
    input.Trim().Split(Environment.NewLine)
    |> Array.map (fun t ->
      let temp = t.Split(':')
      let total = int temp[0]
      let numbers = temp[1].Trim().Split(' ') |> Array.map int
      total, numbers)

  let generateOperators (numberOfValue: int) : string list =
    let operatorPossibility = [ "XX"; "XO"; "OX"; "OO" ]
    let mutable operators: string list = []

    for i in 0 .. 4 - 1 do
      for j in 0 .. 4 - 1 do
        for k in 0 .. 4 - 1 do
          operators <- operatorPossibility[i] + "" + operatorPossibility[j] + "" + operatorPossibility[k] :: operators
          printfn $"%s{operatorPossibility[i]}%s{operatorPossibility[j]}%s{operatorPossibility[k]}"

    operators

  module PartOne =
    let run (input: string) : int =
      input
      |> parseInput
      |> Array.fold
        (fun acc (total, numbers) ->
          let product = numbers |> Array.fold (*) 1

          if product = total then
            printfn $"Equation ID: %d{total}, Values: %A{numbers} - Valid"
            acc + total
          else
            printfn $"Equation ID: %d{total}, Values: %A{numbers} - Invalid"
            acc)
        0

  module PartTwo =
    let run (input: string) : int =
      input |> parseInput |> printfn "%A"
      0

[<TestClass>]
type DaySevenTest() =
  let exampleInput =
    """
190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20"""

  let puzzleInput = """"""

  [<TestMethod>]
  member this.GenerateOperators4() =
    Assert.AreEqual(
      [ "XXXX"
        "XXXO"
        "XXOX"
        "XXOO"
        "XOXX"
        "XOXO"
        "XOOX"
        "XOOO"
        "OXXX"
        "OXXO"
        "OXOX"
        "OXOO"
        "OOXX"
        "OOXO"
        "OOOX"
        "OOOO" ]
      |> List.rev,
      DaySeven.generateOperators 4
    )

  [<TestMethod>]
  member this.GenerateOperators5() =
    Assert.AreEqual(
      [ "XXXX"
        "XXXO"
        "XXOX"
        "XXOO"
        "XOXX"
        "XOXO"
        "XOOX"
        "XOOO"
        "OXXX"
        "OXXO"
        "OXOX"
        "OXOO"
        "OOXX"
        "OOXO"
        "OOOX"
        "OOOO" ]
      |> List.rev,
      DaySeven.generateOperators 5
    )

  [<TestMethod>]
  member this.PartOneExample() =
    Assert.AreEqual<int>(3749, DaySeven.PartOne.run exampleInput)

  [<TestMethod>]
  member this.PartOnePuzzle() =
    Assert.AreEqual<int>(3749, DaySeven.PartOne.run puzzleInput)

  [<TestMethod>]
  member this.PartTwoExample() =
    Assert.AreEqual<int>(3749, DaySeven.PartTwo.run exampleInput)

  [<TestMethod>]
  member this.PartTwoPuzzle() =
    Assert.AreEqual<int>(3749, DaySeven.PartTwo.run puzzleInput)
