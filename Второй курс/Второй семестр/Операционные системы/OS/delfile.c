#include <stdlib.h> 
#include<unistd.h> 
#include<stdio.h> 
#include<sys/types.h> 
#include<sys/stat.h> 
#include<fcntl.h> 
#include "df.h"
 
void delfile(char *path)//получает путь к файлу из главной программы
{ 
  if(unlink(path)==-1)//если удаление мягкой ссылки вернёт -1, то ашибка
    printf("Deletion Error!\n");
  else printf("File deleting succesfull\n");//иначе значит, что выполненная функция unlink прошла успешно и файл удалён, выводим сообщение
}
