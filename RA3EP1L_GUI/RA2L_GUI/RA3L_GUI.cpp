#include <tchar.h>
#include <Windows.h>

#include <fstream>
#include <iostream>
#include <cstring>

#include "resource.h"
#pragma comment(linker,"/manifestdependency:\"type='win32' name='Microsoft.Windows.Common-Controls' version='6.0.0.0' processorArchitecture='x86' publicKeyToken='6595b64144ccf1df' language='*'\"")

bool checkDir() {
	using namespace std;
	fstream _file;
	_file.open("RA3EP1.exe",ios::in);
	if(!_file) {
		cout << "请把此程序放在红警3起义时刻文件夹内" << endl;;
		MessageBox(NULL, _T("请把此程序放在红警3起义时刻文件夹内\n找不到文件 RA3EP1.exe"), _T("错误"), MB_OK);
		 _file.close();
		 return false;
      } else {
		  _file.close();
		  return true;
	}
}

BOOL CALLBACK AboutDlgProc(HWND hwnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	switch(Message)
	{
		case WM_INITDIALOG:

		return TRUE;
		case WM_COMMAND:
			switch(LOWORD(wParam))
			{
				case IDOK:
					EndDialog(hwnd, IDOK);
				break;
				case IDCANCEL:
					EndDialog(hwnd, IDCANCEL);
				break;
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
	case WM_INITDIALOG:
		{
			HWND hComBox = GetDlgItem(hwndDlg, START3);
			SendMessage(hComBox, CB_INSERTSTRING, 0, (LPARAM)_T("-ui"));
			SendMessage(hComBox, CB_INSERTSTRING, 1, (LPARAM)_T("-ui -win"));
			HWND hComBoxRA3XYRES = GetDlgItem(hwndDlg, RA3XYRES);
			SendMessage(hComBoxRA3XYRES, CB_INSERTSTRING, 0, (LPARAM)_T("默认分辨率"));
			SendMessage(hComBoxRA3XYRES, CB_INSERTSTRING, 1, (LPARAM)_T("800x600"));
			SendMessage(hComBoxRA3XYRES, CB_INSERTSTRING, 2, (LPARAM)_T("1360x768"));
			SendMessage(hComBoxRA3XYRES, CB_INSERTSTRING, 3, (LPARAM)_T("1600x900"));
			SendMessage(hComBoxRA3XYRES, CB_INSERTSTRING, 4, (LPARAM)_T("当前分辨率"));
		}
		break;
	case WM_COMMAND:
		{
		switch (wParam)
		{
		case IDRA3: {
			TCHAR szTextChangeRes[50] = {0};
			GetDlgItemText(hwndDlg, RA3XYRES, szTextChangeRes, 50);
			if (checkDir()) {
			if ( !_tcscmp(szTextChangeRes, _T("800x600")) ) {
				system("start RA3EP1.exe -xres 800 -yres 600");
			} else if( !_tcscmp(szTextChangeRes, _T("1360x768")) ) {
				system("start RA3EP1.exe -xres 1360 -yres 768");
			} else if( !_tcscmp(szTextChangeRes, _T("1600x900")) ) {
				system("start RA3EP1.exe -xres 1600 -yres 900");
			}  else if( !_tcscmp(szTextChangeRes, _T("当前分辨率")) ) {
				int xres = GetSystemMetrics(SM_CXSCREEN);
				int yres = GetSystemMetrics(SM_CYSCREEN);
				
				char str[50];
				char temp[10];
				
				strcat_s(str, "start RA3EP1.exe -xres ");
				sprintf_s(temp, "%d", xres);
				strcat_s(str, temp);
				strcat_s(str, " -yres ");
				sprintf_s(temp, "%d", yres);
				strcat_s(str, temp);
				system(str);
			} else {
				system("start RA3EP1.exe");
			} } }
			break;
		case IDRA3WIN: {
			TCHAR szTextChangeRes[50] = {0};
			GetDlgItemText(hwndDlg, RA3XYRES, szTextChangeRes, 50);
			if (checkDir()) {
			if ( !_tcscmp(szTextChangeRes, _T("800x600")) ) {
				system("start RA3EP1.exe -xres 800 -yres 600 -win");
			} else if( !_tcscmp(szTextChangeRes, _T("1360x768")) ) {
				system("start RA3EP1.exe -xres 1360 -yres 768 -win");
			} else if( !_tcscmp(szTextChangeRes, _T("1600x900")) ) {
				system("start RA3EP1.exe -xres 1600 -yres 900 -win");
			}  else if( !_tcscmp(szTextChangeRes, _T("当前分辨率")) ) {
				int xres = GetSystemMetrics(SM_CXSCREEN);
				int yres = GetSystemMetrics(SM_CYSCREEN);
				
				char str[50];
				char temp[10];
				
				strcat_s(str, "start RA3EP1.exe -xres ");
				sprintf_s(temp, "%d", xres);
				strcat_s(str, temp);
				strcat_s(str, " -yres ");
				sprintf_s(temp, "%d", yres);
				strcat_s(str, temp);
				strcat_s(str, " -win");
				system(str);
			} else {
				system("start RA3EP1.exe -win");
			} }
			} break;
		case IDRA3EXIT:
			system("taskkill /f /im RA3EP1.exe");
			system("taskkill /f /im ra3ep1_1.0.game");
			break;
		case START3GO:
				{
					TCHAR szText[50] = {0};
					GetDlgItemText(hwndDlg, START3, szText, 50);
					if ( _tcscmp(szText, _T("-ui")) == 0 ) {
						system("start RA3EP1.exe -ui");
					} else if ( _tcscmp(szText, _T("-ui -win")) == 0 ) {
						system("start RA3EP1.exe -ui -win");
					} else
						MessageBox(hwndDlg, _T("未选择项目"), _T("错误"), MB_OK);
				}
				break;
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
		}
	default:
			break;
		}
	}
	
	return 0;
}


INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		break;
	}
	return (INT_PTR)FALSE;
}

int APIENTRY _tWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPTSTR lpCmdLine, int nCmdShow)
{
	if (_tcscmp(lpCmdLine, _T("-help")) == 0) {
		DialogBox(hInstance, MAKEINTRESOURCE(IDD_ABOUT), NULL, About);
	}
	else if (_tcscmp(lpCmdLine, _T("-c")) == 0) {
		DialogBox(hInstance, MAKEINTRESOURCE(IDD_ABOUT), NULL, About);
	}
	else {
		//checkDir();
		DialogBox(hInstance, MAKEINTRESOURCE(IDD_DIALOG1), NULL, RA2L_Main);
	}
	return 0;
}



