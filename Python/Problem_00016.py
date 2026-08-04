"""
ProjectEuler.net #16

2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
What is the sum of the digits of the number 2^1000?


"""

EXPONENT = 1000

def main():
    value = 2 ** EXPONENT
    text = str(value)
    result = 0
    for c in text:
        result += int(c)
    print(result)

if __name__=='__main__':
    main()
