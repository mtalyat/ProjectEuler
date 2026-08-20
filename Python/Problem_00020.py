"""
ProjectEuler.net #20

n! means n * (n - 1) * ... * 3 * 2 * 1.
For example, 10! = 10 * 9 * ... * 3 * 2 * 1 = 3628800,and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
Find the sum of the digits in the number 100!.

"""

def factorial(n: int) -> int:
    result = 1
    for i in range(1, n + 1):
        result *= i
    return result

def main():
    number = factorial(100)
    result = 0
    while number != 0:
        next_number = number // 10
        result += number - next_number * 10
        number = next_number
    print(result)

if __name__=='__main__':
    main()
