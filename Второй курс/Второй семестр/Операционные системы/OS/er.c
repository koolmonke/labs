#include<stdio.h>
#include<errno.h>
#include<string.h>
#include"errl.h"

void errl()
{
  printf("Error:%s\n",strerror(errno));//вывод сообщений об ошибке и саму ошибку
}
