"""
ProjectEuler.net #21

Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
If d(a) = b and d(b) = a, where a != b, then a and b are an amicable pair and each of a and b are called amicable numbers.
For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
Evaluate the sum of all the amicable numbers under 10000.

"""

TARGET = 10000
SIZE = TARGET + 1

def main():
    # Create initial proper divisors of 1 (without n)
    divisors = [[1] for _ in range(SIZE)]
    # For each n, check for pair if sum of divisirs < n and add to total if there is a pair, then add self to divisors of multiples larger than n
    sums = [0] * SIZE
    sums[1] = 1
    result = 0
    for n in range(2, TARGET):
        s = sum(divisors[n])
        sums[n] = s
        if s < n and sums[s] == n:
            result += n
            result += s
        for m in range(n+n, TARGET, n):
            divisors[m].append(n)
    print(result)

if __name__=='__main__':
    main()

