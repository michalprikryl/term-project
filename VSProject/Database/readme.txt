update se dela v Tools –> NuGet Package Manager –> Package Manager Console

pozor - maze puvodni soubory

nutne mit jako Default project projekt Database (primo v selectboxu v okne)

zada se (samozrejme spravny nazev serveru) ->
Scaffold-DbContext "Server=MICHAL-PC3;Database=TermProject;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -Output tmp/DBObjects [-t nazevTabulky] [-f]

-f = with force

vytvori to i tridu TermProjectContext a tu je potreba smazat

nutne vzdy obnovit CELY DB model!