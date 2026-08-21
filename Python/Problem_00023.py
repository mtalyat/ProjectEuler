"""
ProjectEuler.net #23

A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.
As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.
Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.

"""

from Utility import create_list_divisors

SIZE = 28123 + 1

def main():
    # Get all divisors once
    divisors = create_list_divisors(SIZE, False)
    # Get abundant numbers list
    abundants = []
    for i, d in enumerate(divisors[1:], 1):
        s = sum(d)
        if s > i:
            abundants.append(i)
    # Add each abundant to every other abundant, then remove that from the non-abundants
    nonabundants = set(list(range(SIZE)))
    for ai, a in enumerate(abundants):
        for bi in range(ai, len(abundants)):
            b = abundants[bi]
            s = a + b
            if s in nonabundants:
                nonabundants.remove(s)
    # Sum non-abundants
    result = sum(nonabundants)
    print(result)

if __name__=='__main__':
    main()

