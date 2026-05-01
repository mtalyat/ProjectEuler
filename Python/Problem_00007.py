"""
ProjectEuler.net #7


By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the th prime is .
13.

What is the 10,001st prime number?

We can check if a number is prime by seeing if it is divisible by any previous prime number. If it is, it is not prime.
"""

TARGET = 10001

def is_prime(num: int, primes: list[int]):
	for prime in primes:
		if num % prime == 0:
			return False
	return True

def main():
	primes = [2]
	i = 3
	INC = 2 # Skip evens, except for 2, which halves the number of values to check
	while len(primes) < TARGET:
		if is_prime(i, primes):
			primes.append(i)
		i += INC
	print(primes[-1])
		

if __name__=='__main__':
	main()