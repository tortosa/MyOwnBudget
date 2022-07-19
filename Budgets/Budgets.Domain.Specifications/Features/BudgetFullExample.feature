Feature: BudgetFullExample

Simulating a real complex budget example to detect missing things in domain previous to create different layers

Background:
	Given Accounts
		| Id | Label           |
		| 1  | General Account |
	And Payees
		| Id | Label   |
		| 1  | Payee 1 |
		| 2  | Payee 2 |

Scenario: ComplexCase 
	Given Budgets
		| Id | Label    | DateFormat | Currency |
		| 1  | MyBudget | dd/MM/yyyy | EUR      |
	And GroupCategory associated to budgets
		| Id | BudgetId | Label         |
		| 1  | 1        | Subscriptions |
		| 2  | 1        | Vehicles      |
		| 3  | 1        | Savings       |
	And Category associated to GroupCategory
		| Id | GroupCategoryId | Label               |
		| 1  | 1               | Asisa               |
		| 2  | 1               | Netflix             |
		| 3  | 1               | Amazon Music        |
		| 4  | 1               | Amazon Prime        |
		| 5  | 1               | PlayStation Network |
		| 6  | 2               | Kia Ceed Insurance  |
		| 7  | 2               | Honda PCX Insurance |
		| 8  | 2               | IVTM Honda PCX      |
		| 9  | 2               | IVTM Kia Ceed       |
		| 10 | 3               | Holidays            |
		| 11 | 3               | Christmas           |
		| 12 | 3               | Bicycle             |
	When Transaction is added to MyBudget on 16/05/2022 to Account General Account, Payee Payee 1, Category Asisa with and amount of 100.12 - EUR
	And Transaction is added to MyBudget on 18/05/2022 to Account General Account, Payee Payee 2, Category Amazon Prime with and amount of 49.88 - EUR
	And Assign an amount of 49.88 - EUR at June/2022 to Category Amazon Prime
	Then GroupCategory with label Subscriptions should have 199.88 available at June/2022
	And GroupCategory with label Vehicles should have 0.00 available at June/2022
	Then Category with label Asisa should have 100.12 available at June/2022
	And Category with label Amazon Prime should have 49.88 available at May/2022
	Then GroupCategory with label Subscriptions should have 49.88 assigned	
	And Category with label Asisa should have 0.00 assigned at June/2022
	And Category with label Amazon Prime should have 49.88 assigned at June/2022