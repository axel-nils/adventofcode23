
valid = {"zero": 0, "one": 1, "two": 2, "three": 3, "four": 4, "five": 5, "six": 6, "seven": 7 , "eight": 8, "nine": 9}
valid_reverse = {}

for key in valid:
    valid_reverse[key[::-1]] = valid[key]

print(valid_reverse)

def get_first_num(s: str) -> int:
    for c in s:
        if c.isdigit():
            return int(c)

def get_first_str_num(s: str, d: dict):
    for i, c in enumerate(s):
        subs = []
        if i < 3:
            subs.append(s[0:i+1])
        elif i == 3:
            subs.append(s[0:i+1])
            subs.append(s[1:i+1])
        elif i == 4:
            subs.append(s[0:i+1])
            subs.append(s[1:i+1])
            subs.append(s[2:i+1])
        else:
            subs.append(s[i-4:i+1])
            subs.append(s[i-3:i+1])
            subs.append(s[i-2:i+1])
        for sub in subs:
            if sub in d:
                return d[sub]
        if c.isdigit():
            return int(c)
    return None


def main():
    with open("1/1.txt") as f:
        lines: list = f.readlines()
    
    sum = 0
    for line in lines:
        tens = get_first_str_num(line, valid)
        ones = get_first_str_num(line[::-1], valid_reverse)
        val = 10 * tens + ones
        sum += val
    
    print(sum)


if __name__ == "__main__":
    main()