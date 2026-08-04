"""
ProjectEuler.net #15

Starting in the top left corner of a 2 * 2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
How many such routes are there through a 20 * 20 grid?

"""

from collections import deque

GRID_SIZE = 20
SIZE = GRID_SIZE + 1

def main():
    values = [0] * (SIZE*SIZE)
    def get_value(x, y):
        nonlocal values
        global SIZE
        return values[y * SIZE + x]
    def set_value(x, y, value):
        nonlocal values
        global SIZE
        values[y * SIZE + x] = value
    # Set all values on the same row/col as the target to 1, since it is 1 path only for all those positions
    for i in range(SIZE):
        set_value(i, 0, 1)
        set_value(0, i, 1)
    # Propagate the rest of the grid
    for y in range(1, SIZE):
        for x in range(1, SIZE):
            v = get_value(x-1, y)
            v += get_value(x, y-1)
            set_value(x, y, v)
    # Final answer in 'top-right' position
    result = values[-1]
    print(result)
if __name__=='__main__':
    main()
