namespace AdventOfCode

open Microsoft.VisualStudio.TestTools.UnitTesting

module DayFour =
  let partOne (input: string) : int =
    let grid = input.Split('\n') |> Array.map (fun line -> line.ToCharArray() |> Array.toList) |> Array.toList
    let mutable value = 0
    let horizontal = grid.Length - 1
    for i in 0..horizontal do
      let vertical = grid[i].Length - 1
      for j in 0..vertical  do
        if grid[i].[j].Equals('X') then
          if i >= 3 then
            if grid[i-1].[j].Equals('M') && grid[i-2].[j].Equals('A') && grid[i-3].[j].Equals('S') then
              value <- value + 1
            else
              value <- value
          if j >= 3 then
            if grid[i].[j-1].Equals('M') && grid[i].[j-2].Equals('A') && grid[i].[j-3].Equals('S') then
              value <- value + 1
            else
              value <- value
          if i <= horizontal - 3 then
            if grid[i+1].[j].Equals('M') && grid[i+2].[j].Equals('A') && grid[i+3].[j].Equals('S') then
              value <- value + 1
            else
              value <- value
          if j <= vertical - 3 then
            if grid[i].[j+1].Equals('M') && grid[i].[j+2].Equals('A') && grid[i].[j+3].Equals('S') then
              value <- value + 1
            else
              value <- value
          if i >= 3 && j >= 3 then
            if grid[i-1].[j-1].Equals('M') && grid[i-2].[j-2].Equals('A') && grid[i-3].[j-3].Equals('S') then
              value <- value + 1
            else
              value <- value
          if i <= horizontal - 3 && j <= vertical - 3 then
            if grid[i+1].[j+1].Equals('M') && grid[i+2].[j+2].Equals('A') && grid[i+3].[j+3].Equals('S') then
              value <- value + 1
            else
              value <- value
    value

  let partTwo (input: string) : int = input.Length

[<TestClass>]
type DayFourTest() =
  let exampleInput =
    """
MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX
"""

  let puzzleInput =
    """
MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX
"""

  [<TestMethod>]
  member this.PartOneExample() =
    Assert.AreEqual<int>(18, DayFour.partOne exampleInput)

  [<TestMethod>]
  member this.PartOnePuzzle() =
    Assert.AreEqual<int>(18, DayFour.partOne puzzleInput)

  [<TestMethod>]
  member this.PartTwoExample() =
    Assert.AreEqual<int>(18, DayFour.partTwo exampleInput)

  [<TestMethod>]
  member this.PartTwoPuzzle() =
    Assert.AreEqual<int>(18, DayFour.partTwo puzzleInput)
