#include <stdlib.h>
#include <stdio.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <unistd.h>
#include <errno.h>
#include <string.h>
#include "stfile.h"
#include <time.h>

void statfile(char *path)
{
	int stat(const char *file_name, struct stat *buf);//используется структура из stat.h
	struct stat sb;//наследуется структура из stat.h
	if(stat(path,&sb)==-1)//если не удалось заполнить структуру stat с указанным путём и нашей структурой, то ашибка
		errl();
	else//иначе
	{
		printf("File type:       ");//Тип файла(элемента)
		//тут всё точно как рогаткой в огород, рили
		switch (sb.st_mode & S_IFMT)//в чем смысл, напомню, что S_IFMT это побитовое ИЛИ от всех ниже, то есть st_mode нашей структуры и побитовое И с S_IFMT, вернёт нам один из следующих кейсов 
		{
			case S_IFBLK: printf("block device\n");//Блочное устройство
break;
			case S_IFCHR: printf("character device\n");//Символьное устройство
 break;
			case S_IFDIR: printf("directory\n");//Каталог, папка, директория (все три сразу перечислять не стоит, может доебаться типо в чем разница, а я не ебу)
break;
			case S_IFIFO: printf("FIFO/pipe\n");//Канал FIFO
 break;
			case S_IFLNK: printf("symlink\n");//символическая ссылка
break;
			case S_IFREG: printf("regular file\n");//обычный файл
break;
			case S_IFSOCK: printf("socket\n");//Сокет
break;
			default: printf("unknown?\n");//неизвестный
break;
		}
	}
	printf("i-node number: %ld\n", (long) sb.st_ino);//серийный номер файла
	printf("Mode:    %lo(octal)\n", (unsigned long) sb.st_mode);//выводим права доступа в восьмиричном виде
	if(sb.st_mode & S_IRUSR) printf(" owner has read permission\n");//есть права на чтение у Владельца
	if(sb.st_mode & S_IWUSR) printf(" owner has write permission\n");//есть права на запись у Владельца
	if(sb.st_mode & S_IXUSR & !S_IFDIR) printf(" owner has execute permission\n");//есть права на Испольнение у Владельца ЕСЛИ ЭТО НЕ ПАПКА
	if(sb.st_mode & S_IRGRP) printf(" group has read permission\n");//у группы Владельца есть права на чтение
	if(sb.st_mode & S_IWGRP) printf(" group has write permission\n");//у группы Владельца есть права на запись
	if(sb.st_mode & S_IXGRP & !S_IFDIR) printf(" group has execute permission\n");//у группы Владельца есть права на Исполнение ЕСЛИ ЭТО НЕ ПАПКА
	if(sb.st_mode & S_IROTH) printf(" others has read permission\n");//у остальных пользователей есть права на чтение
	if(sb.st_mode & S_IWOTH) printf(" owner has write permission\n");//у остальных пользователей есть права на запись
	if(sb.st_mode & S_IXOTH & !S_IFDIR) printf(" others has execute permission\n");//у остальных пользователей есть права на исполнение

	printf("Link count: %ld\n", (long) sb.st_nlink);//вывод количества ссылок к файлу
	printf("Ownership: UID=%ld GID=%ld\n", (long) sb.st_uid, (long) sb.st_gid);//id группы файла
	printf("Preferred I/o block size: %lld bytes\n", (long long) sb.st_size);//размер файла в байтах, если это обычный файла
	printf(" Blocks allocated: %lld\n", (long long) sb.st_blocks);//количество блоков выделенных для этого элемента
}
