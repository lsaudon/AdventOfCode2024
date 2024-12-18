﻿namespace AdventOfCode

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

module DayFour =
  let partOne (input: string) : int =
    let grid = input.Trim().Split(Environment.NewLine) |> Array.map (fun line -> line.ToCharArray() |> Array.toList) |> Array.toList
    let mutable value = 0
    let horizontal = grid.Length - 1
    for i in 0..horizontal do
      let vertical = grid[i].Length - 1
      for j in 0..vertical  do
        if grid[i].[j].Equals('X') then
          if i >= 3 then
            if grid[i-1].[j].Equals('M') && grid[i-2].[j].Equals('A') && grid[i-3].[j].Equals('S') then
              value <- value + 1
          if j >= 3 then
            if grid[i].[j-1].Equals('M') && grid[i].[j-2].Equals('A') && grid[i].[j-3].Equals('S') then
              value <- value + 1
          if i <= horizontal - 3 then
            if grid[i+1].[j].Equals('M') && grid[i+2].[j].Equals('A') && grid[i+3].[j].Equals('S') then
              value <- value + 1
          if j <= vertical - 3 then
            if grid[i].[j+1].Equals('M') && grid[i].[j+2].Equals('A') && grid[i].[j+3].Equals('S') then
              value <- value + 1
          if i >= 3 && j >= 3 then
            if grid[i-1].[j-1].Equals('M') && grid[i-2].[j-2].Equals('A') && grid[i-3].[j-3].Equals('S') then
              value <- value + 1
          if i <= horizontal - 3 && j <= vertical - 3 then
            if grid[i+1].[j+1].Equals('M') && grid[i+2].[j+2].Equals('A') && grid[i+3].[j+3].Equals('S') then
              value <- value + 1
          if i <= horizontal - 3 && j >= 3 then
            if grid[i+1].[j-1].Equals('M') && grid[i+2].[j-2].Equals('A') && grid[i+3].[j-3].Equals('S') then
              value <- value + 1
          if i >= 3 && j <= vertical - 3 then
              if grid[i-1].[j+1].Equals('M') && grid[i-2].[j+2].Equals('A') && grid[i-3].[j+3].Equals('S') then
                value <- value + 1
    value

  let partTwo (input: string) : int =
    let grid = input.Trim().Split(Environment.NewLine) |> Array.map (fun line -> line.ToCharArray() |> Array.toList) |> Array.toList
    let mutable value = 0
    let horizontal = grid.Length - 1
    for i in 0..horizontal do
      let vertical = grid[i].Length - 1
      for j in 0..vertical do
        if grid[i].[j].Equals('A') then
          if i >= 1 && j >= 1 && i <= horizontal - 1 && j <= vertical - 1 then
            if grid[i-1].[j-1].Equals('M') && grid[i+1].[j+1].Equals('S') then
              if grid[i+1].[j-1].Equals('M') && grid[i-1].[j+1].Equals('S') then
                value <- value + 1
              if grid[i+1].[j-1].Equals('S') && grid[i-1].[j+1].Equals('M') then
                value <- value + 1
            if grid[i-1].[j-1].Equals('S') && grid[i+1].[j+1].Equals('M') then
              if grid[i+1].[j-1].Equals('M') && grid[i-1].[j+1].Equals('S') then
                value <- value + 1
              if grid[i+1].[j-1].Equals('S') && grid[i-1].[j+1].Equals('M') then
                value <- value + 1
    value

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
XMXMXSXMMSSSSSXMMAMXAAXXMXSXMMSMXMXXMMMMMXXMXXAMSMSSSMXMXSAMXAMAMXSMSMXMXMAMAMAXAMSSSXSXMXMAXAMXSMMSSMXSXXSSXSXSSSMMSSMSXAMXXMAMXSSXSMXMSMMM
MMAMAMASXAAAXAAMASXMXMAXSAMAXAAAAXMASAAASMSMMMASMXAAXMMAASXSXMXASMAAXMAXSMMXSMMAXSAMXASMMSMSSXXAMXAAMXSAMXMAASAMAAXAAAAAXSASXSMSSMSASMSASAAX
ASASMSAMMMSMXXXMAMAMSMSMSASMMSSSMSAASMSMSAAAASXMXMMSMMAMASAMAMSASAMMMMXMSAAAAAXAXMAXMXMASMAAAMXSMMMMMMXAMAMMMMAMSMMMSMMMMXXMAAAXAAMXMASASMMM
XSAAXMAMSAMXASXMMSAMXAAASMMAAMAAAAMXMAXXMXMSMSAMXSMAMXAXAMAMAMMAMXXAMXMASAMXSAMASMMMAAMMMMAMSMAMAXAMSMSMSSSMASXMAAXAXAMXASXMSMMSMMMMMAMAMASX
MMXMASAXMASMAMXAXSMSMSMXMAXMXMXMMMMXAMMSXAMAMSMMAXMASXMSXSAMMSMXMXMMXAMAMXXAXXAAXASXSSXXXXSXAMASAMXSAAAAAMAXAMXSSMMMSMMMXMAMXXMSAAAAMAMAMSMM
XSAMXMAMSAMMAMSMMMSMMXMSSXMMXSAXMXMSMMAMSMSAXMAMXXSAMAASAMXSMAMSMSASMXMSSMMSSXMXMXMAAAASMMMSMMAMXXMMMSMSMSSMMXMXMXAXAAAXASXMMAXMSMSSSMSSSMAA
AXAXSXMASXXMAMAAAXAXMXMAMAXAAMAMSAXAAMSXSXSXSAAMMMMMSSMSAMXXXASAAMAMXMSXAMXMAXSMSMMMMMMMAAAAMMSSSSMXXMXXXAAAMSXMASXSMSMSMMAASXMXAMXXAMAMAMMM
MMSMMASAMMMSASMSMSMSSMMMSSMMSSMMSMXMSMXAMAXAMMMMXMXAMAAXMASMSMSXSMSMMMMSMASMAMMAXXAAAAASXMMMSXMAXAASMSMXMXXMMAXAXMMMAAXMASMMMMSSMSSSSMSSSMSM
XAAASAMAMAXSXSXMAAAXAMMXMMAXAAAXXXSXAMXAMMMXXAXXXMSASMMMMAXAAAMAXAXAXAAAXXMMSSMSAMXMMMMSSXMASMMMMMMSAAAAXMMSXMSMMAAMSMXSAMXXXXAAAAMAXAAAXAAX
MXSMMXSAXSASXXMMMMMXAMXAXMSMSSMMXXAXMSSMAXSASXXSAAMAMMXSMSMSMSMAMXMMSMSSSMSAXXAMMMSAMSMMMSMASAAXXMAMXMXXSAAXAXAASMMMXAAMAMMMSSSMMMSMMSMSMSMS
SAMAMMMMSXAXMMMSXASMMMSXSAMAMMAMMMMMMAXXMMMASXAMMAMSMMAAAMMXMMMMSSMMSMAMAAMMXMXMAAMAMAAAXMMMSMMXSMXSXSAASMMSMMXXMASXMMMSMMSMXAASMAAAMMAMAMXX
XASAMAAMSMSMAXAAMXMAAAAAMXMAMXAMAAXAXSSSMSMAMMXMMXMXAASMMMXASXMASAMASMAMMMMSMMSMMSSMMSSMMSAXSXSAXAMXAMMXMAMAMSMSXMAAMAAMXAAMMSMMMXSMMMSMMMAM
SAMXSSSMSAAMSMSSSSSSMMSMMMSSXSMSSSSSSMAAASAMXAMXMAMMSMXAASMMSAMXMAMAXMAXASMSAAAXMAAMAAAXASMSMAMMSMMMMMXAMXMASAAMAXMSSMSSMSSSMMAXSMXASXMAXMAM
MAAXXAXAMSMXMAXXAAMXXAMXAAXXMXMAMXAMAMSMMMXSMSSMSAXAMASXMMAASMMXSSMMMMXSMSASMMMAMSMMXXAMXXXAMSMAAAAXAMSMSMSMMMMMXMXXAAAXXMAXASAMMASAMMSMMSMS
SSMSMSMSMASAXXXMXMXXXSMSMSXMASMSMSMMAXXSXMASAMAAAMMSSMMAXSMMMXMMSAAMSSMAAMAMXSXSXXMMSMAXASXMSAMSSSMXSMAXAAAASXSMSAXSMMMSMMAMMSMMMAMAMXAMMAAA
AXAAAAAXMAMMMSMAMMMXMMASAMMSAAAAASASXSASXXAMXMMMMXAAAASXMAXMMAMXSMMMAASMMMAMMSAAAMSAMSAMMSAMMAXAXXXAXSSXMSMSASAAMSMSAMASXMASXMAXMMSSSSMMMXSX
MMSMSMSMMSXSAMAMAAMXSMAMAMAMSSXMASAMAMMXMMXSAXXSSMSXSMMAAXSMSASMMSMMSXMXXSXSAMSMXMMAXXMSXSAMSSMSMSMMMAMXMXMAMMMXMAMSAMASASAMASAMAAXMAAMSSMMX
XMAAMMMXAMAMASMXSMSAMMMSSMXXMMXXXSAMXMMAASASMMSAMXXAMXMASXMAMASAAAXAMMSMMXMAXXAXAMSMMAXMXSAMXMAAAAAXMXMMMAMXXAAMSMXSAMASXMAMXMXAMMMMSMMAAAAS
SSMSMAXMASAMAMMMMAMXSAMXAXSAMXXMASAMXMSASMASASMMMAMAMXXMMMMAMMMMSMSMMAAMXSAMXSMMMMAASXMSMSMMAMMMSMSXAASXSMMMSXSXAXMSXMAXMSSMSMXMAASAXXMMSSMA
XAMAMXXMXSAMMMSAMMMASMSMMASAMXXMAXMXAASMMMSMXMASMAMAMSXSAMXXMMAXXXXAMSMSAXAMXMXASASXXXMAXXASXSMMAXXXXXSAAASXMMMXMSMMMMMMMAMXAXAXSXMASMXXXAXM
MSMMMSXSAMXSAAXXSAMMXAAAXMXXMXMMMXSMMMXAXXAMMSXMSXXAMAAMMMSAMSXSSMXAMXXMAMSMMASXSAMXMSSMSMMXAAXSAMXMXSMMMMSXSAMASAXSAMXXMASXSMXMMAMXMAMMMAMX
AAAAAMMMXMAMMSMMSAMXSSSSSXSXSXSXXAAXXAXMMSMSAXXMAXMAMMSMMAAMXMAXAAXMXMMMAMXAMAXAMMMXAXMAMAXMMMMAMSMMMSAMXAMMMASXSAXXAXXMAMSAMAMASMMAMAMXAXMS
SSSMSSSMMMAMAMXMXAMXAAAAXAAASMSAMSXMXMMMMAXMXSMMAXSAMAXXMMMSAAAMMSXMAMAMSXSAMMSXXAAASXMAMSMXAAAMAAAAAMMMMASXSMMXMXMSSMSXSAMAASAMXMMSMMSMXMAA
MMMMXMAAXSXMASXMSSMXMXMMMMMASAMSMAASASASMSSMAMXMAMAAMXMASMASMSMXXMAMMSAXXASXMMAXSMSMXAMAMXXSMXSXSSSMXSAASAXAASXMXAMXXAXAAASXMMAXSMAXAMAASMXM
SXXSASMSMMASMSXXAMXAXSMSXSAXMAMMMSSMASXSAAMMAMAMMSMMMXMSAMXMAAXXSSSMAMMSMMMMSMMXAAXXAMSMXMAMAAMMMAXMAMMMSSMSMMMMSXMASXMMMAMMASMMAMAXASASAMXX
XAXSASXXASXMAXXSMSSXSAMXAXAMXXMSAMAMMMAMMMMSASXSMAMXXAMMXMAMMMMXMAXMXSMAAXXAAAXXMXMAMXAXAMXMSMSAMMMMAMSXMMMAAAXAAMMMMAXXXXXMAMAXMMMSMMMXMSSM
MSMMAMMXXMXMMMAXAAAXMMSMSMSMXSMMMSMMAMSMXMMSXSAXMAXMSSSMAMASXASMMSMXSAMSMSASXSMMXAAAMSASXMAMXASMMXMMAMMAMSSSMSMMXSAAMSMMMSMMSSSMXAXAMAMMXAXS
SMAMSMSSMMXAXMMMMMSSMXSXMAXXXXAAMAMSMMAMXMAMMMMMSXSXAAMMAXAXMXMXAXAMXAMXSAAXAAXASASMXXMAMSMSMXMXMAMSSMSXMAXMXMASASMSXXASAAAMAMXMSMSMSASAMSSM
MMAMXAMXAXSMXAASXMAAMXMAMSMSXMXMMAMAXSASMMAMAAAAXSAMMMMSMSMSSSMMMMAMSXMMAMXMMMSMMXAXXXSAMXMMAASAMAXAAAXMASMSMSAMASAXMSAMSXXMAXAMAMAXSAMXMXAM
SSMXMMMMSMMXSMMSAMSSMAMAMAMSASASMXSAXSAMXMMSMSSSSXMXSAAAAAAAAAMAAXAMAAXMMXSXAAXASMMSSMMMSSMMSXSXXSAMMAMXMAXMASAMXMAMAMMMMMSSSSMSASAMMASXMSAM
MASXSMSAMASASAXSAMXMMSMMSAMSAMMSAAMMMMSMXXAAXMAMXMMASASMSMMMSMSXSSMSSMMXXAMXMXSAXAXAXAAAMXAAMMMMMMAXXASMMMSAMSAMXMXMXMSAXAAAAAASAMXMXAAAAXAS
SXMXAAMASMMASMMSXMXMAXAASMXMAMMMMMMMAMASXMMSXMAMXAMASXMMMAMAMXSAMMMAAMSMMAMXSAMASAMASMMMSSMMSAAAASMMMXMAAAMXMSMMXAAXAMMMSMMXMMAMAMAXMMSXMSSM
MASMMMMXMXMAMXMSXSAMASMMMXAXAXAAXXASXSAMMXMXMXAMXSMASASAMASMXAMXMAMXMMAMXSMSMASAAASAMXXXAAXAMMSSXSMSMMSSMXSAMXSXSXMXXMAXMASXXMAXASMMXMMMMSAA
SAMASMMMXAMMMMAMASMMXSAMXSMSASMSSSMSMMMSMXMAXSASMMMMXAMMSAMXMMXASXSMMSMXAAMAMAMMSMMMSMSMSSMSSMXMAXAAMXAXMAXXSAMMSAMASMSMSAMMXSMSMAXMASXAXMXX
MASXMAASMMMSAMAMMMASXSXMXMXAMXMAMAXMASAAXSMAXSASXSASMMMMMAMSASAMXAAXAAAMSSSSSXSXAMAXAASXMXMAAASASMSMSMSSSSMAMXSASXMXXAAXMMMMAAXMXAMSXMMSSMMM
SAMXXSMXXMASXSXMASAMXMAMSMSSMASASMAXSASXSSSSMMMMASASXSMXSMMMAMXSMSMMSMSXAAAAXMAMXSMSMSMMMAMSSMSXMAMAAMAAAXMAMXMMSAMSMMMMMSAMSSMSMSMSAXXXAMAA
MAXSAMMSSXAMAMAMXMASXSSMSAAXSXSMSXMSMAXMMXMMASMMMMXMAXXAXXXMSMAMAXAXMMXMMMMMMMSMMMMXMXAASAMMMMMAMMMXMXMMMMMAXAXAXAMXAAXAXMAMXAXXAXXSMMXSAMSS
SAAMAMAAMMSSMSAMASAMXAAXMMMXAMXMMXXAMSMMSXMSAMXMXXAMAMMMMMSAMMAMXSAMXAXAMASAXXAAAMAMAXSMSMXMAAMAMMAMMSMMAMSMXMMMSMMSSMSSSSSMMMAMAMXMSAASAMXX
MMSXAMMXSAXAASASASASMSMMMAMXAAXMAMXMXXAAAMMMMSAMMMSMXXAAAXMASMMMXAMMMMSSMASMMSSSMSMSAAMXSASXSSSSSMMSAAASXXAMXXSMSAAMAAXMAAXAXXMAASXAMXMMMSSX
XAMMMMXMMXSMMMAMAXAMMAAXSAXSAMMMXMAMXMMMSMMAXSASMAXMASMSMXSAMAAXSAMXXAAMMMMAAXMMAAMMXSXAMMMAAAAXXAAMMSMMMMASAAXASXMSMMMMSMSMMXXSXAMMMSSMAMXS
MXSASAAXAAXXAMAMXMSMSSSMSAMSMSAAAXSXSXMXMAMSMSMMMSXSAXAAAAMASMMMSAMXMMSSSMMMXSAMSMSMMMMMMMMMMMMMMMMSXMASAMAMMSMAMMAMAAXAAXMASMMMMSMSAAMMXSAX
MASAMMMMMSSXSSXSAMXAMXAAMXMSASMSMMAAXAMXMSMXAXXMAXMXAMSMAMSXMAMMSAMXMXXAAXAXASXMAAAAAXAXXXAXMXSAMAAAMSAMXMXSAMMAMMASXMXSXXSAMAAAXAAMMMSMSMMS
XMMXMXXASMXAMAASXMMMMSMMMAAMAMXXXXMMMMMMXXAMAMAMXSXXMMXXMXSASXSASAMAAXMSMSSSMMSMXMSSMMMSASMSMMSASXMXAMXXXMXMASXMXSXSAMAAAAMMMSMMSMMMSAXMAAAX
SAMXMSMMSAMSMSXMAMXSAXXASMSMSMMMSXXSAMXXAMAMMMSMASAMXAXAAAXAMAMASAMXMXMXAAXMAASMSAMXMSSMMMAXMASXMAXSSMSXSASMAXAXMMXSAMSMAMXSAXAMAXAAMASXSMMS
MASMMMXSMMMXAMSSXMAMAMMXXAXXXXAAXMASASMMXSAMAAAXASASMMMSMXSAMXMMMXMAXSXMMMSMMMSAXAMAMXAAXMAMMASMXMXAXAXXMAAMAXMMAMASAAXAMXXMASASASMMMMMXXAAX
SAMAAAXMAMAMAMAMAMMSAMMSMMMSMSMSXSMMAMXAMSMSMSMMXSAMAAXXAASAMXSMMMSXMMMAXXXXSAMXMXSASMMMMSMXAMXXAMMMMMMMMMMMSSMASMXSMMSMAXXMAMXMAMMASASMXMMS
MAMSMSMSAMSSSMMMAMMMMMAAAMAAAAAAASXMAMMSXSASXMAXXSASXMAMMMXXMAXAAMAMAAAMMMAMMAXXMXSXSAAMASXMSAMMXXAAAXMMAXAAXXMAXAMXMAMXMSMMMSMMMSSMSAXASMAX
MSMAAMAMXSAAXXSSSSXAAMXMMMSSSMSMSMASASAMAMAMASXMXMAMMAMXMMMMMMSSMSXAXAMSASAMSXMASAMXSMMMMMAXMASAASMXSAMXSXMMSMMSXSAAMAMAXAXAXAMSAAAXMMMMAMXS
AAAMMMXMMMMMMAMXXMMMSMMASAMAAAXXAMMMXAMMMMAMXMAMMMSMMXXAASMXSAAAAAMSAMASMXAMAASAMASXXXXXMXMMSAMMMSAAAXXXMXSAAXAMXASMMSMSSXXSMSSMMSSMMXSAAXAA
SMSMMXAMAMXAAMMSMMASAXAAMAMSMMMSXSXSMMXMXSXSASXMMAMAMSSXSXAAAMSMMSAMSSXMMSSMSXMASAMMSMMMSAMAMXMXAMMMMMMAMAMAMMSSMMMMAXAMMXAMXMAXAAMMAAMXSMMX
XMMAXXSSMSSMSAAMAXMSASMXXXMAAAXSASMSXMAMMMASASAMMAXMMAXXMMMMMXXAMXMXAXAAAXMAXMMMMAMXAAAASAXSXSMMMSXXAMXAMAMXSMAAXXMXAMAMAAMSMSAMXSAMMXMAMAAS
MASAMAAAMXMAMAMSSMXMAMXSXSMSXMSMAMXMASASAMAMXMASXSXSMMMSMSASXMASXASMSSSMMSMMMSAXSAMSSSMXSSMXMMMAXMAXSMSXSASAAMSMMAXMSSSMXMMAAMXMXMXXSAMXSAMA
MXMAMXXXMAMMMAMAXMXMXMASAXAAMMXMAMASMMASMMAMSSMMAXMMAMSAAXSMAAAXMASAXAMMAAAAASMMSAXXXXXXMASMASXSMMSMMASASAMMMMXMMSAAMAXMASMMSMSMXMSMSASASAMM
XAXXMMSMMSSXMXSXMMMSAMXMAMSMSXAXXSASAMXMMSMSAAAMAMASAMMMMMMSXMASAAMMMAMMSSSMMSXXSMMSAMXMMXMSXMAAXXMAMAMAMXSMXAMXAAMMMXMMXSXAAAAMAXXASAMXSASX
SMXSXAAAXAAMSMMXSAMSASMMSMAAAMAMXMASXMMAMAMMXMMMMMAMAXXASXMASXAMXMMXMAMXAAAXAMXAXAXAAMSXXAAMMXSMMSMMMMMXSASMMSSMSSSSXMASMMMSMMMXXSMXMSMASAMM
AMASMSSSMMSMAAMAMAXSAMXAAXMSMASAXSASXMAXSXSASXMASMXSAMSMMMSASMMSAMXAMXXMXSMMXSMMSMMMXMAASMSMSMXAXXXXAASMMXSAAXAXAMAMAXXMAXAXMASXXMASMMSMMXMX
XMASAAMXAXAMXMMMMMMSXSMXSSMAXSXXMMASASAXSXMXSASAXAAMAXAAAAMAXXAMAXSASAMMMMAMMMXXAMAMXMMXMAAMAASAMXXSSMSASMMMSXMMXMAMXSAMSMSMSASAMXXAAAMXMASX
XMAMMMSMSMSSMSAXASXMAXAAXAXSSMMSSMAMAMMXSAMAMMMSSMMXMMMMSSMSMXMMAMXMAXAAAMAMAAMMMSAXMXSAMXMSMMMXSXMAMAXXMAMMMAXAXXXAAMAMAAMAMASAMMASMMXAMSMS
XMAMSASAAXXAAAASXXAMXMMMMAMXAASAAMXMMMSASAMMSAAXMASXSXXAXXAAXMXSAMXMSMSMXSAMMSSSXSASMMSASXMMXMSAMMAMMSSSSSMASMMMSSMMXSAMXSMAMAXMSSMXAMSMSAAA
MSASMASMMMSMMMXAMSMMAAAMMXMSSMMMXMMSAAMASXMASMSXSAMXAAMSMMSMMSASASMMAAAXMAMMSAMXAMAXXASXMAAAMXMAMSSXMXAAAMMMMSXAAXAAAXASXMMMMMSAXAXSXMAMMMMX
AMMSMAMXMAXAAXXAAAAMASAMSAMXXMXSSMAAMXMASXSMXAXASMMMMMMMAXAAXMAXAMXMASXMSAMXXMSMXMMMMXMMXSMMSXMXMAMAAMMMMMAXSSMMSSMMXSAMXSAAAXMASMMAMSXSXSXM
XASXMASMMXXSMXMAMSMSMMAMMAMAMSAXMASXMXMXSXAXMXMASXXXXAAXMMMMSMSMXMASMXXAXXXAMXXAMXAAXMXAAXAMXMSMSASMMSMAXSMSSXXAAXAAAMAMAMXXSXXMAXXMMSASAMMS
SXMXSASXMSAXSXSAAXAAXMAMXMMASMMSSXMASMSMSMMXXMMAMXMXSMXMAAXXSAMMXXMSAMXSMMMSXSSSSSXXSASMXSAMAXXASASAAMMMMSXMXAMMMSMSMSAMXSSXMASXMXSXMMMMAMAX
SAMMMMSAMXAMAMSAMMSMSSMMSXMXSXAAAASAMASAMXXXSXMASASXXAASXMSAMAMMSMXMMMAAAXXMAXXMAXXXAMSAAXASMSMXMAMMMMAMAMAMMXSAMAAAXMASMAASAASASAMXMAMSMMSS
MAMXAXSXMMMMAMXXXAXXMMAAAASAMXMMSMMSMAMXMMMMMASASASMMSMXAAXAMMMAAXMMMMSSMMSMMMASASMMMXMAMSMMAXAMMMMSMMMXAXAMXASASMMMSXSMMSMMMXMAMAMAMAMAXMAS
SSMSXMMMSASXMXMMMMSASXMMSAMAMASXAAXMMASAMAAASXMMSMMAMMASMMXMMAMMSMMAXMXMXAAMXMAMAMAAXSAMXAAASMSMSAAAAASMXSASMASAMXMXSXMAAXXMASMAMMSSSXSSSMAS
AMASMAAMXASMSAMSAMMAMMXMMMSMSASMMSSXSASASMSMMAMXXAXSMMMMMASASASMAMSAMSAMMSXXMMMXXXSMMMAMSXSMMAXAXMAXMXSAASXMAMMAMXXASXSAMXMAAXXAMMAXMMMMAXAS
XMAMXMMSMAMAXAMSASMMMMASMMAAMASAMAMMMMMXMAXMMMMMMSMMMASAMXAASMXMAXMAMMAMAMMSSSSXMAXXMASMAMMAMMMMMXMASMSMMMMXSASAMXMASASXAAMMASMMSMMMSAMXAMXS
AMASXSASMAMMMSMMAMMSMSAMAMMSMMMMMAXSASMSSXMSAMXSAMASXMMXSSMMMMXSMSAMXSSMASAAAAMAMSMMMMMMAXXAMSSMMMSAAAMAXXXAAXSXMXAMMAMXSAMSASAMMASASASMSSMM
ASMMXMAMXAMXAAASAMXAAMASXMXAXMAXMAMMASAASAAXXSAMXMXMAMMSXMASAXXSAXXXXMASASMMMMMXMAAAAAXSAXSAMASAAASXMMSSMMMXXXSASMSMMSXMASXMASXMSAMAMAMAMMXM
MXXSXMAMMSSMSSXMXXXMMMXSXAXMXMASMMSMAMMMMMMSSMMSSSMMSAXMASAMXSAMAMAMMXMMXXAXSXSAMXMXXMXMXXAAMASMMMSASAMXAASASXXAMAXXAAXSAXXMMMMAMMSSMAMSMMAS
XAAXAMAXMXAXMMXMMXAXSAAMXMMXMSXSAASMAMXAXXAXAAAAAAAAMXXXAMXSAMMMXMXMMAXXXMMMMXMAXSXSSXSXSSMSMXMXMASAMXSMXMXAAMMSMMMMXSXMMSXXMAXXMXAMSSSMASAX
MMSXXMASMSSMMMAAMXXMAMXSAMAXAMAMXMXSMSMXSMASXMMSSSMMXMSMXSXMXSXMXXXASXSXXSAAXSXMMXAMAASAMAXXMASXSMMXMASMMSMMMXAMASAXXMAAMMAAMAMSMMXMAMAMAMAS
XAAXMMXAMAXMAMXAMXMAMXAXASASXMAMASXSMMMAAMMMXXMAXMASAAXXAMXSAAAASXSMMAMMMSASMXASAMXMMMMAMAMAMXSMAXMSMAXSAXAAXMASASMSASMMAMSMMXMAASXMMSAMXSXA
MXSAXSSMMSSSMSSSXSMASAMXAMASMMAXASMXAAMMSMAAXXMASXASMSMMMSAMMSMMAMMAMAMAMMXMASXMSAAMASMMMSSXMMMMSMXAMAMMMXAMXXAMASASMMSMMAAAXMSSMMAAXMMSASXM
SAXAMXAMAMXXSAMXAXMASAMMMXAMMSSMXMAXMMSAAXMSSMSMMMASMXMAMMAMAXAAMAXMSXSAXXAAMXMAMSMSAMASAAAAXXAAXXSXSXMASXSSSXAMAMXMAXXSMXMASMAMMXXMSXAMASMX
MASMMSXMAXMXMMXMMMMMSMSASMSSXAXASMSXMMMXSSMAAASASMSXMASMMMAMSSMMXSMXAXMMXSMSMASAMAMMXXAMMSSSMMMSXXMASXMMSAMAMMSMMMASMMMXMAXXXMASXSMASXSMMMXX
MXMAXSXSXMXAXSASAXAXMASASAMXMXSAMAMMSXMMXAAMXMSAXMAAMAXMAMSSMAMMXMAMMSMSASAAMMMASAMAAMMMMAAMXMAMMXSASXMMMAMSMAXAXXAXMAMASMMSSMXSAAASXAXMAMXX
SMSSMMAMMSSMMSAXASMMMAMMMMMAXAAXMAMAAAAMXMMXMMMMMSSSMSSMAMXAMAMXAMXAXAAMAMXMXMSAMXMMMSAAAMMXMMASMASMSAXAMMMMMSSSMMMSSMSASAAMASMMMSMMMXMMAMXM
AAAMSMAMAAAMAMMMXMXAMXSMMXSSMMAMMASXSXMSSSMXSXAXAMAXMMAMMXSAMSSMMSAMMMSMSMMSAAMAMXXAASXSMXXAMMAXMASASXMSSMAASAMXAAAAXAMXSMMSMMXAAMASAXSMASAA
MSMAASXMMSSMASAMXASXMAMMSAAXMXAAXAXXMAXAAAAASXMSMMMMMSAMXAMMMMAXAAAXAAAAXAAAMMMMSXMAXXAXMMMXXMMSXAMAMXXAAXSMSAMSXMMMSMSAMXAAMAMMXXSMSAXSAXXS
XMXSXSXAXAXXAXMXMAMSAMXAMMSMSSMSMXMASMMMSMMMSAMAXAXSASAMMSMSAMSMSSMMSSMSMMMSXXAAMMMSMMMMSSMXSASAMXSSMSMSAMXXXAMMASXMAXMXSMMXMXMAXXAAMMMMMSMM
XMXMAXXAMXSSSXSAMSAMXXMASMAXAAAXASXMMAMXAAAAMAMXSASMAXMXXMASXXXAMMAXAAXAXXXAXSMMAASASAMXAAAAXMMAAMXXAXAMAASMMSMMAMASXSMXSMMSMMXAMSMMMXSAMAAA
MSSMMMXXAXMAMAXAMXAMMSMMMXMSSMMMXMASMMMSXSMSMSMMXMXMXMMAMMMMXXMAMSAMMXSXMMXMMXMXXMSASXMMSSMSSXAMMSMMXMXMMXMAMMAMSSXMAAXAMXAAASMSMASXMASASMSS
SASAXAMXSMMAMSSSMSXMAAAMMAXXXMAXXMAMAXAAAMXMAMAMASASMSMAAASMMMSAMXXXAAXAMXAXXAMXSXMXSASAMXAMXMXSAXAXXMAMAXMXMSAMAXMMSMMXSMXSXMAASXMXMAXMMAAX
MAMMXSAMAAXMXXAXAXSMMMSASMSSSMSMAMXSXMMSXSAMXSAMMSASAASXXXMAAAMMMMXMMMSAMAMSMAXSAXSASXMASMSMXSAMAXSAXSAMSSMMXSMMMSAAMMMMXMAXMMSMMXSXMSSSMMMS
MAMMAMMSSSMSXMMMMMASXAMASAAAAAASAMMMMXMXMXAMXMXMASMMMMXMSMSMMSSXSMMSAAXMMAAXXAMXMXMAMMSASAMAMMASAMAAMMMXMAASAXXAMXMXSAAAXMASAXXAMXSSMMAXXAMA
MASMASAMAXAMXXAAXSAMMSMAMXMXMMMSXXAAMXMAMXAMXMSMXSMSXMAAAMAAXMAMAAAMXSMSSSSSMSASXMMSMAMAXMMSMSAMXSMXMAXAMSMMMSSMSAMXSXMMXMASMMXAMAMAMMAMSXSS
SAXAAMAMMMSMMSXXXMAMSAMXMMSMXSAMAXSXSASASMSAMXAMXSXSASMSMSSSMMMAMMMSMMAAAAAAAAAAASAXMSMMMSAXMMMAAMXSSMMMXAXMAMAMXAMXMMXMAMASMMSSMMXAMMSMSAAX
MMSMASXMXAAAXAMSSSXMSXSAMAXAXMAMMMXASASASXMAMMAXXMMSAMXMXMXMAAXSXSAXAMMMSMMMMMSMXMASAMAMAMASXAMMMSAMASASXMMSMXAASAMAMASMAAAXAMAMXMXASXXAMMMM
XXAXMAXXMSSMMMSAASAMXMSMMAMXXSSMSSMAMAMXMXSAMXSMAMAMXMAMXMASMMSAMXMSSSXMMMMXXAXMAMXMMSAMASMAXXSMAMXMMMMMAMASXSMMSAMMMAMSAMXSSMASAXMMMXMAMSAA
MSMXSAMMAMAASXMASMXXAXXMMSSMAXXAXAMXMXMASMMAXAASAMSSMMAXMSAMAXAXAAAMXMAXXAMXMMSMSMAXXSASXSMMSMMMSMMSXMASMMAXXMAASXSXMAXAXMXAXSAMAXSAXASAMMMS
AMAAMASMASMMMMXMAXXSSSSXAAAXSSMSMSMSMASASXSAMXXMSAMXASASASAMXMSXMMSSSSSMSXMXXMAAAMSMMMXMASXSAAMAMAAAMSAMXMAMMXMMSAXXMXSMMSMSAMXXAASMMMSXXSAM
SMMMSAXMMSMSMAAXMAXAAAMMMSSMMAMAAAAASXMMXAXAXSAMMXXSXMAAASAMAAAMSMAAAAAASMSXASMMMXXAAXMAMXSMSSMASMMMXMAXXMAXSASMMAMSMXMXAXSMMMSSMMSXMASAMMAM
MASAMMSSMSMAXSMMMXMMMMMAAXAMSSMMSMSMMXMASXSAMSAMXAMXXMAMMMXSSSMSAMMSMSMMMAXMAXMASASXMMSMSSSMAXMAXXXXXSXASMMAAAMXMXAXAAMMSMMXAAMAMXSMMMMAMMSM
SAMXSAAMASXMXMMASASXAAXXSSXMAAAAXAAMSMMASXAXMMMMMSMMMAMXAAAMXMXSASMXXMXXMMMSXMXAMAMAMAASXAXMAXMAMSSMXXMAXAXMMXSXMMMMSMSAXAMSSMMMMAXMMXSAMXAS
MXSASXXMAMAXMASASASMSMMSAMXMSSMMMXMMAAMASMMSSXMAAAAXSSSSMSMSXMASAMXSASAMSMASASMXSSSMMSSSMMMASMMAMAAXSASXSMMXXAMAXAAAMAXASMMMAMSXMSSXAXSAXMAS
MSMASXMMSSSMSXMXSAMMXAXMAMXMAXASMSSSMSMAMAMAMASMSSXMAAAXAAXMAMASAXAXMMXMAMXSAMAAAXMXXXMMAMXSAASXMSMMMAMAAMSMMXSSMSXSSMMMMXAXAMAASAMXMMXSMMSX
MAMMMMMAAMAMXMMMMAXAMAXMAMAMAXMXAAAAXMMMSMMASMMXMAMSMMMMSMSSMMMSAMXXSMSXXMAMXMMMSSSXXMAXAMMMMXAXAXAAMXMXMMAASAMAAXXMAXAXMXSXMXXXMASMMMAXXXMA
SASASAMAMMAMAAAXSMMXSSXMAXASXSSMMMMMMXXAAAMXXMXAMXMXAAXXAAXXAAXSXXAASASASMMXSAXMAAMMSSXXASXXMMMMXSSMSAMXXSXSMASMSMMSXMSMSAAASMSMMMMMAMASMMMM
XASAMXSXXXAMSXMMSXAXMAMSSSMSAMMAMXSMXSMMSXSASXSSSSMSSMSSMSMXSSXMMMMMMAMAMXAXMSSMMSMAXAASMMXMXMXMXXXMAXMXMMSMXXMAMMASAAAAMMSMMAAAASASXMSAMXAX
MXMXMMXASXMMMSMAXMSMMSMMXAXMASXSMAAMASAAAAMAMAAMAXMAXXMMMMXMAMAAMXSXMXMMMMMXSAMAAXXMMMMMXAASASAMASAMXAXAXSAMSXMXMMASMMMSMAMXMSMSAMASMMAMXSMS
SAAXMXSXMAXAMAMMXAAMAAAMMAMSXMAAMSSMASMMXMMAMMMMAMMAMXXAAMAMASXMMAMMMXMAXAXXMASMMSAMSSMAMSMSXSXSASMMXMSAXSAMXASXXMXSXXXAAASXXAAXAMSMMSSSMAMS
SMSMXASAXXMAXMMXMSSSSSMMASXSXMMMMAAMASXXSASXSSXMXSMSSSSSSMXSMXXSMAMAMXSXSSSMXXMAMMAMAAXXMMAMXXXMXSAAAMMMMSXMSMMMAMSMMSMAMMSXMMSMMMXAMAAXMAAS
XAAMMXSAMSASXXSAMMAMAAASXMAMSMMAMXXMAXAASMMMAXAMXSAAAXAAAXXMMSSXSSSMSASAAXXASMMSMSMMSSMSXSASMMSXAMMMMSAXAXMAXAASAMAXMAXAMMXMASMAXASMMMMMSMSX
MSMSMXMXMXAMMMMMXSAMMMMSAMXMAMASXSAMXMMMSXMMASXMAMMMXMMMMMAAAXMASMAAMAMMAMMXMAAXXXAAXAXXAMAMAMSMSXAAAMAMXSXSSSMSXXXSXMSMSMAASMSMMXSXMXAMAMMA
MAAAMAMSSMMMXXAMMXAMXXXSMMXSMSAXAMXAXXSAXAXMASMMASMSAXXAXSMMMXMXMSMXMAMXMMSSMMMMASMMSSMMSMMMXMXAMAMMMSAMMMMMAMXXMAXSMMAMAXMMMXAMMMMAMSMSAMXX
SMSMMASAAAAAXXMSASMMMMMMAMXXMMASXXXXXMMMSSMMASAMXSAAXMMMXSXMMXSXMASAXASAAXAASAMMMMMXAMAAMAMXMXMXMAMAASAMAAXMAMXAMXXMASMSAMSASXSSXXMAMMXSAMSX
XMAMMMSMSSMSSMAMASAAAXAAASXAXMAMASXMXSAXAAAXAMXMAMMMAAXMMSAMMMMAXXSMSMSXSMSSMXAAAAXMASMMXAMMXXMASASMXSASMSMMXMMXXMASXMAMXXSASAAXMMSSSMAMMMSA
XMASXAXXMXXAAMAMXSMMMMXXMSXMMMMSAMXSASXSSSMMSXXMAXAXMXSAAMXMAASXMAXXAXMMXAMXXSSSSMSAMXAASXMAXSXMSASMMSMMAXAMAXMASAXMAMMMSASAMMMMAMAMXMAMAASM
XMAMMSMASXMMXMAXXMXSSXSMMSAMAAXMXSAMASAMAMXAAMSMMMSAAAMMMMASXXAAMMMSMSXAXAMMXXMAXAXXAXMMAMXSXSAMXAXMAMAMASAMXSMAMSAMXMAMAAMAMXAASMASXMSSMMXM
SMASAXMAMMMSMSSXSXAMMAAAAXAXSSXSAMASAMAMXMMMXXAAXAAMMMSAAXAMXMSMAAXAASMMSAMXSMMMMMMSMSXAMAXXAMMMSMMMMSXMMMXMXXMAMMXMASXMMXMAXSXSASASMMMAMXSM
XSAMXSMXSAAAXAAASMMSSSMMSSSMAAAMASAMXSXMSXMAMSSXMMSAMXMMMSASXAAMMMSMMMAXAMMASAAXAXXAAMMXMSMMAMSMSAAXMXMXAMSSSMXSSMAMMSSXSMSSMXMAXMXSAMSAMAAS
MMXMAXMASMMSMMMMMAMMAXXXAAMMMMXSAMASMSAMMAMMMAXASAAAAXMAMSAMASXSAMAXAXXMSXMXSXMXXXSMSMAAAMAMAMAAXSMSAASMMSAAAAAMAXSMMXMXSAAXMASXSMMMMMSAMAXA
ASAMXSAMXMAMAXAASXMMMMMSMMMSXXAMXSAMXXAXSASMMASMMASXSAMXXMAXXMAXAXAXMSMXXASXMASMSMAAXXSXSSSMSSSSMXXAMSSMMMMSMMMSAAXASMMAMMMMSAXAAAXMSASMMSMM
XMAXAXMASMASAXSXSAMAXAMAAXAXMMMSAMMSMSXMXASAMXMMSAMXMXXXXMMMSMXSSMSXMAAXSMMASASAAAMAMAMAAAXAXAAAAXSMMMMAAMXXMXXMMMSAMAMXXAAAAMASMMMXMASMAMAS
SSSMSSSXXMAMXMMXMASXMXMSAMXSAAAMASAAAAMSMMMXMAMXSAXXMASXMSMAAMMAAAMMSASMSASXMASXMMSAMAMMMMMXMMMMMMXAAAXSMSAXMAXXXAXAMSXASMMSAXXXAAASAMXMAXMM
MAAAXMMMSMMXSAXASMMXAMXMASAMXMMSSMXSXSASAMAASXSASXMXMAXXAAMSMSMSMMMAMAMAXAMMSXXAXXSASXSAMXXASAXXXXMMMSMMAMASMXSSMMSXMXXMASMXXMASXMMMMXSXSSSM
MSMMMAAAAXSXAAXAMMAMXAAXMMAMXSMXAAMMMMXSAMSXSAMAMAAXMSMMSMXMAXXMAMAAMAMXMMMXMMMMMXSAMXXASMSMXXSMMMSAAXAMXMSMMMMXAXAASXSXAMXMSMMMXMAXMASAXMAS
XXXASXMSSSXMMMMSMMSSMSASXSXMAXMSMMMSXMASXMMAXMMMSMSMMAAMMMXMMMMSMMSSSXSAMSSMXAAAMXMMMMSMMMAMMMAMAAMMSMXMAMMAXSSSMMMSMAXMXSAMAXAAAXXSAAMXMSAM
XSAMXMMMMMAMXSAXASMAAXAAAAMMMXAAXAMXAMAMMXMXXMAXAAAMMSSMASXMAMMAMXAAAASMXAAXXSSSSMSAAAASMSXXAAASMXSAMXAMAMMMMMAAAASAMMMSMSASMXMSMSAMMSMMAMAS
AAMAMXXSASXMAMXMMMMMMMXMAMAAAASMSSSSSMAMMAAXMSASXXMSXMAXAMXXAMSAMSMSMMSXMSSMXAAAAAMSMSMSXSASXMMXAAMXMSXXSXXAAMXMMMMMSAAAASAMMSMAMXXMAMAMSXXM
MAMSXSASAMXMSSMMSAAAAMAXAXSASXMAAAAAAMAMMSSMAAAXXASXMSAMXXSXAMMAMSAMAMXMMXAXAMMSMMMXXAAXAMXMMASMMMMMMSSMXASMMSASMSMXSMSSMMXMAAMXSSMMASAMMSSX
XSSXAAAMXMXMAXAAMMXSASMSSMXAXXMMMMMMSSMSMXMASMSMSMMAMAAXMASMMMSAMMMMSXMAMSMMMXMXMMXXSAMMSAMXSAMAMXASAMAMMAMXASAXAAAMXMAXAMXMSAMMMAAAAMAMXAMX
XXAMAMAMMSAMMMMSSMAXAAXAMAXMMMXXXXSAMXAXMASXMAAMXAXAMMMMMAXAAAAXSXMAMAAMASAMXAMAMXSMMXMXXAMAMASMMMMMASXMMAMMAMAMSMSMAMAXXAXMASAAXSXMASXMMMMX
XXMMMXAAAXXXXAAAAMAMSMMMMSXAAXMAMSMMSMSMSASAMSMSSSSSSXSAMXSSMSSMXAAASAMXASAMSMSASAAAAAXSSXMASXMMASXSXMAASMXAMMXMMAMXXSXASMSMAAXSMMXXMMAMMMMX
MMXASXSMMSSSSSSSSMXXMAMSAXMSMSMSMSAMAXAXMXSAMMMXAAAAAMSAXAMAAXMASMMMMASMXXAMAAXAMMSMMXXAAXSAMAMSAMMXMXSMMMSSXMAAMAMXMAMMXAAMAMMMMXASXSAXMAMS
AAMXSAXSAAAXMAMXAAXMSAMMXSXMAXAAASXMASMMMASAMXMMMMMMMMSMMSSMXXAMMXAAXAXMASXMMSMXMAMMASMMMMMAXAMMASAXAAXASAAMASXSSSSXMXMXMXMXSSMASMMSASAXSAMM
SSSSMMMAMMSMSMSSMMSAMXMMASAMXMSMMMAXAMMSMASMMAMMSXMMSAXXAXAAMMMSMSXSMMMSAMXAAMAMXSXSAAAAASXSSXSMXAXXMASAMMSMMMAAAAMMMASMSASXAAMAMAMMMMMMXASX
XMMAASMSASAASXMAAAMXMAXMAXAMXMXMAXAMMMAAMMMXXAXXMASAMAMMSSXMAAMAMXXMAMXMAXXMMXAMAMAMXSSMSAAXAMXMAMSMSMMXMAAASMSMMMSAMMSASASMSMMSXMSAAAAXSMSM
MXSSMMAXSSMSMASMMMSASMSMMSSMXSASMSSXSASXXSASXSSSSMMXSASAMXXMXXMASXAMAMXSXMXSXXSASMMMAMMXMAXMMAAXAXAASMXMMMSSXAXXMAXXSXMAMXMAMXMXASXXMSMXAAMX
AMXASMXMAXMXMAMXAXSAMXAAAAAMXXASAAAASMXMMMASAMXAASMASAMXSASMSXSASMSAASAMMMXMASMAXAASASASMSAAXSMXMXMXMASXXAMAMSMMMXSAMXSAMXMXMMSMXMAXXAMSMMMX
MXSAMMAMMMSSMMMMXMXXMASMMSMMSMMMMMMMMXMSSMMMAMMXMMXAMMMMMMSAAAXASAMSMMMSAAAMSMMSMSMSAMASAMMXAAMAMXMXMMSMMSMSAAAXAAMAMMSASXMASAAAAXAMMAMMXMAX
AMMSMSXSXAAMAAAMSSSMMAMXAMXAAAXMMAMAMMMAAAASAMMSMSMSXMAAAMMMMSMAMMMAXASMXSXSMAAXAAXXAMSMXMXMSASASAMASXXAAAXASMSMMSMMMASXMAMSMSSSXMMXSAMSMSSS
MXAXMAXXMMMXMMMSAAASMASMXSMSXSMMMAMAXAMSXXMSXSAAAAAMMSMSMSAMSAMXMXXAMXMMMMMAXMMSMSSMMMXAXMXXXASXSXSASASMMSSXXMXAMXASMMSASXMAAXXMXMMASXMAMAAS
XMXMXMSXSSSXSAXMMMMMMASXASXMAMAASMXSSSXXAMMMMXXMSMMSASXAASMMMXSXXSAMXAAAAAXSXMAMAAMAAXXMSMSMSMMMSAMASAMAAAAMMMMSXSMMAMSXMASMSMMSMSMASASMSMMM
MMAMAMAAXAAAMAMXSXMASAMMXXXSASAMXAAXXMAMMMAAXAMXXMASAXMMMMSSXMXMASASXXSSSSXMASAMXMSAMSMMAAAMAAAXMXMAMXSXMSMAAXAMXMASMMSASMMXAAXAAAMMSMMAAAXM
ASASASMMMMMMMMSAMASASAMAMSMMAMMMMMMSAMXMXSSSMXSAMXMMMMMSXAASAMXAMSMMAMXAMXASAMXSSXSAMXMSMSMSSSMSMAMASAMXMAMSSMMSAMXSAMSASXMSSSSMSMSAMXMMSMMM
XSASMSAAMXAXXMMASAMASXMAAAAMAMAAXASAMXAMAMAAAASXSAXASMAAAMXSMAXSAMXMXXMAMSAMASXXMASAMSXAAAXXAAXMMASMMMSASAMAAMASASASAMMXMAMXMAAAAAMXSAMXXMAM
MMXMXSMMSASXMASXMASMMXSASXSMXSXSSMSMXSSSXMSMMMSAMXSMXMAMSAMMASAMXAXXASMXMASMMMXAMXMAAXSMSMMMSMMXSMSXMXSXSMMMSMXSAMASMMSXSAMXMMMSMSMXSXSMASMS
"""

  [<TestMethod>]
  member this.PartOneExample() =
    Assert.AreEqual<int>(18, DayFour.partOne exampleInput)

  [<TestMethod>]
  member this.PartOnePuzzle() =
    Assert.AreEqual<int>(2397, DayFour.partOne puzzleInput)

  [<TestMethod>]
  member this.PartTwoExample() =
    Assert.AreEqual<int>(9, DayFour.partTwo exampleInput)

  [<TestMethod>]
  member this.PartTwoPuzzle() =
    Assert.AreEqual<int>(1824, DayFour.partTwo puzzleInput)
