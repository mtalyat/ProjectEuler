"""
ProjectEuler.net #4

A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 * 99.
Find the largest palindrome made from the product of two 3-digit numbers.

In this problem, my solution is to start at 999 and fond the largest palindrome pair from there.
Each time we only need to check values higher than what has already been found.
"""

def is_palindrome(text):
	length = len(text)
	for i in range(length // 2):
		left = text[i]
		right = text[length - 1 - i]
		if left != right:
			return False
	return True

def main():
	best = 0
	for left in range(999, 1, -1):
		for right in range(999, 1, -1):
			number = left * right
			if number <= best:
				break
			number_text = str(number)
			if is_palindrome(number_text):
				best = number
	print(best)
		
if __name__=='__main__':
	main()