#include<stdio.h>
#include<windows.h>

void about();

int main(void)
{
	system("title 红警2启动器");
	
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
			case 99: matrix();break;
			case 48: exit(0); break;
			case 27: exit(0); break;		//27 == ESC
		}
	}
}

void printlist()
{
	system("mode con cols=29 lines=18");
	system("color 4E");
	system("cls");
	printf("┍━━━━━━━━━━━━┑\n");
	printf("│      Red Alert 2       │\n");
	printf("┕━━━━━━━━━━━━┙\n");

	printf("     \n");
	printf("     1.启动 红警2\n");
	printf("     +.启动 红警2窗口模式\n");
	printf("     2.启动 尤里的复仇\n");
	printf("     -.启动 尤里窗口模式\n");
	printf("     \n");
	printf("     3.结束 红警2\n");
	printf("     4.结束 尤里的复仇\n");
	printf("     \n");
	printf("     9.帮助\n");
	printf("     0.退出\n");
	printf("     \n");
	printf("  ━━━━━━━━━━━━  \n");
	printf("     →输入 ");
}

void about()
{
	
	system("cls");
	printf("*         帮助        *\n");
	
	printf("\n");
	printf("* 把此程序放在红警2文件夹内\n");
	printf("* 建议以管理员身份运行此程序\n");
	printf("* 窗口模式需16位色\n");
	printf("* 游戏在任务中可以调速\n");
	printf("\n");
	colors();
	system("pause");
	system("cls");
}

void matrix()
{
	HWND hwnd=GetForegroundWindow();
	int x=GetSystemMetrics(SM_CXSCREEN)+300,y=GetSystemMetrics(SM_CYSCREEN)+300;
	char setting[30];
	sprintf(setting,"mode con:cols=%d lines=%d",x,y);//设置控制台行数列数
	system(setting); 
	SetWindowPos(hwnd, HWND_TOPMOST,0,0,x+300,y+300,NULL);//置顶
	MoveWindow(hwnd,-10,-40,x+300,y+300,1);//移动
	
	int i;
	system("title matrix");
    system("date /T");
    system("TIME /T");
    system("color 0A");
    printf("╔═════════════════╗\n");
    printf("║※         M A T R I X          ※║\n");
    printf("╚═════════════════╝\n");
    system("color 0A");
    printf("Input:");
    //sleep(1); 
    colors();
    scanf("%ld",&i);
    there: printf("%ld\t",++i);
	goto there;
}

void colors()
{
	int i;
	for(i=0;i<5;i++)
    {
    system("color 09");
    system("color 0C");
    system("color 0A");
	}
}


