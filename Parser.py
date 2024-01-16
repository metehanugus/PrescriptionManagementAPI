import pandas as pd
import random
import os

# Path to your Excel file
excel_file_path = 'C:/Users/meteh/Desktop/PrescriptionManagementAPI/PrescriptionManagementAPI/example-data-from-the-source.xlsx'

# Reading data from Excel
data = pd.read_excel(excel_file_path)
medicines_from_excel = data['İlaç Adı'].dropna().unique()

# Ensure at least 1000 unique medicines
if len(medicines_from_excel) < 1000:
    extra_medicines_needed = 1000 - len(medicines_from_excel)
    repeated_medicines = list(medicines_from_excel)[:extra_medicines_needed]
    medicines = list(medicines_from_excel) + repeated_medicines
else:
    medicines = list(medicines_from_excel)[:1000]

# Function to generate a random price
def generate_random_price():
    return round(random.uniform(10, 500), 2)

# Generating prices for each medicine
medicine_price_data = [(medicine, generate_random_price()) for medicine in medicines]

# Creating SQL insert statements
insert_statements = [
    "INSERT INTO Medicines (Name, Price) VALUES ('{}', {});".format(name.replace("'", "''"), price)
    for name, price in medicine_price_data
]

# Directory of the source Excel file
source_directory = os.path.dirname(excel_file_path)

# SQL file path in the same directory as the source file
sql_file_path = os.path.join(source_directory, 'medicine_inserts.sql')

# Writing the statements to the SQL file
with open(sql_file_path, 'w', encoding='utf-8') as file:
    for statement in insert_statements:
        file.write(statement + "\n")


