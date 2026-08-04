"""
ProjectEuler.net #10

The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
Find the sum of all the primes below two million.

"""

import math

TARGET = 2_000_000

def is_prime(num: int, primes: list[int]):
    limit = math.sqrt(num)
    for prime in primes:
        if num > limit and num >= 3:
            break
        if num % prime == 0:
            return False
    return True

def main():
    is_prime = [True] * TARGET
    is_prime[0] = False
    is_prime[1] = False
    total = 0
    limit = int(math.ceil(math.sqrt(TARGET)))
    
    # Iterate over all numbers under the sqrt
    for i in range(2, limit+1):
        # If not prime, ignore it
        if not is_prime[i]:
            continue
        # If it is prime, set all multiples down the road to not prime
        for m in range(i*i, TARGET, i):
            is_prime[m] = False
        # Add this prime number to the total
        total += i
    # Iterate over all numbers after the sqrt
    for i in range(limit+1,TARGET):
        # If number is prime, add number to the total
        if is_prime[i]:
            total += i
    print(total)

if __name__=='__main__':
    main()
