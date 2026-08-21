def create_list_divisors(limit: int, include_n: bool = False) -> list[list[int]]:
    # Create divisors lists, auto populate with 1 since every number will have 1
    divisors = [[1] for _ in range(limit)]
    # For 2 plus, add the n to each list of divisors after n
    for n in range(2, limit):
        offset = 0 if include_n else n
        for m in range(n + offset, limit, n):
            divisors[m].append(n)
    return divisors
