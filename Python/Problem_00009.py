"""
ProjectEuler.net #9

A Pythagorean triplet is a set of three natural numbers, a < b < c, for which, a^2 + b^2 = c^2.

For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
There exists exactly one Pythagorean triplet for which a + b + c = 1000. Find the product abc.

The easiest way to find a triplet that matches the given criteria is to calculate a and b, then subtract those from the target count to find c. After that, just keep checking if it is a match!
"""

TARGET = 1000

def main():
	result = 0
	for b in range(2, TARGET+1):
		for a in range(1,b):
			c = TARGET - b - a
			if b >= c:
				continue
			if a * a + b * b == c * c:
				result = a * b * c
		if result != 0:
			break
	print(result)
			
				
		
if __name__=='__main__':
	main()