"""
ProjectEuler.net #6

The sum of the squares of the first ten natural numbers is,

1² + 2² + ... 10² = 385


The square of the sum of the first ten natural numbers is,

(1 + 2 + ... + 10)² = 3025


Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 - 385 = 3025

Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
"""

COUNT = 100

def main():
	sumOfSquares = 0
	squareOfSum = 0
	
	for i in range(1, COUNT + 1):
		sumOfSquares += i * i
		squareOfSum += i
	squareOfSum *= squareOfSum
	result = squareOfSum - sumOfSquares
	print(result)

if __name__=='__main__':
	main()