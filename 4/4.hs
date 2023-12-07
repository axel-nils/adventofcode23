module Four where

import Data.List
import Data.Maybe (fromMaybe)
import qualified Data.List as List

wordsWhen :: (Char -> Bool) -> String -> [String]
wordsWhen p s =  case dropWhile p s of
                      "" -> []
                      s' -> w : wordsWhen p s''
                            where (w, s'') = break p s'

dropStart :: String -> String
dropStart x = drop (2 + fromMaybe 0 (elemIndex ':' x)) x

extractWinning :: String -> String
extractWinning x = take (-1 + fromMaybe 0 (elemIndex '|' x)) x

extractNumbers :: String -> String
extractNumbers x = drop (1 + fromMaybe 0 (elemIndex '|' x)) x

readLines = fmap lines . readFile

stringToList :: String -> [Int]
stringToList = map read . words

main = do
    x <- readLines "4.txt"
    let b = List.map dropStart x
    let w = List.map (stringToList . extractWinning) b
    let n = List.map (stringToList . extractNumbers) b
    let c = zip w 
    return c