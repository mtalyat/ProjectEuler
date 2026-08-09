"""
ProjectEuler.net #19

You are given the following information, but you may prefer to do some research for yourself.
1 Jan 1900 was a Monday.
Thirty days has September,
April, June and November.
All the rest have thirty-one,
Saving February alone,
Which has twenty-eight, rain or shine.
And on leap years, twenty-nine.
A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?


"""

# How many days per month
DAYS_PER_MONTH = [
    31,
    28,
    31,
    30,
    31,
    30,
    31,
    31,
    30,
    31,
    30,
    31
]
# Change of weekday per month
WEEKDAY_PER_MONTH = [
    d % 7 for d in DAYS_PER_MONTH
]
DAYS_PER_WEEK = 7
MONTHS_PER_YEAR = 12
# Number of days to check
TARGET_DAYS = 1 * 100 * 365 - 1
# Target day of week to count
TARGET_WEEKDAY = 6

def main():
    weekday = 0 # 0 = Monday
    days = 0
    year = 0
    month_index = 0
    count = 0
    while days <= TARGET_DAYS:
        # Add to total days, account for new year
        if month_index == 1 and year % 4 == 0:
            days += 29
        else:
            days += DAYS_PER_MONTH[month_index]
        # Calculate day of week
        weekday = (weekday + WEEKDAY_PER_MONTH[month_index]) % DAYS_PER_WEEK
        
        # Count of correct day
        if weekday == TARGET_WEEKDAY:
            count += 1
        
        # Move on to next month
        month_index = (month_index + 1) % MONTHS_PER_YEAR
    print(count)

if __name__=='__main__':
    main()
