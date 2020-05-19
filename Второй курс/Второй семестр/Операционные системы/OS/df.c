#include <cstdlib>
#include <unistd.h>
#include <iostream>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include "df.h"
#include "err1.h"
using namespace std;
void delfile(char *path)
{
  if(unlink(path)==-1)
    err1();
  else cout<<"File deleting succesfull";
}
