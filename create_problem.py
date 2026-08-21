import os
import sys

def main():

    language = input('Enter language name: ')
    number = input('Enter problem number: ')
    padded_number = number.zfill(5)
    
    problem_fn = f'Problem_{padded_number}.txt'
    resource_path = f'Resources/{problem_fn}'
    
    # Check if there are resources for this problem
    has_resources = os.path.exists(resource_path)
    
    # Get problem text
    with open(f'Problems/{problem_fn}', 'r') as f:
        problem_text = f.read()
        
    # Find template
    template_file = None
    for root, dirs, files in os.walk(f'{language}/'):
        for file in files:
            fn = os.path.splitext(file)[0]
            if fn.startswith('TEMPLATE'):
                if not has_resources or fn.endswith('_R'):
                    template_file = file
                    break
    
    # No template?
    if template_file is None:
        print('No appropriate template found.')
        return
    
    # Get template text for langauge
    with open(f'{language}/{template_file}', 'r') as f:
        template_text = f.read()
    
    # Replace placeholders in template
    code_text = template_text.replace('{NUMBER}', number).replace('{PROBLEM_TEXT}', problem_text).replace('{RESOURCE}', f'../{resource_path}')
    
    # Create the new file
    extension = os.path.splitext(template_file)[1]
    file_path = f'{language}/Problem_{padded_number}{extension}'
    create_file = True
    if os.path.exists(file_path):
        create_file = input(f'A problem file already extists for {number}, would you like to overwrite it? y/n: ') != 'n'
    with open(file_path, 'w') as f:
        f.write(code_text)
        
    # Done!
    print(f'Created {file_path}.')

if __name__ == '__main__':
    main()
