#include <iostream>
#include <errno.h>
#include <string.h>
#include "err1.h"
using namespace std;
void err1()
{
  cout<<"Error: "<<strerror(errno)<<"\n";
  return;
}
