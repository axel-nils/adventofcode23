
open System.IO

// alt enter to run selection
type path = string
type row = string
type schematic = List<row>

let charIsNum a  = 
    List.contains a ['0'; '1'; '2'; '3'; '4'; '5'; '6'; '7'; '8'; '9']

let charIsSymbol (a: char) =
    (not (charIsNum a)) && (not(a = '.')) 

let readLines (filePath: path) = seq {
        use sr = new StreamReader (filePath)
        while not sr.EndOfStream do
            yield sr.ReadLine ()
}
let input: schematic = readLines "3.txt" |> Seq.toList

let rec extendLeft (r: row) (i: int) : int = 
    match i with
    | 0 -> i
    | x when charIsNum r[x-1] -> extendLeft r (x-1)
    | x -> x

let rec extendRight (r: row) (i: int): int = 
    match i with
    | x when x = r.Length-1 -> x
    | x when charIsNum r[x+1] -> extendRight r (x+1)
    | x -> x
    
let extend (r: row) (i: int) =
    (extendLeft r i, extendRight r i)

let surroundings (s: schematic) (i: int) (a, b) =
    List.allPairs  [for x in [(if i > 0 then i-1 else i)..(if i < (s.Length-1) then i+1 else i)] -> x] [for x in [(if a > 0 then a-1 else a)..(if b < (s[i].Length-1) then b+1 else b)] -> x]

let checkSurronding (s: schematic) ls =
    [for l in ls -> s[fst l][snd l]] 
    |> List.fold (fun acc elem -> charIsSymbol elem || acc) false 

let sumNum (r: row) (a: int, b: int) = 
    List.map (fun (n, p) -> (10.0 ** p) * n ) [for x in [a..b] -> (float(string(r[x])), float(b-x))]
    |> List.sum |> int

let sumRow (s: schematic) (r: int) =
    [0..s[r].Length-1] 
    |> List.filter (fun x -> charIsNum (s[r][x])) 
    |> List.map (extend (s[r])) 
    |> List.distinct 
    |> List.filter (fun x ->(surroundings s r x |> checkSurronding s))
    |> List.map (sumNum s[r])
    |> List.sum

let sumSchematic (s: schematic) =
    [0..s.Length-1] |> List.map (sumRow s) |> List.sum

printfn "%d" (sumSchematic input)