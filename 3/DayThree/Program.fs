
open System.IO

// alt enter to run selection
type path = string
type row = string
type schematic = List<row>

let readLines (filePath: path) = seq {
    use sr = new StreamReader (filePath)
    while not sr.EndOfStream do
        yield sr.ReadLine ()
}

let listLines (file: path) : schematic = [for (line: row) in (readLines file) -> line]

let input = listLines "DayThree/3.txt"
input |> Seq.iter(fun x -> printfn "%s" x) 



let charIsNum a  = 
    List.contains a ['0'; '1'; '2'; '3'; '4'; '5'; '6'; '7'; '8'; '9']

let charIsSymbol (a: char) =
    (not (charIsNum a)) && (not(a = '.')) 

let stringIsSymbol (a: string) =
    a |> char |> charIsSymbol




let testString = ['4'; '.'; '3'; '2'; '0';]
let charTest = testString |> Seq.map charIsSymbol |> Seq.fold (fun x y -> x || y) false