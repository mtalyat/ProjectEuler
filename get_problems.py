"""
Helper script to get problems from Project Euler and create files for them in the appropriate language directories.
"""

import re
import os
import requests
import sys

PROJECT_EULER_URL = 'https://projecteuler.net/minimal='
TEMPLATE_FILE_NAME = 'TEMPLATE'

def get_problem_text(number) -> str:
    url = f'{PROJECT_EULER_URL}{number}'
    response = requests.get(url)
    if response.status_code != 200:
        return None

    html_text = response.text
    
    # Remove HTML tags (anything between < and >)
    text = re.sub(r'<[^>]+>', '', html_text)
    
    # Remove dollar signs
    text = text.replace('$', '')

    # Replace '\dots' with '...'
    text = text.replace('\\dots', '...')

    # Trim leading and trailing whitespace
    text = text.strip()
    
    return text

def get_problem(number, language, template, extension) -> bool:
    # Identify the output file
    new_file_name = f'Problem_{number:05d}{extension}'
    new_file_path = os.path.join(language, new_file_name)

    # If it already exists, skip it
    if os.path.exists(new_file_path):
        return True

    # Get the problem text from a loaded file
    text_path = f'Problems/Problem_{number:05d}.txt'
    if os.path.exists(text_path):
        with open(text_path, 'r') as text_file:
            text = text_file.read()
    else:
        return False
    
    # Replace the placeholders in the template with the problem number and text
    file_text = template
    file_text = file_text.replace('{NUMBER}', str(number))
    file_text = file_text.replace('{PROBLEM_TEXT}', text)

    # Create a new file for the problem
    with open(new_file_path, 'w') as new_file:
        new_file.write(file_text)

    return True

def get_template(language) -> str:
    # Find the template file within the language directory
    template_path = None
    for dirpath, dirnames, filenames in os.walk(language):
        for file in filenames:
            if os.path.splitext(file)[0] == TEMPLATE_FILE_NAME:
                 template_path = os.path.join(dirpath, file)
                 break
            
    if template_path is None:
        return None, None
    
    # Get the file extension from the template file
    _, file_extension = os.path.splitext(template_path)
    
    # Read the template file
    with open(template_path, 'r') as template_file:
        template = template_file.read()

    return template, file_extension

def load_problem(number):
    problem_text = get_problem_text(number)
    if problem_text is None:
        return False
    
    with open(f'Problems/Problem_{number:05d}.txt', 'w') as problem_file:
        problem_file.write(problem_text)

    return True

def load_problems(max_number):
    number = 1
    while number <= max_number:
        path = f'Problems/Problem_{number:05d}.txt'
        if os.path.exists(path):
            print(f'Problem {number} already exists, skipping')
            number += 1
            continue
        if not load_problem(number):
            print(f'Finished loading problems. Last problem number: {number - 1}')
            break
        print(f'Got problem {number}')
        number += 1

def main():
    number = int(sys.argv[1]) if len(sys.argv) > 1 else None
    language = sys.argv[2] if len(sys.argv) > 2 else None

    if language is None:
        load_problems(number)
    else:
        template, extension = get_template(language)
        if template is None:
            print(f'No template found for language {language}')
            return
        
        if get_problem(number, language, template, extension):
            print(f'Got problem {number} for language {language}')
            return
        else:
            print(f'Problem {number} does not exist or could not be loaded')
            return

if __name__=='__main__':
    main()