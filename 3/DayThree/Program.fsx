
open System.IO

// alt enter to run selection
type path = string
type row = string
type schematic = List<row>

let charIsNum a  = 
    List.contains a ['0'; '1'; '2'; '3'; '4'; '5'; '6'; '7'; '8'; '9']

let charIsSymbol (a: char) =
    (not (charIsNum a)) && (not(a = '.')) 

let stringIsSymbol (a: string) =
    a |> char |> charIsSymbol

let readLines (filePath: path) = seq {
    use sr = new StreamReader (filePath)
    while not sr.EndOfStream do
        yield sr.ReadLine ()
}

let listLines (file: path) : schematic = [for (line: row) in (readLines file) -> line]

let input = listLines "3.txt"
input |> Seq.iter(fun x -> printfn "%s" x) 

let smallInput : schematic = 
    ["467..114..";
     "...*......";
     "..35..633.";
     "......#...";
     "617*......";
     ".....+.58.";
     "..592.....";
     "......755.";
     "...$.*....";
     ".664.598.."]

let dims matrix = (List.length matrix, matrix[0] |> Seq.toList |> List.length)

let extend (r: row) = failwith "Not implemented"

let rec extendLeft (r: row) (i: int) : int = 
    match i with
    | 0 -> i
    | _ -> if charIsNum r[i-1] then extendLeft r i else i

let rec extendRight (r: row) (i: int) (l: int): int = 
    match i with
    | l -> i
    | _ -> if charIsNum r[l+1] then extendRight r i l else i
    

let testString = ['4'; '.'; '3'; '2'; '0';]
let charTest = testString |> Seq.map charIsSymbol |> Seq.fold (fun x y -> x || y) false