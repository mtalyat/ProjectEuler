"""
ProjectEuler.net #22

Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.
For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 938 * 53 = 49714.
What is the total of all the name scores in the file?

"""

RESOURCE_PATH = '../Resources/Problem_00022.txt'
CHAR_START = ord('A') - 1

def main():
    # Get names
    with open(RESOURCE_PATH, 'r') as file:
        text = file.read()
    names = [name[1:-1].upper() for name in text.split(',')]
    # Sort the names
    names = list(sorted(names))
    # Score the names
    result = 0
    for i, name in enumerate(names):
        score = 0
        for c in name:
            score += ord(c) - CHAR_START
        score *= i + 1
        result += score
    print(result)
    

if __name__=='__main__':
    main()

