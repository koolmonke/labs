#include <cstdlib>
#include <iostream>
#include <string.h>
#include "err1.h"   //обработчик ошибок
#include "df.h"		//удаляет файл
#include "md.h"		//создает каталог
#include "cp.h"		//копирует файл
#include "of.h"		//открывает файл
#include "rd.h"		//удаляет  каталог
#include "rf.h"		//переименовывает  файл
#include "stfile.h" //выдает информацию о файле
/*Основной модуль передаёт некоторое значение (в данном случае он передаёт пути к файлам или каталогам)
 * в написанные нами процедуры (которые находятся в модулях) в зависимости от параметров входной строки.
 * То есть наш основной модуль выполняет функции командного интерпретатора.*/
using namespace std;

int main()
{
	char path[300];
	char nname[300];
	char c[50];

	cout << "if you want delete file type \"del-f\"\n";
	cout << "if you want open file type \"op-f\"\n";
	cout << "if you want withdraw file stats type \"st-f\"\n";
	cout << "if you want copy file type \"cp-f\"\n";
	cout << "if you want rename file type \"rn-f\"\n";
	cout << "if you want delete dir type \"del-d\"\n";
	cout << "if you want create dir type \"cr-d\"\n";
	cout << "if you want exit type \"exit\"\n";

	while (true)
	{
		cin >> c;
		if (strcmp(c, "exit") == 0)
			return 0;
		if (strcmp(c, "del-f") == 0)
		{ // cравнение 2 строк //удаляет файл
			cout << "Enter path name\n";
			cin >> path;
			delfile(path);
			cout << "Enter command\n";
		}
		if (strcmp(c, "op-f") == 0)
		{ //открывает файл
			cout << "Enter path name\n";
			cin >> path;
			openfile(path);
			cout << "Enter command\n";
		}
		if (strcmp(c, "st-f") == 0)
		{ //выдает информацию о файле
			cout << "Enter path name\n";
			cin >> path;
			statfile(path);
			cout << "Enter commаnd\n";
		}
		if (strcmp(c, "cp-f") == 0)
		{ //копирует файл
			cout << "Enter path name\n";
			cin >> path;
			cout << "Enter new name\n";
			cin >> nname;
			copyfile(path, nname);
			cout << "Enter command\n";
		}
		if (strcmp(c, "rn-f") == 0)
		{ //переименовывает  файл
			cout << "Enter path name\n";
			cin >> path;
			cout << "Enter new name\n";
			cin >> nname;
			renamefile(path, nname);
			cout << "Enter command\n";
		}
		if (strcmp(c, "del-d") == 0)
		{ //удаляет  каталог
			cout << "Enter path name\n";
			cin >> path;
			deldir(path);
			cout << "Enter command\n";
		}
		if (strcmp(c, "cr-d") == 0)
		{ //создает каталог
			cout << "Enter path name\n";
			cin >> path;
			makedir(path);
			cout << "Enter command\n";
		}
	}
	return 0;
}
