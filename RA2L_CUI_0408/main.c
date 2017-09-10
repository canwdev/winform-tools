#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include <windows.h> 

//设置全屏函数，直接调用即可
void FullScreen(){ 

HWND hwnd=GetForegroundWindow();
int x=GetSystemMetrics(SM_CXSCREEN)+300,y=GetSystemMetrics(SM_CYSCREEN)+300;
char setting[30];
sprintf(setting,"mode con:cols=%d lines=%d",x,y);//设置控制台行数列数
system(setting); 

SetWindowPos(hwnd, HWND_TOPMOST,0,0,x+300,y+300,NULL);//置顶


MoveWindow(hwnd,-10,-40,x+300,y+300,1);//移动
printf("\n\n");
}

int main(void)
{
	int choice=2016;
	//char su[80]={"busybox\ndate\nsu\nexit"};
	//char so[80]={"\n"};
	//char *psu=su;
	
	system("color 4E");
	system("title 红警2启动器 1.0");
	system("mode con cols=39 lines=20");    
	
	//printf("指针测试%s\n",psu);
	//puts(su);
	
	while (choice != 0)
	{
	int choice=2016;
	system("cls");
	printf("╔════╧═══════╧════╗\n");
    printf("║※           红色警戒2          ※║\n");
    printf("╚═════════════════╝\n");
	//功能
	//printf("\n输入数字以启动:\n");
	printf("          1. 启动 红警2\n");
	printf("          2. 启动 尤里的复仇\n");
	printf("\n");
	printf("          3. 结束 红警2\n");
	printf("          4. 结束 尤里的复仇 \n");
	printf(" \n");
	printf("          9. 帮助与关于 \n");
	printf("          0. 退出\n");
	printf("  ═════════════════  \n");
	//选择
		//输入选项
		
		printf("\n           请选择:");
		scanf("%d",&choice);
		system("cls");
		
		//判断并执行 用switch
		 switch (choice)
		 {
		 	case 1:
		    system("start ra2.exe -speedcontrol");
		 	break;
		 	
		 	case 11:
		    system("start ra2.exe -win -speedcontrol");
		 	break;
		 	
		 	case 2:
		 	system("start ra2md.exe -speedcontrol");
		 	break;
		 	
		 	case 22:
		 	system("start ra2md.exe -win -speedcontrol");
		 	break;
		 	
		 	case 3:
		 	system("taskkill /f /im ra2.exe");
		 	system("taskkill /f /im game.exe");
		 	break;
		 	
		 	case 4:
		 	system("taskkill /f /im ra2md.exe");
		 	system("taskkill /f /im gamemd.exe");
		 	break;
		 	
		 	case 9:
		 	system("cls");
		    printf("  ═════════════════\n");
	        printf("               帮助与关于           \n");
	        printf("  ═════════════════\n");
	        printf("  把此程序放在红警2文件夹内。\n");
	        printf("  建议以管理员身份运行此程序。\n");
	        printf("  窗口模式需要调整颜色深度为16位色。\n");
	        printf("  启动的游戏在任务中可以调速。\n");
	        printf("\n");
	        printf("  ※附加指令:\n");
	        printf("  \"11\"或\"22\"——窗口模式\n");
	        printf("  \"233\" ————\"Matrix\"\n");
	        //printf("   \"s\"或 \"r\"——关机/重启\n");
	        printf("\n");
	        printf("  ═════════════════\n");
	        system("pause");
			break; 
			
			case 233:
        	system("title 全屏");
        	FullScreen();
        	system("date /T");
        	system("TIME /T");
        	system("color 0A");
            printf("╔════╧═══════╧════╗\n");
            printf("║※        发现隐藏选项!!        ※║\n");
            printf("╚═════════════════╝\n");
            system("color 0A");
            printf("           请输入任意数字:");
            sleep(1); 
            system("color 09");sleep(1); 
            system("color 0C");sleep(1); 
            system("color 0A");
            scanf("%ld",&choice);
            there: printf("%ld   ",++choice);
	        goto there;
			break;
			
			case 0:
			system("cls");
	        printf("程序结束。");
        	return 0;
        	break;
				
			default :
			printf("  ═════════════════\n");
			printf("                未选择！            \n");
			printf("  ═════════════════\n");
			sleep(1); 
			break;
		 }
		
		//printf("选择了: %d",choice);
	}
	
	//结束程序


	return 0;
}


