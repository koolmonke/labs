#include<stdio.h>
#include<sys/types.h>
#include<sys/stat.h>
#include "md.h"

void makedir(char *path)
{
	if (mkdir(path,0777)==0)//если создание папки по пути и с правами доступа вернуло 0, значит директория успешно создана иначе ашибка
//про права доступа смотри в приложение.txt
		printf("Directory created\n");
	else errl();
}
