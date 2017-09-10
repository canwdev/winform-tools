#include<stdio.h>
#include<windows.h>

void about();

int main(void)
{
	int select=1;

	system("title RA2L C!");
	system("color 4E");
	system("mode con cols=29 lines=16");
	
	while(select)
	{
	printf("============================\n");
	printf("      RA2 Launcher C    \n");
	printf("============================\n");

		printf("    \n");
		printf("    1.Launch RA2\n");
		printf("    2.Launch YR\n");
		printf("    \n");
		printf("    3.Exit RA2\n");
		printf("    4.Exit YR\n");
		printf("    \n");
		printf("    9.Help\n");
		printf("    0.Exit\n");
		printf("    \n");


	printf("============================\n");
		printf("    !.Select: ");
		scanf("%d",&select);

		system("cls");

		switch(select)
		{
		case 1: system("start ra2.exe -speedcontrol"); break;
		case 11: system("start ra2.exe -win -speedcontrol"); break;
		case 2: system("start ra2md.exe -speedcontrol"); break;
		case 22: system("start ra2md.exe -win -speedcontrol"); break;

		case 3: system("taskkill /f /im ra2.exe"); system("taskkill /f /im game.exe"); system("cls"); break;
		case 4: system("taskkill /f /im ra2md.exe"); system("taskkill /f /im gamemd.exe"); system("cls"); break;

		case 9: about(); break;

		case 0: return 0; break;

		//default: return 0;
		}
	}
}

void about()
{
	system("cls");
	printf("============================\n");
	printf("           Help        \n");
	printf("============================\n");
	printf("* \"11\",\"22\" launch in window.\n");
	printf("* -speedcontrol enabled.\n");
	printf("\n");
	printf("* w 2016.4 in C.\n");
	printf("\n");
	printf("\n");
	printf("\n");
	system("pause");
	system("cls");
}