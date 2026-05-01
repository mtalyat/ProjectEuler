"""
ProjectEuler.net #5

2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
What is the smallest positive number that is evenly divisible with no remainder by all of the numbers from 1 to 20?

Need to iterate and check each value until one is found.
We only need to check values that are not a factor if another value in the set. For example: If a number is divisible by 16, then we know it is also divisible by 8, 4 and 2.
Okay, after looking into it: this is only the top half of the range. This can be simplified.
"""

BIG_NUMBER = 1_000_000_000
RANGE_MAX = 20

def main():
	result = 0
	for i in range(1,BIG_NUMBER):
		found = True
		for j in range(RANGE_MAX//2+1,RANGE_MAX+1):
			if i % j != 0:
				found = False
				#print(f'FAIL {i}')
				break
		if found:
			#print(f'PASS {i}')
			result = i
			break
	print(result)
		
		
if __name__=='__main__':
	main()