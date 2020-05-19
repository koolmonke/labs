#include <cstdlib>
#include <iostream>
#include <sys/types.h>
#include <sys/stat.h>
#include "err1.h"
using namespace std;
void makedir(char *path)
{
  if (mkdir(path,0777)==0)
    cout<<"Directory created\n";
  else err1();
}
