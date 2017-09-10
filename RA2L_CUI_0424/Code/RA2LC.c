#include<stdio.h>
#include<windows.h>

void about();

int main(void)
{
	system("title RA2 Launcher");
	system("color 4E");
	system("mode con cols=29 lines=18");
	
	launcher();
}

void launcher()
{
	int input=100;
	
	while(input)
	{
		input=100;
		
		printlist();
		
		
		switch(input=getch())				//等待键盘按下一个字符
		{
			case 49: system("start ra2.exe -speedcontrol"); break;
			case 43: system("start ra2.exe -win -speedcontrol"); break;
		
			case 50: system("start ra2md.exe -speedcontrol"); break;
			case 45: system("start ra2md.exe -win -speedcontrol"); break;
	
			case 51: system("taskkill /f /im ra2.exe"); system("taskkill /f /im game.exe"); system("cls"); break;
			case 52: system("taskkill /f /im ra2md.exe"); system("taskkill /f /im gamemd.exe"); system("cls"); break;

			case 57: about(); break;		//57 == 9
			
			case 48: exit(0); break;
			case 27: exit(0); break;		//27 == ESC
		}
	}
}

void printlist()
{
	system("cls");
	printf("┍━━━━━━━━━━━━┑\n");
	printf("│      Red Alert 2       │\n");
	printf("┕━━━━━━━━━━━━┙\n");

	printf("     \n");
	printf("     1.Launch RA2\n");
	printf("     +.Launch RA2 -win\n");
	printf("     2.Launch YR\n");
	printf("     -.Launch YR  -win\n");
	printf("     \n");
	printf("     3.Exit RA2\n");
	printf("     4.Exit YR\n");
	printf("     \n");
	printf("     9.Help\n");
	printf("     0.Exit\n");
	printf("     \n");
	printf("  ━━━━━━━━━━━━  \n");
	printf("     →Input ");
}

void about()
{
	
	system("cls");
	printf("*         Help        *\n");
	printf("\n");
	printf("* -speedcontrol enabled.\n");
	printf("\n");
	system("pause");
	system("cls");
}

void ifexit()
{
	int input;
	input=getch();//等待键盘按下一个字符
		if(input==27)//如果是ESC则悔棋或退出
		exit(0);
}
