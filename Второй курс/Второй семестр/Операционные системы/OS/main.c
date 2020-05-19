#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <stdbool.h>
#include "errl.h"//для ошибок
#include "df.h"//для удаления файла
#include "md.h"//для создания папки
#include "cp.h"//для копирования файла
#include "of.h"//для открытия файла
#include "rd.h"//для переименования папки
#include "rf.h"//для переименования файла
#include "stfile.h"//для того, чтобы узнать статы элемента

int main()
{
	char path[300];//переменная для пути
	char nname[300];//переменная для имени
	char c[50];//переменная для ввода команды
	printf("Type \"help\" to see commands\n");
	while (true)//вечный цикол
	{
	  printf("Enter command: ");
	  scanf("%s",c);//ввод команды
	  if (strcmp(c, "exit")==0)//если команда exit, то выходим
	    return 0;
	  if (strcmp(c, "help")==0)//если команда help, то показываем, что у нас есть из команд
	  {
		  printf("if you want delete file type \"del-f\"\n");
		  printf("if you want to change directory \"chdir\"\n");
		  printf("if you want open file type \"op-f\"\n");
		  printf("if you want withdraw file stats type \"st-f\"\n");
		  printf("if you want copy file type \"cp-f\"\n");
		  printf("if you want rename file type \"rn-f\"\n");
		  printf("if you want delete dir  type \"del-d\"\n");
		  printf("if you want create dir type \"cr-d\"\n");
		  printf("if you want exit type \"exit\"\n");
	  }
	  if (strcmp(c, "chdir")==0)
	  {
		printf("Enter path name: ");
		scanf("%s", path);
		chdir(path);
	  }
	  if (strcmp(c, "del-f")==0)//удаление файла
	  {
		  printf("Enter path name: ");
		  scanf("%s", path);
		  delfile(path);
	  }
	  if (strcmp(c,"op-f")==0)//открытие файла
	  {
		  printf("Enter path name: ");
		  scanf("%s", path);
		  openfile(path);
	  }
	  if (strcmp(c,"st-f")==0)//статистика элемента
	  {
		  printf("Enter path name: ");
		  scanf("%s", path);
		  statfile(path);
	  }
	  if (strcmp(c,"cp-f")==0)//копирование файла
	  {
		  printf("Enter path name: ");
		  scanf("%s", path);
		  printf("Enter new name: ");
		  scanf("%s" ,nname);
		  copyfile(path, nname);
	  }
	  if(strcmp(c,"rn-f")==0)//переименование файла
	  {
		  printf("Enter path name: ");
		  scanf("%s", path);
		  printf("Enter new name: ");
		  scanf("%s" ,nname);
		  renamefile(path, nname);
	  }
	  if (strcmp(c, "del-d")==0)//удаление папки
	  {
	  	  printf("Enter path name: ");
		  scanf("%s", path);
		  deldir(path);
	  }
	  if (strcmp(c,"cr-d")==0)//создание папки
	  {
		  printf("Enter path name: ");
		  scanf("%s", path);
		  makedir(path);
	  }
	}
	return 0;
}
