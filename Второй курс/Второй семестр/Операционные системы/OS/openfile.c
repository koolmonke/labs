#include<stdlib.h> 
#include<stdio.h> 
#include<sys/types.h> 
#include<sys/stat.h> 
#include<fcntl.h>  
#include "of.h" 
 
void openfile(char *path) 
{ 
  int fd;//переменная для открытия файла 
  if(fd=open(path, O_CREAT, S_IRWXU)==-1)//если открытие файла по пути с правами на Открытие или создание, если файла нет, Полные права доступа для пользователя(чтение, запись, исполнение), вернуло -1, то ашибка 
    errl(); 
  else printf(" File opening/creation succesfull\n"); 
}
