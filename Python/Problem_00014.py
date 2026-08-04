"""
ProjectEuler.net #14

The following iterative sequence is defined for the set of positive integers:
n -> n/2 (n is even)
n -> 3n + 1 (n is odd)
Using the rule above and starting with 13, we generate the following sequence:
13 -> 40 -> 20 -> 10 -> 5 -> 16 -> 8 -> 4 -> 2 -> 1.
It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
Which starting number, under one million, produces the longest chain?
NOTE: Once the chain starts the terms are allowed to go above one million.

"""

def next(n: int) -> int:
    if n & 1 == 0: # even
        return n >> 1 # n/2
    else:
        return (n << 1) + n + 1 # 3n + 1
        
MAXIMUM = 1000000

def main():
    chains = dict()
    current = list()
    longest = 0
    result = 0
    for i in range(1, MAXIMUM):
        number = i
        current.clear()
        length = 0
        while number > 1:
            # If number has already been encountered, re-use the chain length
            if number in chains:
                length = chains[number]
                break
            # Add to list so it can be updated in the chains dict later with the length
            current.append(number)
            length += 1
            # Move on to the next number
            number = next(number)
        # Add all new numbers to the chains dict with the appropriate length
        for number in reversed(current):
            length += 1
            chains[number] = length
            if length > longest:
                longest = length
                result = number
    print(result)

if __name__=='__main__':
    main()
