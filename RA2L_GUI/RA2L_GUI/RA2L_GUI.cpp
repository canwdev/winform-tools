#include <tchar.h>
#include <Windows.h>
#include "resource.h"
#pragma comment(linker,"/manifestdependency:\"type='win32' name='Microsoft.Windows.Common-Controls' version='6.0.0.0' processorArchitecture='x86' publicKeyToken='6595b64144ccf1df' language='*'\"")

BOOL CALLBACK AboutDlgProc(HWND hwnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	switch(Message)
	{
		case WM_INITDIALOG:

		return TRUE;
		case WM_COMMAND:
			switch(LOWORD(wParam))
			{
				case IDCANCEL:
					EndDialog(hwnd, IDOK);
				break;
				case IDMORE: {
					MessageBox(NULL, _T("* 把此程序放在红警2文件夹内\n* 建议以管理员身份运行此程序\n* 窗口模式(-win)需16位色\n* 游戏在任务中可以调速 (-speedcontrol)\n"), _T("帮助"), MB_OK);
				break;
							 }
			}
			break;
		default:
			return FALSE;
	}
	return TRUE;
}



INT_PTR CALLBACK RA2L_Main(HWND hwndDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch(message)
	{
	case WM_COMMAND:
		{
		switch (wParam)
		{
		case IDRA2:
			system("start ra2.exe -speedcontrol");
			break;
		case IDRA2WIN:
			system("start ra2.exe -win -speedcontrol");
			break;
		case IDRA2EXIT:
			system("taskkill /f /im ra2.exe");
			system("taskkill /f /im game.exe");

			break;
		case IDYR:
			system("start ra2md.exe -speedcontrol");
			break;
		case IDYRWIN:
			system("start ra2md.exe -win -speedcontrol");
			break;
		case IDYREXIT:
			system("taskkill /f /im ra2md.exe");
			system("taskkill /f /im gamemd.exe");
			break;

		case IDRA2INI: {
			
 
			MessageBox(hwndDlg, _T("\n请手动修改 ra2(md).ini 的 [Video] 内容，改为：\n\n[Video]\nAllowHiResModes=yes\nVideoBackBuffer=no\nAllowVRAMSidebar=no\nScreenWidth=1024\nScreenHeight=768\nStretchMovies=no"), _T("INI优化"), MB_OK);
			break;
					   }
		case IDHELP:
			{
				int ret = DialogBox(GetModuleHandle(NULL), 
						MAKEINTRESOURCE(IDD_ABOUT), hwndDlg, AboutDlgProc);
			}
			break;
		case IDCLOSE:
			EndDialog(hwndDlg, IDCLOSE);
			break;
		case IDCANCEL:
			EndDialog(hwndDlg, IDCANCEL);
			break;


		default:
			break;
		}
	}
	}
	return 0;
}


INT_PTR CALLBACK INIMod(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message)
	{
	case WM_COMMAND:
	{
		switch (wParam)
		{
		case IDCANCEL:
			EndDialog(hWnd, IDCANCEL);
			break;
		case IDOPENHELP:
			//DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUT), hWnd, About);
			//MessageBox(hwndDlg, _T("自动优化功能开发中。o O"), _T("INI优化"), MB_OK);
			break;
		}
	}
	}
	return (INT_PTR)FALSE;
}

int APIENTRY _tWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPTSTR lpCmdLine, int nCmdShow)
{
	if (_tcscmp(lpCmdLine, _T("-mod")) == 0) {
		DialogBox(hInstance, MAKEINTRESOURCE(IDD_INIMOD), NULL, INIMod);
	}
	else if (_tcscmp(lpCmdLine, _T("-help")) == 0) {
		DialogBox(hInstance, MAKEINTRESOURCE(IDD_ABOUT), NULL, AboutDlgProc);
	}
	else if (_tcscmp(lpCmdLine, _T("-c")) == 0) {
		DialogBox(hInstance, MAKEINTRESOURCE(IDD_ABOUT), NULL, AboutDlgProc);
	}
	else {
		DialogBox(hInstance, MAKEINTRESOURCE(IDD_DIALOG1), NULL, RA2L_Main);
	}
	
	
	return 0;
}

