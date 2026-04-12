"""
ProjectEuler.net #26

A unit fraction contains  in the numerator. The decimal representation of the unit fractions with denominators  to  are given:


Where  means , and has a -digit recurring cycle. It can be seen that  has a -digit recurring cycle.

Find the value of   for which contains the longest recurring cycle in its decimal fraction part.
"""

COUNT = 1000
DEPTH = 100000
PRINT_ALL = False

def long_division(value, divisor):
	result = ""
	current = 0
	for i in range(DEPTH):
		if value == 0:
			if i <= 1:
				result += '0'
			return result
		current = 0
		while value >= divisor:
			value -= divisor
			current += 1
		result += str(current)
		if i == 0 and DEPTH > 1: result += '.'
		value *= 10
	return result
	
def get_pattern(text):
	# Ignore "0."
	dot_index = text.find('.')
	fixed_text = text[dot_index+1:]
	# Keep checking for loops
	length = len(fixed_text)
	half_length = length // 2
	start = 0
	size = 0
	while start < length:
		#print(f'start={start}', end=' ')
		remaining = length - start
		pattern = True
		# i is the potential size of the pattern
		for i in range(1,remaining//2):
			pattern = True
			#print(f'inc={i}', end=' ')
			# k is the index within the pattern
			for k in range(i):
				# j is the location to check
				#print(f'p_index={k}', end=' ')
				start_ch = fixed_text[start+k]
				#print(f'p_char={start_ch}', end=' ')
				for j in range(start+k,length,i):
					ch = fixed_text[j]
					#print(f'index={j} char={ch}', end=' ')
					if ch != start_ch:
						#print('FAIL',end=' ')
						pattern = False
						break
				if not pattern:
					break
			if pattern:
				#print('PASS',end=' ')
				size = i
				break
			#print()
		if pattern:
			break
		start += 1
	if size == 0:
		return (-1,-1)
	return (start+dot_index+1, size)

def main():
	best_index = 0
	best_size = 0
	for i in range(1, COUNT):
		divisor = float(i)
		value = long_division(1.0, divisor)
		pstart, psize = get_pattern(value)
		if pstart != -1 and psize != -1:
			if psize > best_size:
				best_index = i
				best_size = psize
				print(f'{i}: size={psize}, number={value[:pstart]}({value[pstart:pstart+psize]})')
		
if __name__=='__main__':
	main()