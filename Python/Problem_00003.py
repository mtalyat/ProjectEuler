"""
ProjectEuler.net #3

The prime factors of 13195 are 5, 7, 13 and 29.
What is the largest prime factor of the number 600851475143?
"""

# NUMBER = 13195
NUMBER = 600851475143

def main():
	n = NUMBER
	factor = 2
	while factor * factor <= n:
		if n % factor == 0:
			n //= factor
		else:
			factor += 1
	print(n)
		
if __name__=='__main__':
	main()