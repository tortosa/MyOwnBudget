Feature: BudgetFullExample

Simulating a real complex budget example to detect missing things in domain previous to create different layers

Scenario: MayJunExample
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
	When MyBudget is actioned
	Then GroupCategory Subscriptions should have 1000.52 EUR assigned
	Then GroupCategory Subscriptions should have 1000.52 EUR available
	Then Category Asisa should have 41.34 EUR assigned
	Then Category Asisa should have 1.34 EUR available