"""
ProjectEuler.net #17

If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used? 
NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of "and" when writing out numbers is in compliance with British usage.


"""

ONES = [
    "one",
    "two",
    "three",
    "four",
    "five",
    "six",
    "seven",
    "eight",
    "nine",
    "ten",
    "eleven",
    "twelve",
    "thirteen",
    "fourteen",
    "fifteen",
    "sixteen",
    "seventeen",
    "eighteen",
    "nineteen"
]
TENS = [
    "twenty",
    "thirty",
    "fourty",
    "fifty",
    "sixty",
    "seventy",
    "eighty",
    "ninety"
]
AND = "and"
HUNDRED = "hundred"
THOUSAND = "thousand"

def main():
    # In retrospect, this could be solved completely using math...
    lengths = dict()
    total_length = 0
    index = 1
    def add_length(number, length):
        nonlocal lengths, total_length
        lengths[number] = length
        total_length += length
    # Calculate length for <= 19 since they are special (1...19)
    for n in ONES:
        add_length(index, len(n))
        index += 1
    # Calculate tens (20...99)
    for n in TENS:
        length = len(n)
        add_length(index, length)
        index += 1
        for one in range(1, 10):
            add_length(index, length + lengths[one])
            index += 1
    # Calculate hundreds (100...999)
    for n in range(1, 10):
        length = lengths[n] + len(HUNDRED)
        add_length(index, length)
        index += 1
        # account for "and"
        length += len(AND)
        for i in range(1, 100):
            add_length(index, length + lengths[i])
            index += 1
    # One thousand
    add_length(index, lengths[1] + len(THOUSAND))
    print(total_length)
    
if __name__=='__main__':
    main()
